using DomainLayer.Enums;
using System;

namespace DomainLayer.Response
{
	public class BaseResponse<TData> : IBaseResponse<TData>
	{
		/// <summary>
		/// Свойство для описания исключительных ситуаций и предупреждений
		/// </summary>
		public string Description { get; set; }
        public StatusCode StatusCode { get; set; }
        public TData Data { get; set; }
    }

	public interface IBaseResponse<TData>
	{
		TData Data { get; set; }
	}
}
