﻿using System;
using System.Reactive.Disposables;

namespace PiTop
{
    public abstract class PiTopPlate : IDisposable
    {
        public PiTopModule Module { get; }
        protected PiTopPlate(PiTopModule module)
        {
            Module = module ?? throw new ArgumentNullException(nameof(module));
        }

        private readonly CompositeDisposable _disposables = new CompositeDisposable();
        public void Dispose()
        {
            OnDispose(true);
            _disposables.Dispose();
        }

        protected void RegisterForDisposal(IDisposable disposable)
        {
            if (disposable == null) throw new ArgumentNullException(nameof(disposable));
            _disposables.Add(disposable);
        }

        protected internal void RegisterForDisposal(Action dispose)
        {
            if (dispose == null) throw new ArgumentNullException(nameof(dispose));
            _disposables.Add(Disposable.Create(dispose));
        }

        protected virtual void OnDispose(bool isDisposing)
        {
        }
    }
}