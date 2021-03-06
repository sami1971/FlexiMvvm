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

using System;
using FlexiMvvm.ViewModels;
using JetBrains.Annotations;

namespace FlexiMvvm.Views
{
    public interface IIosView
    {
        bool HandleKeyboard { get; }

        [CanBeNull]
        KeyboardHandler KeyboardHandler { get; }

        bool IsBeingPresented { get; }

        void DismissViewController(bool animated, [CanBeNull] Action completionHandler);
    }

    public interface IIosView<out TViewModel> : IIosView, IView<TViewModel>
        where TViewModel : class, IViewModel
    {
        event EventHandler<ViewModelResultSetEventArgs> ResultSet;

        void SetResult(ViewModelResultCode resultCode, [CanBeNull] ViewModelResultBase result);

        void RaiseResultSet([NotNull] ViewModelResultSetEventArgs args);

        void HandleResult([NotNull] object sender, [NotNull] ViewModelResultSetEventArgs args);
    }
}
