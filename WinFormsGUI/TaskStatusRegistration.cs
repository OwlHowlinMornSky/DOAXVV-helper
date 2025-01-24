﻿/*
*    DDOA-DOAXVV-OPEN-ASSISTANT
* 
*     Copyright 2023-2025  Tyler Parret True
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
	internal class TaskStatusRegistration {

		internal TaskStatusRegistration() {
			Helper.GUICallbacks.LockTask = LockTask;
			Helper.GUICallbacks.LockStepDaily = LockStepDaily;
			Helper.GUICallbacks.LockStepChallenge = LockStepChallenge;
			Helper.GUICallbacks.Pause = () => { Pause(); };
			Helper.GUICallbacks.Log = (x) => { Log(x); };
		}

		internal Action<Helper.GUICallbacks.LogInfo> Log = x => { };

		internal Action Pause = () => { };

		/// <summary>
		/// 任务状态改变时锁定与解锁GUI的事件。
		/// </summary>
		internal Action OnStartLock = () => { }; // 成功开始任务后，在UI线程锁定UI。
		internal Action<bool> OnLockWork = x => { }; // 任务线程跑起来后，从任务线程，通知UI线程。
		internal bool LockedWork { get; private set; } = false;
		internal void LockTask(bool x) {
			LockedWork = x;
			OnLockWork(x);
		}

		internal Action<bool> OnLockStepDaily = x => { }; // 任务线程跑起来后，从任务线程，通知UI线程。
		internal bool LockedStepDaily { get; private set; } = false;
		internal void LockStepDaily(bool x) {
			LockedStepDaily = x;
			OnLockStepDaily(x);
		}

		internal Action<bool> OnLockStepChallenge = x => { }; // 任务线程跑起来后，从任务线程，通知UI线程。
		internal bool LockedStepChallenge { get; private set; } = false;
		internal void LockStepChallenge(bool x) {
			LockedStepChallenge = x;
			OnLockStepChallenge(x);
		}
	}
}
