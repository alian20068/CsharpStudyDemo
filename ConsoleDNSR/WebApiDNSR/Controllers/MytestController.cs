using Aliyun.Acs.Alidns.Model.V20150109;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDNSR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MytestController : ControllerBase
    {
        private string aliyun_dns_access_key = "";
        private string aliyun_dns_secret_key = "";
        [HttpGet]
        public ActionResult<string> EchoIp()
        {
            //获取自己的ip地址
            // http://www.ip138.com/
            // https://www.ipify.org/
            var currentIp = HttpContext.Connection.RemoteIpAddress.ToString();

            //https://help.aliyun.com/document_detail/124923.html
            //https://cloud.tencent.com/document/product/302/8516
            var acsClient = new DefaultAcsClient(
                DefaultProfile.GetProfile(
                    "",
                    aliyun_dns_access_key,
                    aliyun_dns_secret_key
                )
            );
            //更新 cool.mydomain.cc 为最新Ip
            var domainRecords = acsClient.GetAcsResponse(new DescribeDomainRecordsRequest
            {
                DomainName = "mydomain.cc",
                RRKeyWord = "cool",
            }).DomainRecords;

            var homeRecord = domainRecords.First(x => x.RR == "home");
            if (homeRecord._Value != currentIp)
            {
                acsClient.GetAcsResponse(new UpdateDomainRecordRequest
                {
                    RecordId = homeRecord.RecordId,
                    RR = homeRecord.RR,
                    Type = homeRecord.Type,
                    _Value = currentIp,
                });
                string.Format($"{homeRecord._Value} -> {currentIp}");
            }
            else
            {
                string.Format("DNS not changed");
            }

            //cool.mydomain.cc 显示 home.mydomain.cc:44403
            acsClient.GetAcsResponse(new AddDomainRecordRequest
            {
                DomainName = "mydomain.cc",
                RR = "cool",
                Type = "SRV",//记录提供特定的服务的服务器
                _Value = "0 5 44403 home.mydomain.cc",
            });

            return currentIp;
        }
    }
}
