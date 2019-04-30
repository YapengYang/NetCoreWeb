using H.SPS.Common;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Text;

namespace H.SPS.BusinessService
{
    /// <summary>
    /// 
    /// </summary>
    [Route("Vistor")]
    public class VistorService 
    {
        /// <summary>
        /// 从第三方获取系统实现，如第三方没有实现就获取服务器时间
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation("QueryCurrentTime")]
        public QueryCurrentTimeRes QueryCurrentTime([FromBody]QueryCurrentTimeReq req)
        {
            return new QueryCurrentTimeRes() { CurrentTime = req.CurrentTime };
        }
        /// <summary>
        /// 登录，返回操作员信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation("QueryVistorOperator")]
        public QueryVistorOperatorRes QueryVistorOperator([FromBody]QueryVistorOperatorReq req)
        {
            return new QueryVistorOperatorRes();
        }
        /// <summary>
        /// 登录，返回操作员信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation("QueryVistorPersonInfo")]
        public QueryVistorPersonInfoRes QueryVistorPersonInfo([FromBody]QueryVistorPersonInfoReq req)
        {
            return new QueryVistorPersonInfoRes();
        }
        /// <summary>
        /// 加载访客系统策略
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation("QueryVistorStrategy")]
        public QueryVistorStrategyRes QueryVistorStrategy([FromBody]QueryVistorStrategyReq req)
        {
            return new QueryVistorStrategyRes();
        }
        /// <summary>
        /// 获取访客机的申请的记录
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation("QueryVistorApproveResult")]
        public QueryVistorApproveResultRes QueryVistorApproveResult([FromBody]QueryVistorApproveResultReq req)
        {

            return new QueryVistorApproveResultRes();
        }
        /// <summary>
        /// 获取访客当日统计数据请求参数
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation("QueryVistorStatistics")]
        public QueryVistorStatisticsRes QueryVistorStatistics([FromBody]QueryVistorStatisticsReq req)
        {
            return new QueryVistorStatisticsRes();
        }
        /// <summary>
        /// 提交访客申请
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation("PostVistorInfo")]
        public PostVistorInfoRes PostVistorInfo([FromBody]PostVistorInfoReq req)
        {
            return new PostVistorInfoRes();
        }
        /// <summary>
        /// 提交取访客凭证记录（已打印，保存记录）
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation("PostPickVoucherRecord")]
        public PostPickVoucherRecordRes PostPickVoucherRecord([FromBody]PostPickVoucherRecordReq req)
        {
            return new PostPickVoucherRecordRes();
        }
    }
}
