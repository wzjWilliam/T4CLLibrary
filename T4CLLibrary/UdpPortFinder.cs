using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections.Generic;

internal class UdpPortFinder
{
    /// <summary>
    /// 通过netstat获取当前系统上所有正在监听的UDP端口信息
    /// </summary>
    /// <returns></returns>
    public static List<UdpPortInfo> GetUdpListeningPorts()
    {
        var result = new List<UdpPortInfo>();

        // 创建进程启动信息
        var psi = new ProcessStartInfo
        {
            FileName = "netstat.exe",
            Arguments = "-ano -p UDP",
            WindowStyle = ProcessWindowStyle.Hidden,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            StandardOutputEncoding = System.Text.Encoding.UTF8
        };

        // 启动进程
        using (var process = new Process { StartInfo = psi })
        {
            process.Start();

            // 读取输出
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            // 解析输出
            result = ParseNetStatOutput(output);
        }

        return result;
    }

    /// <summary>
    /// 解析netstat的输出
    /// </summary>
    /// <param name="output">netstat输出</param>
    /// <returns>UDP端口信息</returns>
    private static List<UdpPortInfo> ParseNetStatOutput(string output)
    {
        var result = new List<UdpPortInfo>();
        var lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        // 正则表达式匹配UDP行
        // 示例行: UDP    0.0.0.0:500          *:*                                    1234
        var regex = new Regex(@"^\s*UDP\s+([^:]+):(\d+)\s+\S+\s+(\d+)\s*$", RegexOptions.Compiled);

        foreach (var line in lines)
        {
            var match = regex.Match(line);
            if (match.Success)
            {
                try
                {
                    var ipAddress = match.Groups[1].Value;
                    var port = int.Parse(match.Groups[2].Value);
                    var pid = int.Parse(match.Groups[3].Value);

                    result.Add(new UdpPortInfo
                    {
                        Protocol = "UDP",
                        LocalAddress = ipAddress,
                        LocalPort = port,
                        ProcessId = pid
                    });
                }
                catch (FormatException)
                {
                    // 忽略解析错误的行
                    continue;
                }
            }
        }

        return result;
    }
}

internal class UdpPortInfo
{
    public string Protocol { get; set; }
    public string LocalAddress { get; set; }
    public int LocalPort { get; set; }
    public int ProcessId { get; set; }
    public string ProcessName { get; set; }

    /// <summary>
    /// 根据进程ID解析进程名称
    /// </summary>
    public void ResolveProcessName()
    {
        try
        {
            var process = Process.GetProcessById(ProcessId);
            ProcessName = process.ProcessName;
        }
        catch (ArgumentException)
        {
            ProcessName = null;
        }
    }

    public override string ToString()
    {
        return $"{Protocol} {LocalAddress}:{LocalPort} -> PID: {ProcessId} ({ProcessName ?? "Not resolved"})";
    }
}