﻿/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█                                     ▄███████▄
      █   ███                                    ███    ███
      █   ███▌     ██       ▄█████    ▄▄██▄▄▄    ███    ███    █████  ██████   █    █   █  ██████▄     ▄█████    █████
      █   ███▌ ▀███████▄   ██   █   ▄█▀▀██▀▀█▄   ███    ███   ██  ██ ██    ██ ██    ██ ██  ██   ▀██   ██   █    ██  ██
      █   ███▌     ██  ▀  ▄██▄▄     ██  ██  ██ ▀█████████▀   ▄██▄▄█▀ ██    ██ ██    ██ ██▌ ██    ██  ▄██▄▄     ▄██▄▄█▀
      █   ███      ██    ▀▀██▀▀     ██  ██  ██   ███        ▀███████ ██    ██ ██    ██ ██  ██    ██ ▀▀██▀▀    ▀███████
      █   ███      ██      ██   █   ██  ██  ██   ███          ██  ██ ██    ██  █▄  ▄█  ██  ██   ▄██   ██   █    ██  ██
      █   █▀      ▄██▀     ███████   █  ██  █   ▄████▀        ██  ██  ██████    ▀██▀   █   ██████▀    ███████   ██  ██
      █
      █       ███
      █   ▀█████████▄
      █      ▀███▀▀██    ▄█████   ▄█████     ██      ▄█████
      █       ███   ▀   ██   █    ██  ▀  ▀███████▄   ██  ▀
      █       ███      ▄██▄▄      ██         ██  ▀   ██
      █       ███     ▀▀██▀▀    ▀███████     ██    ▀███████
      █       ███       ██   █     ▄  ██     ██       ▄  ██
      █      ▄████▀     ███████  ▄████▀     ▄██▀    ▄████▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Unit tests for the ItemProvider class.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016-2017 JP Dillingham (jp@dillingham.ws)
      █
      █  This program is free software: you can redistribute it and/or modify
      █  it under the terms of the GNU Affero General Public License as published by
      █  the Free Software Foundation, either version 3 of the License, or
      █  (at your option) any later version.
      █
      █  This program is distributed in the hope that it will be useful,
      █  but WITHOUT ANY WARRANTY; without even the implied warranty of
      █  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      █  GNU Affero General Public License for more details.
      █
      █  You should have received a copy of the GNU Affero General Public License
      █  along with this program.  If not, see <http://www.gnu.org/licenses/>.
      █
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                   ██
                                                                                               ▀█▄ ██ ▄█▀
                                                                                                 ▀████▀
                                                                                                   ▀▀                            */

[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]

