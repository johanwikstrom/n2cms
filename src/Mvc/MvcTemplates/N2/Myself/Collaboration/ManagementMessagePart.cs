﻿using N2.Definitions;
using N2.Details;
using N2.Edit.Collaboration;
using N2.Integrity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N2.Management.Myself.Collaboration
{
	[AllowedZones("Collaboration")]
	[PartDefinition("Management message")]
	[WithEditableTitle]
	[Versionable(AllowVersions.No)]
	public class ManagementMessagePart : RootPartBase, IMessageSource
	{
		[EditableText]
		public virtual string Text { get; set; }

		[EditableCheckBox]
		public virtual bool Alert { get; set; }

		public IEnumerable<CollaborationMessage> GetMessages(CollaborationContext context)
		{
			if (this.IsPublished())
				yield return new CollaborationMessage { Title = Title, Alert = Alert, Text = Text, Updated = Updated };
		}
	}
}