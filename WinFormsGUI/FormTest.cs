﻿/*
*    DDOA-DOAXVV-OPEN-ASSISTANT
* 
*     Copyright 2023-2024  Tyler Parret True
* 
*    Licensed under the Apache License, Version 2.0 (the "License");
*    you may not use this file except in compliance with the License.
*    You may obtain a copy of the License at
* 
*        http://www.apache.org/licenses/LICENSE-2.0
* 
*    Unless required by applicable law or agreed to in writing, software
*    distributed under the License is distributed on an "AS IS" BASIS,
*    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
*    See the License for the specific language governing permissions and
*    limitations under the License.
* 
* @Authors
*    Tyler Parret True <mysteryworldgod@outlook.com><https://github.com/OwlHowlinMornSky>
*/
namespace WinFormsGUI {
	/// <summary>
	/// 测试用窗口
	/// </summary>
	public partial class FormTest : Form {

		private readonly UserControlHome home; // 因为编辑器抽风没法加控件所以只能手动用代码加了。

		public FormTest() {
			InitializeComponent();

			home = new UserControlHome {
				MyPopNotification = PopNotification,
				Dock = DockStyle.Fill
			};
			tabPage_home.Controls.Add(home);

			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

			Program.helper.SetShowCaptureOrNot(true);
		}

		private void FormTest_Load(object sender, EventArgs e) {
			notifyIcon_Main.Text = Text;
		}

		/// <summary>
		/// 窗口试图关闭
		/// </summary>
		private void FormTest_FormClosing(object sender, FormClosingEventArgs e) {
			if (Program.helper.IsRunning()) {
				if (e.CloseReason != CloseReason.WindowsShutDown) {
					// 询问是否关闭
					var res = MessageBox.Show(
						Strings.Main.QueryClose,
						Text,
						MessageBoxButtons.OKCancel,
						MessageBoxIcon.Question
					);
					if (res == DialogResult.Cancel) {
						e.Cancel = true;
						return;
					}
				}
				Program.helper.AskForStop();
				while (Program.helper.IsRunning()) {
					Thread.Sleep(100);
				}
			}
			home.OnClosing();
		}

		/// <summary>
		/// 窗口已关闭。
		/// </summary>
		private void FormTest_FormClosed(object sender, FormClosedEventArgs e) {
			Settings.GUI.Default.Save();
			Settings.Core.Default.Save();
			//Settings.Param.Default.Save();
		}

		/// <summary>
		/// 点击托盘图标右键菜单的“退出”项。
		/// </summary>
		private void ToolStripMenuItem_Exit_Click(object sender, EventArgs e) {
			Close();
		}

		/// <summary>
		/// 发送托盘消息。
		/// </summary>
		/// <param name="title">消息标题</param>
		/// <param name="text">消息内容</param>
		/// <param name="icon">消息图标</param>
		private void PopNotification(string title, string text, ToolTipIcon icon) {
			if (Settings.GUI.Default.UseNotify)
				notifyIcon_Main.ShowBalloonTip(
					Settings.Param.Default.NotifyTime,
					title,
					text,
					icon
				);
		}
	}
}
