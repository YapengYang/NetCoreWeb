using System;
using System.Collections.Generic;
using System.Text;

namespace H.SPS.Common
{
    public interface IVistorDataManager
    {
        /// <summary>
        /// 从第三方获取系统实现，如第三方没有实现就获取服务器时间
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        QueryCurrentTimeRes QueryCurrentTime(QueryCurrentTimeReq req);
        /// <summary>
        /// 登录，返回操作员信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>

        QueryVistorOperatorRes QueryVistorOperator(QueryVistorOperatorReq req);
        /// <summary>
        /// 登录，返回操作员信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        QueryVistorPersonInfoRes QueryVistorPersonInfo(QueryVistorPersonInfoReq req);
        /// <summary>
        /// 加载访客系统策略
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        QueryVistorStrategyRes QueryVistorStrategy(QueryVistorStrategyReq req);
        /// <summary>
        /// 获取访客机的申请的记录
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        QueryVistorApproveResultReq QueryVistorApproveResult(QueryVistorApproveResultReq req);
        /// <summary>
        /// 获取访客当日统计数据请求参数
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        QueryVistorStatisticsRes QueryVistorStatistics(QueryVistorStatisticsReq req);
        /// <summary>
        /// 提交访客申请
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        PostVistorInfoRes PostVistorInfo(PostVistorInfoReq req);
        /// <summary>
        /// 提交取访客凭证记录（已打印，保存记录）
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        PostPickVoucherRecordRes PostPickVoucherRecord(PostPickVoucherRecordReq req);
    }
}
