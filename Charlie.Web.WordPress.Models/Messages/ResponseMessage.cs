using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Charlie.Web.WordPress.Models.Messages
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ResponseMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseMessage"/> class.
        /// </summary>
        /// <param name="msg">The message.</param>
        public ResponseMessage(string msg)
        {
            this.Message = msg;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseMessage"/> class.
        /// </summary>
        public ResponseMessage()
            : this(string.Empty)
        {
        }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        [JsonProperty("msg")]
        public string Message { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ResponseDataMessage : ResponseDataMessage<object>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseDataMessage"/> class.
        /// </summary>
        /// <param name="data">The source.</param>
        public ResponseDataMessage(object data)
            : base(data)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseDataMessage"/> class.
        /// </summary>
        /// <param name="msg">msg</param>
        /// <param name="data">The source.</param>
        public ResponseDataMessage(string msg,object data):base(msg,data)
        {
            
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class ResponseDataMessage<T> : ResponseMessage
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [JsonProperty("data")]
        protected virtual T Data { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseDataMessage{T}"/> class.
        /// </summary>
        /// <param name="data">The source.</param>
        public ResponseDataMessage(T data):base()
        {
            this.SetData(data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseDataMessage{T}"/> class.
        /// </summary>
        /// <param name="msg">The message.</param>
        /// <param name="data">The data.</param>
        public ResponseDataMessage(string msg,T data):base(msg)
        {
                this.SetData(data);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseDataMessage{T}"/> class.
        /// </summary>
        /// <param name="msg">The message.</param>
        public ResponseDataMessage(string msg):base(msg)
        {
        }
        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="data"></param>
        private void SetData(T data)
        {
            this.OnDataChanging(data);
            this.Data = data;
            this.OnDataChanged(data);
        }

        /// <summary>
        /// Called when [data changing].
        /// </summary>

        /// <param name="data"></param>
        protected virtual void OnDataChanging(T data)
        {
        }

        /// <summary>
        /// Called when [data changed].
        /// </summary>
        /// <param name="data">The source.</param>
        protected virtual void OnDataChanged(T data)
        {
        }
    }
    /// <summary>
    /// 
    /// </summary>
    [Serializable]

    public class ResponseStatusMessage : ResponseDataMessage<bool>
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ResponseStatusMessage"/> is successed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if successed; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("successed")]
        public bool Successed
        {
            get
            {
                return base.Data;
            }
            set
            {
                base.Data = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseStatusMessage"/> class.
        /// </summary>
        /// <param name="successed">if set to <c>true</c> [successed].</param>
        public ResponseStatusMessage(bool successed)
            : base(successed)
        {
        }


        public readonly static ResponseStatusMessage Successe = new ResponseStatusMessage(true);

        public static ResponseStatusMessage Failure(string msg)
        {
            return new ResponseStatusMessage(false)
            {
                 Message=msg
            };
        }

    }




}