namespace OpenIIoT.SDK.Tests.Common.Provider.ItemProvider
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Moq;
    using SDK.Common.Provider.ItemProvider;
    using Xunit;

    /// <summary>
    ///     Unit tests for the <see cref="ItemProvider"/> class.
    /// </summary>
    public class ItemProviderTests
    {
        #region Private Fields

        /// <summary>
        ///     The mockup of the <see cref="ItemProvider"/> class.
        /// </summary>
        private Mock<ItemProvider> itemProvider;

        /// <summary>
        ///     The concrete mockup of the <see cref="MockItemProvider"/> class.
        /// </summary>
        private ItemProvider mockProvider;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ItemProviderTests"/> class.
        /// </summary>
        public ItemProviderTests()
        {
            itemProvider = new Mock<ItemProvider>("test");
            itemProvider.CallBase = true;

            mockProvider = new MockItemProvider("mock");
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///     Tests the <see cref="ItemProvider.Browse(SDK.Common.Item)"/> method.
        /// </summary>
        /// <remarks>Depends upon the <see cref="MockItemProvider"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void Browse()
        {
            SDK.Common.Item item = mockProvider.Browse();
            Assert.Equal("Root", item.ToString());
        }

        /// <summary>
        ///     Tests the <see cref="ItemProvider.BrowseAsync(SDK.Common.Item)"/> method.
        /// </summary>
        /// <remarks>Depends upon the <see cref="MockItemProvider"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public async void BrowseAsync()
        {
            SDK.Common.Item item = await mockProvider.BrowseAsync();

            Assert.Equal("Root", item.ToString());
        }

        /// <summary>
        ///     Tests the <see cref="ItemProvider.BrowseAsync(SDK.Common.Item)"/> method.
        /// </summary>
        /// <remarks>Depends upon the <see cref="MockItemProvider"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public async void BrowseAsyncItem()
        {
            SDK.Common.Item searchItem = new SDK.Common.Item();
            IList<SDK.Common.Item> items = await mockProvider.BrowseAsync(searchItem);

            Assert.Empty(items);
        }

        /// <summary>
        ///     Tests the <see cref="ItemProvider.Browse(SDK.Common.Item)"/> method.
        /// </summary>
        /// <remarks>Depends upon the <see cref="MockItemProvider"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void BrowseItem()
        {
            SDK.Common.Item item = new SDK.Common.Item();

            Assert.Empty(mockProvider.Browse(item));
        }

        /// <summary>
        ///     Tests the constructor of <see cref="ItemProvider"/>.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            Assert.IsAssignableFrom<ItemProvider>(itemProvider.Object);
        }

        /// <summary>
        ///     Tests the <see cref="ItemProvider.FindAsync(string)"/> method.
        /// </summary>
        /// <remarks>Depends upon the <see cref="MockItemProvider"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public async void FindAsync()
        {
            SDK.Common.Item item = await mockProvider.FindAsync("test");

            Assert.Null(item);
        }

        /// <summary>
        ///     Tests the <see cref="ItemProvider.Find(string)"/> method with a known good search string.
        /// </summary>
        /// <remarks>Depends upon the <see cref="MockItemProvider"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void FindFound()
        {
            SDK.Common.Item item = mockProvider.Find("Root.Child");

            Assert.Equal("Root.Child", item.ToString());
        }

        /// <summary>
        ///     Tests the <see cref="ItemProvider.Find(string)"/> method with a string that is not expected to be found.
        /// </summary>
        /// <remarks>Depends upon the <see cref="MockItemProvider"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void FindNotFound()
        {
            SDK.Common.Item item = mockProvider.Find("NotFound");

            Assert.Null(item);
        }

        /// <summary>
        ///     Tests the <see cref="ItemProvider.Find(string)"/> method with the search string matching the root Item.
        /// </summary>
        /// <remarks>Depends upon the <see cref="MockItemProvider"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void FindRoot()
        {
            SDK.Common.Item item = mockProvider.Find("Root");

            Assert.NotNull(item);
        }

        /// <summary>
        ///     Tests the <see cref="ItemProvider.ItemProviderName"/> property.
        /// </summary>
        [Fact]
        public void ItemProviderName()
        {
            Assert.Equal("test", itemProvider.Object.ItemProviderName);
        }

        /// <summary>
        ///     Tests the <see cref="ItemProvider.Subscribe(SDK.Common.Item, Action{object})"/> method.
        /// </summary>
        [Fact]
        public void Subscribe()
        {
            SDK.Common.Item item = new SDK.Common.Item("test");

            Action<object> action = (object obj) => { };

            Assert.Empty(itemProvider.Object.Subscriptions);

            bool result = itemProvider.Object.Subscribe(item, action);

            Assert.True(result);
            Assert.Equal(1, itemProvider.Object.Subscriptions.Count);
            Assert.Equal(1, itemProvider.Object.Subscriptions[item].Count);
        }

        /// <summary>
        ///     Tests the <see cref="ItemProvider.Subscribe(SDK.Common.Item, Action{object})"/> method with a duplicate subscription.
        /// </summary>
        [Fact]
        public void SubscribeDuplicateSubscription()
        {
            SDK.Common.Item item = new SDK.Common.Item("test");
            Action<object> action = (object obj) => { };

            Assert.Empty(itemProvider.Object.Subscriptions);

            bool result = itemProvider.Object.Subscribe(item, action);

            Assert.True(result);

            result = itemProvider.Object.Subscribe(item, action);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests the <see cref="ItemProvider.Subscribe(SDK.Common.Item, Action{object})"/> with a second subscription to a
        ///     previously subscribed Item.
        /// </summary>
        [Fact]
        public void SubscribeSecondSubscriber()
        {
            SDK.Common.Item item = new SDK.Common.Item("test");

            Action<object> action1 = (object obj) => { };
            Action<object> action2 = (object obj) => { };

            Assert.Empty(itemProvider.Object.Subscriptions);

            bool result = itemProvider.Object.Subscribe(item, action1);

            Assert.True(result);
            Assert.Equal(1, itemProvider.Object.Subscriptions.Count);

            result = itemProvider.Object.Subscribe(item, action2);

            Assert.True(result);
            Assert.Equal(1, itemProvider.Object.Subscriptions.Count);
            Assert.Equal(2, itemProvider.Object.Subscriptions[item].Count);
        }

        /// <summary>
        ///     Tests the <see cref="ItemProvider.Subscriptions"/> property.
        /// </summary>
        [Fact]
        public void Subscriptions()
        {
            Assert.IsType<Dictionary<SDK.Common.Item, List<Action<object>>>>(itemProvider.Object.Subscriptions);
            Assert.Empty(itemProvider.Object.Subscriptions);
        }

        /// <summary>
        ///     Tests the <see cref="ItemProvider.UnSubscribe(SDK.Common.Item, Action{object})"/> method.
        /// </summary>
        [Fact]
        public void UnSubscribe()
        {
            SDK.Common.Item item = new SDK.Common.Item("test");

            Action<object> action = (object obj) => { };

            itemProvider.Object.Subscribe(item, action);

            Assert.NotEmpty(itemProvider.Object.Subscriptions);

            itemProvider.Object.UnSubscribe(item, action);

            Assert.Empty(itemProvider.Object.Subscriptions);
        }

        /// <summary>
        ///     Tests the <see cref="ItemProvider.UnSubscribe(SDK.Common.Item, Action{object})"/> method with an Item to which
        ///     there are no subscriptions.
        /// </summary>
        [Fact]
        public void UnSubscribeNotSubscribed()
        {
            SDK.Common.Item item = new SDK.Common.Item("test");

            Action<object> action = (object obj) => { };

            itemProvider.Object.UnSubscribe(item, action);

            Assert.Empty(itemProvider.Object.Subscriptions);
        }

        #endregion Public Methods
    }

    /// <summary>
    ///     Mocks an Item Provider.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the abstract nature of the
    ///     <see cref="ItemProvider"/> class and some of its methods.
    /// </remarks>
    public class MockItemProvider : ItemProvider
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MockItemProvider"/> class.
        /// </summary>
        /// <param name="providerName">The name of the Item Provider.</param>
        public MockItemProvider(string providerName)
            : base(providerName)
        {
            ItemRoot = new SDK.Common.Item("Root");
            ItemRoot.AddChild(new SDK.Common.Item("Child"));
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///     Reads and returns the current value of the specified <see cref="Item"/>.
        /// </summary>
        /// <param name="item">The Item to read.</param>
        /// <returns>The value of the specified Item.</returns>
        public override object Read(SDK.Common.Item item)
        {
            return 1;
        }

        /// <summary>
        ///     Asynchronously reads and returns the current value of the specified <see cref="Item"/>
        /// </summary>
        /// <param name="item">The Item to read.</param>
        /// <returns>The value of the specified Item.</returns>
        public override async Task<object> ReadAsync(SDK.Common.Item item)
        {
            return await Task.Run(() => Read(item));
        }

        #endregion Public Methods
    }
}