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
using FlexiMvvm.Bindings;
using FlexiMvvm.ViewModels;
using JetBrains.Annotations;

namespace FlexiMvvm.Views.Core
{
    public class BindableViewDelegate<TView, TViewModel> : ViewDelegate<TView, TViewModel>
        where TView : class, IBindableAndroidView<TViewModel>
        where TViewModel : class, IViewModelWithState
    {
        [CanBeNull]
        private BindingSet<TViewModel> _bindingSet;

        public BindableViewDelegate([NotNull] TView view)
            : base(view)
        {
        }

        public override void OnStart()
        {
            base.OnStart();

            if (_bindingSet == null)
            {
                _bindingSet = new BindingSet<TViewModel>(ViewModel);
                View.Bind(_bindingSet);
                _bindingSet.Apply();
            }
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();

            _bindingSet = null;
        }
    }
}
