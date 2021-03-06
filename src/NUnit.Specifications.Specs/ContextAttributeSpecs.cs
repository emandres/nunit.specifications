﻿using System;
using System.Dynamic;
using System.IO;
using System.Linq.Expressions;
using NUnit.Framework;
using NUnit.Specifications.Specs.Attributes;
using Should;

namespace NUnit.Specifications.Specs
{
	public class ContextAttributeSpecs
	{
		[Initializable]
		public class when_a_specification_is_decorated_with_a_context_attribute : ContextSpecification
		{
			It should_initialize_the_attribute = () => ((bool) Context.IsInitialized).ShouldBeTrue();

			It should_initialize_the_attribute_only_once = () => ((int) Context.InitializeCount).ShouldEqual(1);
		}
	}

	// Used to manually validate that excluded categories don't get executed
	[CreateFile("touch.txt"), Category("exclude")]
	public class when_an_specification_is_decorated_with_a_context_attribute_that_creates_a_file : ContextSpecification
	{
		Cleanup after = () => File.Delete("touch.txt");

		It should_not_execute = () => File.Exists("touch.txt").ShouldBeTrue();
	}
}