// --------------------------------------------------------------------------
// <copyright file="ProjectInstaller.Designer.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Jason.Ly" date="2014.5.26">Created</change>
// </history>

namespace Fanex.NAP.SMALossEmail.Service
{
    /// <summary>
    /// Project installer.
    /// </summary>
    public partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer _components = null;

        private System.ServiceProcess.ServiceProcessInstaller _serviceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller _serviceInstaller;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">True if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (_components != null))
            {
                _components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._serviceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this._serviceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // _serviceProcessInstaller
            // 
            this._serviceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this._serviceProcessInstaller.Password = null;
            this._serviceProcessInstaller.Username = null;
            // 
            // _serviceInstaller
            // 
            this._serviceInstaller.Description = "NAP CM - SMA Loss Email Notification";
            this._serviceInstaller.DisplayName = "SMA Loss Email Notification";
            this._serviceInstaller.ServiceName = "EmailNotification";
            this._serviceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this._serviceProcessInstaller,
            this._serviceInstaller});

        }

        #endregion
    }
}