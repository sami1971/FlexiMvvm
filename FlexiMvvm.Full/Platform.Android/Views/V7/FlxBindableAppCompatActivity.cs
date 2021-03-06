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

using FlexiMvvm.Bindings;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views.Core;

namespace FlexiMvvm.Views.V7
{
    public class FlxBindableAppCompatActivity<TViewModel>
        : FlxAppCompatActivity<TViewModel>, IBindableAndroidView<TViewModel>
        where TViewModel : class, IViewModelWithoutParameters, IViewModelWithState
    {
        protected override IViewDelegate<FlxAppCompatActivity> CreateViewDelegate()
        {
            return new BindableViewDelegate<FlxBindableAppCompatActivity<TViewModel>, TViewModel>(this);
        }

        public virtual void Bind(BindingSet<TViewModel> bindingSet)
        {
        }
    }

    public class FlxBindableAppCompatActivity<TViewModel, TParameters>
        : FlxAppCompatActivity<TViewModel, TParameters>, IBindableAndroidView<TViewModel>
        where TViewModel : class, IViewModelWithParameters<TParameters>, IViewModelWithState
        where TParameters : ViewModelParametersBase
    {
        protected override IViewDelegate<FlxAppCompatActivity> CreateViewDelegate()
        {
            return new BindableViewDelegate<FlxBindableAppCompatActivity<TViewModel, TParameters>, TViewModel>(this);
        }

        public virtual void Bind(BindingSet<TViewModel> bindingSet)
        {
        }
    }
}
