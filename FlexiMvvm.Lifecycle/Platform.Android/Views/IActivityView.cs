﻿// =========================================================================
// Copyright 2018 EPAM Systems, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// =========================================================================

using Android.App;
using Android.Content;
using FlexiMvvm.ViewModels;
using JetBrains.Annotations;

namespace FlexiMvvm.Views
{
    public interface IActivityView : IAndroidView
    {
        void Finish();
    }

    public interface IActivityView<out TViewModel> : IActivityView, IAndroidView<TViewModel>
        where TViewModel : class, IViewModel
    {
        void SetResult(Result resultCode);

        void SetResult(Result resultCode, [CanBeNull] Intent data);
    }
}
