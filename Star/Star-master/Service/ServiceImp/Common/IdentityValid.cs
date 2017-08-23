using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Service.Models;

namespace Service.ServiceImp.Common
{
    public static class IdentityValid
    {
        private static readonly string AppSecret = "liansida";
        //测试临时调大
        private static double SignExpMinutes = 30 * 24 * 60; //10;
        private static double TokenExpMinutes = 30 * 24 * 60;
        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="appid"></param>
        /// <returns></returns>
        public static bool ValidateSignature(string signature, string timestamp, string nonce, string appid)
        {
            string[] arrTmp = { AppSecret, timestamp, nonce };
            bool IsSuccess = false;
            Array.Sort(arrTmp);
            string tmpStr = string.Join("", arrTmp);

            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            if (tmpStr != null)
            {
                tmpStr = tmpStr.ToLower();

                if (tmpStr == signature)
                {
                    DateTime dtTime = Convert.ToDateTime(timestamp);
                    double minutes = DateTime.Now.Subtract(dtTime).TotalMinutes;
                    if (minutes > SignExpMinutes)
                    {
                        //msg = "签名时间戳失效";
                        IsSuccess = false;
                    }
                    else
                    {
                      //  msg = "";
                        IsSuccess = true;
                    }
                }
                else
                {
                   // msg = "签名不正确！";
                    IsSuccess = false;
                }
            }
            else
            {
               // msg = "非法签名！";
                IsSuccess = false;
            }
            return IsSuccess;
        }
        /// <summary>
        /// 创建Token
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="appid"></param>
        /// <param name="expTime"></param>
        /// <returns></returns>
        public static string CreateToken(string userName,string appid)
        {
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var now = Math.Round((DateTime.UtcNow.AddDays(30) - unixEpoch).TotalSeconds);

            var payload = new Dictionary<string, object>()
            {
                { "userName",  userName},
                { "appid", appid },
                {"exp",now }
            };
            return JWT.JsonWebToken.Encode(payload, AppSecret, JWT.JwtHashAlgorithm.HS256);
        }
        /// <summary>
        /// 验证Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static TokenResult ValidateToken(string token)
        {
            var tokenResult = new TokenResult();
            try
            {
                var payload = JWT.JsonWebToken.DecodeToObject(token, AppSecret) as IDictionary<string, object>;
                var userName = payload["userName"].ToString();
                var appid = payload["appid"].ToString();
                tokenResult.token = token;
                tokenResult.userName = userName;
                tokenResult.appid = appid;
                tokenResult.IsSuccess = true;
            }
            catch (JWT.SignatureVerificationException)
            {
                tokenResult.token = "";
                tokenResult.Msg = "Token非法！";
                tokenResult.IsSuccess = false;
            }
            return tokenResult;
        }
    }
}
