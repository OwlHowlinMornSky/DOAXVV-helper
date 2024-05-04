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
#pragma once

#include "API.h"

namespace ohms::Settings {

struct CORE_API Challenge {
	static Challenge DEFAULT; // 本体在 Settings.cpp
	Challenge() :
		PlayNewMatchOrPrevious(false), // 默认上一次比赛
		EnterAddition(true), // 默认进入奖励挑战赛
		CheckAddition(false), // 默认不检查奖励挑战赛
		AutoUseCamFP(false) // 默认不使用拍摄补充FP。
	{}

	bool PlayNewMatchOrPrevious; // 选择新比赛。
	bool EnterAddition; // 进入奖励挑战赛。
	bool CheckAddition; // 是否检查奖励挑战赛。
	bool AutoUseCamFP; // 是否自动使用每日拍摄的补充FP。
};

}
