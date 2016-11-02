﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;

namespace HermaFx.Settings
{
	[AttributeUsage(AttributeTargets.Interface | AttributeTargets.Property, AllowMultiple = false)]
	public sealed class SettingsAttribute : Attribute, IPropertyDescriptorInitializer
	{
		public const string DEFAULT_PREFIX_SEPARATOR = ":";

		/// <summary>
		/// Gets or sets the key prefix.
		/// </summary>
		/// <value>
		/// The key prefix.
		/// </value>
		public string KeyPrefix { get; }
		/// <summary>
		/// Gets or sets the prefix separator.
		/// </summary>
		/// <value>
		/// The prefix separator.
		/// </value>
		public string PrefixSeparator { get; set; }

		public SettingsAttribute()
		{
			PrefixSeparator = DEFAULT_PREFIX_SEPARATOR;
		}

		public SettingsAttribute(string keyPrefix)
			: this()
		{
			KeyPrefix = keyPrefix;
		}

		#region IPropertyDescriptorInitializer

		public int ExecutionOrder => DictionaryBehaviorAttribute.LastExecutionOrder;

		public void Initialize(PropertyDescriptor propertyDescriptor, object[] behaviors)
		{
			propertyDescriptor.Fetch = true;
		}

		public IDictionaryBehavior Copy()
		{
			return this;
		}

		#endregion

	}
}
