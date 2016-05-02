﻿using System.Diagnostics;
using InstaFollow.Core.Context;

namespace InstaFollow.Core.UI.Command
{
	public class GetKeyFromWebPageCommand : BaseContextCommand<IVerifyContext>
	{
		private string licenseGetFromWebLink = @"http://activation.branova.de?machinekey={0}";

		public override void Execute(object obj)
		{
			var link = string.Format(this.licenseGetFromWebLink, this.CurrentContext.MachineKey);
			Process.Start(new ProcessStartInfo(link));
		}

		protected internal override bool EvaluateCanExecute()
		{
			return !string.IsNullOrEmpty(this.CurrentContext.MachineKey);
		}
	}
}