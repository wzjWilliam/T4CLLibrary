# T4CLLibrary
一个关于机房管理助手和极域的库，可以方便的做出用来在信息课上结束极域和机房管理助手的程序。

## 注意：
- 本程序为**库**，而不是可执行文件（Demo也只是演示，可能会有大量的Bug）。
- 本人是C#新手，所以有些代码会十分奇妙，遇到问题可以反馈。

## 目的
肯定很多人都想制作这种类型的程序，但是被某些细节（如: 更改极域密码、获取机房管理助手随机进程名等）所难住，本库就是提供了一些简单的函数来让想做这种程序的人无需重复造轮子。

## 用法
在VS等软件中将`T4CLLibrary.dll`添加为依赖，之后导入`T4CLLibrary`、`T4CLLibrary.Mythware`以及`T4CLLibrary.Jfglzs`这几个命名空间，然后参考Demo中的方法调用函数，~~懒得自己写了~~。

目前已经支持: 
- 结束机房管理助手以及极域所有进程；
- 自动计算机房管理助手随机进程名；
- 挂起以及恢复极域主进程（即StudentMain.exe）；
- 获取极域密码，设置机房管理助手密码和获取机房管理助手9\.99版及以上的的密码(获取为暴力破解)
- 获取机房管理助手临时密码
- 极域UDP重放攻击
- 更方便的结束、挂起或恢复进程的方法；

## 其他
### T4CL是什么？
我自己随便搞的缩写，全称为Tools for Computer Lesson，即机房工具。这也是我以前某个项目的名称，功能与这个相似，但是是可执行文件（用WinForms写的UI）。
### 引用
- 加密和解密极域密码: [这个项目](https://github.com/MuliMuri/Mythware)
- 极域UDP重放攻击: [这个项目](https://github.com/ht0Ruial/Jiyu_udp_attack)