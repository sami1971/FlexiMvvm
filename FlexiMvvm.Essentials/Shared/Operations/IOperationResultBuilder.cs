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
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FlexiMvvm.Operations
{
    public interface IOperationResultBuilder<out TResult>
    {
        [NotNull]
        IOperationResultBuilder<TResult> OnSuccess([NotNull] Action<TResult> handler);

        [NotNull]
        IOperationResultBuilder<TResult> OnSuccessAsync([NotNull] Func<TResult, CancellationToken, Task> handler);

        [NotNull]
        IOperationResultBuilder<TResult> OnError<TException>([NotNull] Action<OperationError> handler)
            where TException : Exception;

        [NotNull]
        IOperationResultBuilder<TResult> OnErrorAsync<TException>([NotNull] Func<OperationError, CancellationToken, Task> handler)
            where TException : Exception;

        [NotNull]
        IOperationResultBuilder<TResult> OnCancel([NotNull] Action handler);

        [NotNull]
        IOperationResultBuilder<TResult> OnCancelAsync([NotNull] Func<CancellationToken, Task> handler);

        [NotNull]
        Task ExecuteAsync(CancellationToken cancellationToken = default);
    }
}
