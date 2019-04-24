﻿/*
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License.
 */

using System;
using System.Management.Automation;
using Microsoft.PowerBI.Common.Abstractions;
using Microsoft.PowerBI.Common.Abstractions.Interfaces;
using Microsoft.PowerBI.Common.Client;

namespace Microsoft.PowerBI.Commands.OnPremisesDataGateway
{
    [Cmdlet(CmdletVerb, CmdletName)]
    [OutputType(typeof(void))]
    public class RemoveOnPremisesDataGatewayClusterUser : PowerBIClientCmdlet, IUserScope
    {
        public const string CmdletName = "OnPremisesDataGatewayClusterUser";
        public const string CmdletVerb = VerbsCommon.Remove;

        [Parameter()]
        public PowerBIUserScope Scope { get; set; } = PowerBIUserScope.Individual;

        [Alias("Cluster")]
        [Parameter()]
        public Guid GatewayClusterId { get; set; }

        [Parameter()]
        public Guid PrincipalObjectId { get; set; }

        public override void ExecuteCmdlet()
        {
            using (var client = CreateClient())
            {
                var result = client.GatewaysV2.DeleteUserOnGatewayCluster(GatewayClusterId, PrincipalObjectId, this.Scope == PowerBIUserScope.Individual).Result;
                Logger.WriteObject(result, true);
            }
        }
    }
}
