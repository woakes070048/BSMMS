﻿using System;
using System.Windows.Input;
using BSMMS.Core.Container;
using BSMMS.Core.Context;
using BSMMS.Core.Enum;
using BSMMS.Core.Extension;
using BSMMS.Core.UI.Command;

namespace BSMMS.Core.UI.ViewModel
{
	public class InstagramViewModel : BaseViewModel, IExploreContext
	{
		private string userName, password, keywords, commentString, currentImage;
		private ProcessState processState;
		private bool like, follow, comment, paging;
		private int maxTimeout = 100;
		private int minTimeout = 15;

		/// <summary>
		/// Prevents a default instance of the <see cref="InstagramViewModel"/> class from being created.
		/// </summary>
		private InstagramViewModel() { }

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		public override void Init()
		{
			ThreadDispatcher.Initialize();
			this.StartProcessCommand = this.CoreFactory.CreateContextCommand<StartProcessCommand, IExploreContext>(this);
			this.StopProcessCommand = this.CoreFactory.CreateContextCommand<StopProcessCommand, IProcessStateContext>(this);
		}

		/// <summary>
		/// Gets or sets the name of the user.
		/// </summary>
		/// <value>
		/// The name of the user.
		/// </value>
		public string UserName
		{
			get { return userName; }
			set
			{
				userName = value;
				this.RaisePropertyChanged("UserName");
				this.RaisePropertyChanged("StartCommandEnabled");
				this.RaisePropertyChanged("StopCommandEndabled");
				this.RaisePropertyChanged("StartButtonImage");
				this.RaisePropertyChanged("StopButtonImage");
			}
		}

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>
		/// The password.
		/// </value>
		public string Password
		{
			get { return password; }
			set
			{
				password = value;
				this.RaisePropertyChanged("Password");
				this.RaisePropertyChanged("StartCommandEnabled");
				this.RaisePropertyChanged("StopCommandEndabled");
				this.RaisePropertyChanged("StartButtonImage");
				this.RaisePropertyChanged("StopButtonImage");
			}
		}

		/// <summary>
		/// Gets or sets the keywords.
		/// </summary>
		/// <value>
		/// The keywords.
		/// </value>
		public string Keywords
		{
			get { return keywords; }
			set
			{
				keywords = value;
				this.RaisePropertyChanged("Keywords");
				this.RaisePropertyChanged("StartCommandEnabled");
				this.RaisePropertyChanged("StopCommandEndabled");
				this.RaisePropertyChanged("StartButtonImage");
				this.RaisePropertyChanged("StopButtonImage");
			}
		}

		/// <summary>
		/// Gets or sets the CommentString.
		/// </summary>
		/// <value>
		/// The CommentString.
		/// </value>
		public string CommentString
		{
			get { return commentString; }
			set
			{
				commentString = value;
				this.RaisePropertyChanged("CommentString");
				this.RaisePropertyChanged("CommentBoxEnabled");
				this.RaisePropertyChanged("StartCommandEnabled");
				this.RaisePropertyChanged("StopCommandEndabled");
				this.RaisePropertyChanged("StartButtonImage");
				this.RaisePropertyChanged("StopButtonImage");
			}
		}

