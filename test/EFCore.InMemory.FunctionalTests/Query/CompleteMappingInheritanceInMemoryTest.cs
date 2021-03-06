﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Query
{
    public class CompleteMappingInheritanceInMemoryTest : InheritanceTestBase<CompleteMappingInheritanceInMemoryFixture>
    {
        public CompleteMappingInheritanceInMemoryTest(CompleteMappingInheritanceInMemoryFixture fixture)
            : base(fixture)
        {
        }

        [ConditionalFact]
        public override void Can_query_all_animal_views()
        {
            var message = Assert.Throws<InvalidOperationException>(() => base.Can_query_all_animal_views()).Message;

            Assert.Equal(
                CoreStrings.TranslationFailed(
                    @"DbSet<Bird>()
    .Select(b => InheritanceInMemoryFixture.MaterializeView(b))
    .OrderBy(a => a.CountryId)"),
                message);
        }

        protected override bool EnforcesFkConstraints => false;
    }
}
