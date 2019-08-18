﻿using System;

namespace NetCore.Test.Token.Model
{
    public class TokenModel
    {
        public TokenModel()
        {
            this.Uid = 0;
        }
        /// <summary>
        /// 用户Id
        /// </summary>
        public long Uid { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Uname { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string UNickname { get; set; }
        /// <summary>
        /// 身份
        /// </summary>
        public string Sub { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public int expireMinutes { get; set; }
    }

}
