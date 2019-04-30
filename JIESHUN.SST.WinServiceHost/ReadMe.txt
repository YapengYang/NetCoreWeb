这是微服务的宿主程序。只要H.SPS.WinServiceHost+带有IService的Dll就能组成一个微服务，
用法请参考H.SPS.BusinessService的Service.cs和ControllerRegister.cs


运行时的环境信息

举例：
Env.SystemInfo   系统信息
Env.ApplicationServices   IOC
Env.LoggerFactory    日志打印
Env.RuntimeInfo    运行时需要的

如果哪个接口经常用，也可以在里面保存个快捷方式
Env.BizXXXX