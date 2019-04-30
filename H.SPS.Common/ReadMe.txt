本项目为公共类库

--DTO  数据传输对象，用于接口的输入输出参数
--Interface  系统所有的接口都在这里，整个系统就是由这些接口组成
--Model 模型
--Utilty 工具类如序列化、压缩、邮件等


约定：
1.Model和DTO里面的内容都是POCO,请以public字段提供而非属性(get/set)，用属性去封装显得(冗余)很乱，
也不要在Model和DTO里面写什么方法

2.与访客有关的模型以Vistor开头命名，方便区分。假设要另外再做个ATM系统，则同样以ATM开头命名

3.每个对外暴露的方法都需要以DTO作为参数，除非明确知道无输入参数或者输出参数。这是为了方便扩展，虽然现在不用，不代表以后不会增加,
输入DTO以Req结尾，输出DTO以Res结尾，例如GetTimeReq,GetTimeRes，Req和Res请放在同一个文件里面

4.IESHUN.SST.Business.Vistor3rd和H.SPS.Business.VistorJieLink
以及Device下面的各个项目里面的Model、DTO等放在各自的项目即可，不需要放这个项目,
比如JieLink里面的操作员叫comOperator，则comOperator放在H.SPS.Business.VistorJieLink项目
，comOperator和访客机的VistorOperatorInfo之间由个转换，如果可以，用AutoMapper

5.相同类型的东西放在一起或以同样的方式去命名，方便阅读  
