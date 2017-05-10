using System;
using JMetalCSharp.Core;

namespace JMetalCSharp.Encoding.Variable
{
	/// <summary>
	/// This abstract class is the base for defining new types of variables.
	/// </summary>
	public class Variable<T> : Core.Variable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="JMetalCSharp.Encoding.Variable.Variable`1"/> class.
		/// </summary>
		/// <param name="value">Value.</param>
		public Variable(T value)
		{
			Value = value;
		}

		/// <summary>
		/// Creates an exact copy of a <code>Variable</code> object.
		/// </summary>
		/// <returns>the copy of the object.</returns>
		public override Core.Variable DeepCopy()
		{
			return new Variable<T>(Value);
		}

		/// <summary>
		/// Get or Set the double value representating the encodings.variable.
		/// </summary>
		public new T Value { get; set; }

		/// <summary>
		/// Get or Set the upper bound value of a encodings.variable.
		/// </summary>
		public new T LowerBound { get; set; }

		/// <summary>
		/// Get or Set the lower bound value of a encodings.variable.
		/// </summary>
		public new T UpperBound { get; set; }

		/// <summary>
		/// Gets the type of the encodings.variable. The types are defined in class Problem.
		/// </summary>
		/// <returns>The type of the encodings.variable</returns>
		public new Type GetVariableType()
		{
			return this.GetType();
		}
	}
}

