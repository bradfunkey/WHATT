using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Whatt.Web.HtmlHelpers
{
	public static class KnockoutExtensions
	{
		/// <summary>
		/// Creates a pipeline to javascript to pass the C# ViewModel into Knockout js
		/// </summary>
		/// <param name="html"></param>
		/// <param name="model"></param>
		/// <param name="camelCasePropertyNames"></param>
		/// <param name="localizeDateTimes"></param>
		/// <returns></returns>
		public static IHtmlString KnockoutViewModelFrom(this HtmlHelper html, object model,
			 bool camelCasePropertyNames = true, bool localizeDateTimes = true)
		{
			var serializerSettings = new JsonSerializerSettings();
			if (camelCasePropertyNames)
				serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

			if (localizeDateTimes)
				serializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;

			var sb = new StringBuilder();

			sb.Append("(function() {");
			var json = JsonConvert.SerializeObject(model, serializerSettings);

			sb.Append("var vm = ko.mapping.fromJS(" + json + ");");

			var type = model.GetType();
			var jsNamespace = (type.Namespace ?? "");

			sb.Append("Whatt.namespace('" + jsNamespace + "');");
			sb.Append(jsNamespace + "." + type.Name + " = vm;");

			sb.Append("})();");

			return new HtmlString(sb.ToString());
		}
	}
}