		/// <summary>
		/// Gets or sets the current image.
		/// </summary>
		/// <value>
		/// The current image.
		/// </value>
		public string CurrentImage
		{
			get { return this.currentImage; }
			set
			{
				this.currentImage = value;
				this.RaisePropertyChanged("CurrentImage");
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether the strategy should like or not.
		/// </summary>
		/// <value>
		///   <c>true</c> if enabled; otherwise, <c>false</c>.
		/// </value>
		public bool Like
		{
			get { return this.like; }
			set
			{
				this.like = value;
				this.RaisePropertyChanged("Like");
				this.RaisePropertyChanged("StartCommandEnabled");
				this.RaisePropertyChanged("StopCommandEndabled");
				this.RaisePropertyChanged("StartButtonImage");
				this.RaisePropertyChanged("StopButtonImage");
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether the strategy should follow or not.
		/// </summary>
		/// <value>
		///   <c>true</c> if enabled; otherwise, <c>false</c>.
		/// </value>
		public bool Follow
		{
			get { return follow; }
			set
			{
				this.follow = value;
				this.RaisePropertyChanged("Follow");
				this.RaisePropertyChanged("StartCommandEnabled");
				this.RaisePropertyChanged("StopCommandEndabled");
				this.RaisePropertyChanged("StartButtonImage");
				this.RaisePropertyChanged("StopButtonImage");
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether the strategy should comment or not.
		/// </summary>
		/// <value>
		///   <c>true</c> if enabled; otherwise, <c>false</c>.
		/// </value>
		public bool Comment
		{
			get { return comment; }
			set
			{
				this.comment = value;
				this.RaisePropertyChanged("Comment");
				this.RaisePropertyChanged("StartCommandEnabled");
				this.RaisePropertyChanged("StopCommandEndabled");
				this.RaisePropertyChanged("StartButtonImage");
				this.RaisePropertyChanged("StopButtonImage");
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether the stategy should use paging.
		/// </summary>
		/// <value>
		///   <c>true</c> if paging; otherwise, <c>false</c>.
		/// </value>
		public bool Paging
		{
			get { return this.paging; }
			set
			{
				this.paging = value;
				this.RaisePropertyChanged("Paging");
				this.RaisePropertyChanged("StartCommandEnabled");
				this.RaisePropertyChanged("StopCommandEndabled");
				this.RaisePropertyChanged("StartButtonImage");
				this.RaisePropertyChanged("StopButtonImage");
			}
		}

		/// <summary>
		/// Gets a value indicating whether the comment tick box is enabled or not.
		/// </summary>
		/// <value>
		///   <c>true</c> if comment box enabled; otherwise, <c>false</c>.
		/// </value>
		public bool CommentBoxEnabled { get { return !string.IsNullOrEmpty(this.CommentString); } }

		/// <summary>
		/// Gets the timeout range.
		/// </summary>
		/// <value>
		/// The timeout range.
		/// </value>
		public TimeoutRangeContainer TimeoutRange
		{
			get { return new TimeoutRangeContainer(this.MinTimeout, this.MaxTimeout); }
		}

		/// <summary>
		/// Gets or sets the maximum timeout.
		/// </summary>
		/// <value>
		/// The maximum timeout.
		/// </value>
		public int MaxTimeout
		{
			get { return maxTimeout; }
			set
			{
				maxTimeout = value;
				this.RaisePropertyChanged("MaxTimeout");
			}
		}

		/// <summary>
		/// Gets or sets the minimum timeout.
		/// </summary>
		/// <value>
		/// The minimum timeout.
		/// </value>
		public int MinTimeout
		{
			get { return minTimeout; }
			set
			{
				minTimeout = value;
				this.RaisePropertyChanged("MinTimeout");
			}
		}

		/// <summary>
		/// Gets or sets the start process command.
		/// </summary>
		/// <value>
		/// The start process command.
		/// </value>
		public ICommand StartProcessCommand { get; set; }

		/// <summary>
		/// Gets a value indicating whether the start command can execute.
		/// </summary>
		/// <value>
		///   <c>true</c> if this command can start; otherwise, <c>false</c>.
		/// </value>
		public bool StartCommandEnabled { get { return this.StartProcessCommand.CanExecute(null); } }

		/// <summary>
		/// Gets or sets the stop process command.
		/// </summary>
		/// <value>
		/// The stop process command.
		/// </value>
		public ICommand StopProcessCommand { get; set; }

		/// <summary>
		/// Gets the play button image.
		/// </summary>
		/// <value>
		/// The play button image.
		/// </value>
		public string StartButtonImage
		{
			get { return this.StartCommandEnabled ? @"..\Images\play.png" : @"..\Images\play_disabled.png"; }
		}

		/// <summary>
		/// Gets the stop button image.
		/// </summary>
		/// <value>
		/// The stop button image.
		/// </value>
		public string StopButtonImage
		{
			get { return this.StopCommandEndabled ? @"..\Images\stop.png" : @"..\Images\stop_disabled.png"; }
		}

		/// <summary>
		/// Gets the progress header bulb.
		/// </summary>
		/// <value>
		/// The progress header bulb.
		/// </value>
		public string ProgressHeaderBulb
		{
			get { return this.ProcessRunning ? @"..\Images\green_light.png" : @"..\Images\red_light.png"; }
		}

		/// <summary>
		/// Gets or sets the state of the process.
		/// </summary>
		/// <value>
		/// The state of the process.
		/// </value>
		public ProcessState ProcessState
		{
			get { return this.processState; }
			set
			{
				this.processState = value;
				this.RaisePropertyChanged("ProcessState");
				this.RaisePropertyChanged("ProcessStateText");
				this.RaisePropertyChanged("ProcessRunning");
				this.RaisePropertyChanged("ProgressHeaderBulb");
				this.RaisePropertyChanged("StartCommandEnabled");
				this.RaisePropertyChanged("StopCommandEndabled");
				this.RaisePropertyChanged("StartButtonImage");
				this.RaisePropertyChanged("StopButtonImage");

				this.RaisePropertyChanged("UserNameEnabled");
				this.RaisePropertyChanged("PasswordEnabled");
				this.RaisePropertyChanged("KeywordsEnabled");
				this.RaisePropertyChanged("CommentsEnabled");
			}
		}

		/// <summary>
		/// Gets the process state as text.
		/// </summary>
		/// <value>
		/// The process state as text.
		/// </value>
		public string ProcessStateText { get { return this.ProcessState + "."; } }

		/// <summary>
		/// Gets a value indicating whether the progress bar should marquee or not.
		/// </summary>
		/// <value>
		///   <c>true</c> if it should marquee; otherwise, <c>false</c>.
		/// </value>
		public bool ProcessRunning { get { return this.ProcessState == ProcessState.Running; } }

		/// <summary>
		/// Gets a value indicating whether the stop command can execute.
		/// </summary>
		/// <value>
		///   <c>true</c> if this command can start; otherwise, <c>false</c>.
		/// </value>
		public bool StopCommandEndabled { get { return this.StopProcessCommand.CanExecute(null); } }
		public bool UserNameEnabled { get { return !this.ProcessRunning; } }
		public bool PasswordEnabled { get { return !this.ProcessRunning; } }
		public bool KeywordsEnabled { get { return !this.ProcessRunning; } }
		public bool CommentsEnabled { get { return !this.ProcessRunning; } }

		/// <summary>
		/// Updates the current image (thread safe).
		/// </summary>
		/// <param name="imageUrl">The image URL.</param>
		public void UpdateCurrentImage(string imageUrl)
		{
			this.CurrentImage = imageUrl;
		}

		/// <summary>
		/// Handles the exception.
		/// </summary>
		/// <param name="ex">The exeption to handle.</param>
		/// <exception cref="System.NotImplementedException"></exception>
		public void HandleException(Exception ex)
		{
			this.ProcessState = ProcessState.Error;
			this.WindowService.ShowExceptionMessageBox(ex);

			this.RaisePropertyChanged("ProcessState");
			this.RaisePropertyChanged("ProcessStateText");
			this.RaisePropertyChanged("ProcessRunning");
			this.RaisePropertyChanged("ProgressHeaderBulb");
		}

		/// <summary>
		/// Handles the close event.
		/// </summary>
		public void HandleCloseEvent()
		{
			this.ProcessState = ProcessState.Stopped;

			this.RaisePropertyChanged("ProcessState");
			this.RaisePropertyChanged("ProcessStateText");
			this.RaisePropertyChanged("ProcessRunning");
			this.RaisePropertyChanged("ProgressHeaderBulb");
		}
	}
}