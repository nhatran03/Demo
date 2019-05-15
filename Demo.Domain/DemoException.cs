using System;
using System.Runtime.Serialization;

namespace Demo.Domain
{
	public class DemoException : Exception
	{
		/// <summary>
		/// Creates a new <see cref="DemoException"/> object.
		/// </summary>
		public DemoException()
		{

		}

		/// <summary>
		/// Creates a new <see cref="DemoException"/> object.
		/// </summary>
		public DemoException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

		}

		/// <summary>
		/// Creates a new <see cref="DemoException"/> object.
		/// </summary>
		/// <param name="message">Exception message</param>
		public DemoException(string message)
            : base(message)
        {

		}

		/// <summary>
		/// Creates a new <see cref="DemoException"/> object.
		/// </summary>
		/// <param name="message">Exception message</param>
		/// <param name="innerException">Inner exception</param>
		public DemoException(string message, Exception innerException)
            : base(message, innerException)
        {

		}
	}
}
