using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebApp.Infrastructure.Configuration.AppSettingDetail;

namespace WebApp.Infrastructure.Configuration
{
    public class AppSettings
    {
        public DomainSettings DomainSettings { get; set; }
        public ZaloSettings ZaloSettings { get; set; }
        public EmailSettings EmailSettings { get; set; }
        public PathSettings PathSettings { get; set; }
        public GeneralSettings GeneralSettings { get; set; }
        // ddphuong:11/08/2023  add setting
        public GenerateQRCodeSettings GenerateQRCodeSettings { get; set; }
        /// <summary>
        /// Thông tin config ZNS
        /// </summary>
        public ZNSSettings ZNSSettings { get; set; }
        public SecuritySettings SecuritySettings { get; set; }
        
    }
    public class AppSettingDetail
    {
        public class DomainSettings
        {
            /// <summary>
            /// doamain thanh toán onepay
            /// </summary>
            public string OnepayService { get; set; }
            /// <summary>
            /// domain côn đảo
            /// </summary>
            public string LangBiangService { get; set; }
            /// <summary>
            /// Domain Zalo
            /// </summary>
            public string ZaloService { get; set; }
            /// <summary>
            /// domain lấy token authen zalo
            /// </summary>
            public string TokenZaloUrl { get; set; }
            /// <summary>
            /// domain Generate QR Code
            /// </summary>
            public string GenerateQRCodePayment { get; set; }
            /// <summary>
            /// domain authenZNS
            /// </summary>
            public string AuthZNSService { get; set; }
            /// <summary>
            /// doamain gủi tin zns
            /// </summary>
            public string ZNSService { get; set; }
            /// <summary>
            /// Auth Gaman
            /// </summary>
            public string OAuthGamanService { get; set; }
        }

        public class ZaloSettings
        {
            /// <summary>
            /// key
            /// </summary>
            public string APIKey { get; set; }
            /// <summary>
            /// mã bảo mật
            /// </summary>
            public string APISecert { get; set; }
            public string TemplateID { get; set; }
            public string CampainID { get; set; }
            /// <summary>
            /// URL hình qrcode
            /// </summary>
            public string URLQRCode { get; set; }
            /// <summary>
            /// cta code 
            /// </summary>
            public string CTACode { get; set; }
        }

        public class EmailSettings
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string SMTPAddress { get; set; }
            public int SMTPPort { get; set; }
        }
        public class PathSettings
        {
            public string TemplateEmail { get; set; }
        }
        public class GeneralSettings
        {
            public string RootFolder { get; set; }
            public string QRCodeFolder { get; set; }
        }

        public class GenerateQRCodeSettings
        {
            /// <summary>
            /// key
            /// </summary>
            public string ApiKey { get; set; }
            /// <summary>
            /// ClientId
            /// </summary>
            public string ClientId { get; set; }
            
        }

        public class ZNSSettings
        {
            /// <summary>
            /// ID OA
            /// </summary>
            public  long OAId { get; set; }
            /// <summary>
            /// ID ứng dụng
            /// </summary>
            public long AppId { get; set; }
            /// <summary>
            /// ID template
            /// </summary>
            public string TemplateID { get; set; }
            /// <summary>
            /// cta code 
            /// </summary>
            public string CTACode { get; set; }
            /// <summary>
            /// Tên đơn vị gửi ZNS
            /// </summary>
            public string CompanyName { get; set; }
        }

        public class SecuritySettings
        {
            public string AuthenticationKey { get; set; }
        }
    }

    
}
