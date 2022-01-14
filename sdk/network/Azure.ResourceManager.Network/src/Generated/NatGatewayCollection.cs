// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Network
{
    /// <summary> A class representing collection of NatGateway and their operations over its parent. </summary>
    public partial class NatGatewayCollection : ArmCollection, IEnumerable<NatGateway>, IAsyncEnumerable<NatGateway>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly NatGatewaysRestOperations _natGatewaysRestClient;

        /// <summary> Initializes a new instance of the <see cref="NatGatewayCollection"/> class for mocking. </summary>
        protected NatGatewayCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="NatGatewayCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal NatGatewayCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _natGatewaysRestClient = new NatGatewaysRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        // Collection level operations.

        /// <summary> Creates or updates a nat gateway. </summary>
        /// <param name="natGatewayName"> The name of the nat gateway. </param>
        /// <param name="parameters"> Parameters supplied to the create or update nat gateway operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="natGatewayName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual NatGatewayCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string natGatewayName, NatGatewayData parameters, CancellationToken cancellationToken = default)
        {
            if (natGatewayName == null)
            {
                throw new ArgumentNullException(nameof(natGatewayName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("NatGatewayCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _natGatewaysRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, natGatewayName, parameters, cancellationToken);
                var operation = new NatGatewayCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _natGatewaysRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, natGatewayName, parameters).Request, response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates or updates a nat gateway. </summary>
        /// <param name="natGatewayName"> The name of the nat gateway. </param>
        /// <param name="parameters"> Parameters supplied to the create or update nat gateway operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="natGatewayName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<NatGatewayCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string natGatewayName, NatGatewayData parameters, CancellationToken cancellationToken = default)
        {
            if (natGatewayName == null)
            {
                throw new ArgumentNullException(nameof(natGatewayName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("NatGatewayCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _natGatewaysRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, natGatewayName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new NatGatewayCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _natGatewaysRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, natGatewayName, parameters).Request, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the specified nat gateway in a specified resource group. </summary>
        /// <param name="natGatewayName"> The name of the nat gateway. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="natGatewayName"/> is null. </exception>
        public virtual Response<NatGateway> Get(string natGatewayName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (natGatewayName == null)
            {
                throw new ArgumentNullException(nameof(natGatewayName));
            }

            using var scope = _clientDiagnostics.CreateScope("NatGatewayCollection.Get");
            scope.Start();
            try
            {
                var response = _natGatewaysRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, natGatewayName, expand, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NatGateway(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the specified nat gateway in a specified resource group. </summary>
        /// <param name="natGatewayName"> The name of the nat gateway. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="natGatewayName"/> is null. </exception>
        public async virtual Task<Response<NatGateway>> GetAsync(string natGatewayName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (natGatewayName == null)
            {
                throw new ArgumentNullException(nameof(natGatewayName));
            }

            using var scope = _clientDiagnostics.CreateScope("NatGatewayCollection.Get");
            scope.Start();
            try
            {
                var response = await _natGatewaysRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, natGatewayName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new NatGateway(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="natGatewayName"> The name of the nat gateway. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="natGatewayName"/> is null. </exception>
        public virtual Response<NatGateway> GetIfExists(string natGatewayName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (natGatewayName == null)
            {
                throw new ArgumentNullException(nameof(natGatewayName));
            }

            using var scope = _clientDiagnostics.CreateScope("NatGatewayCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _natGatewaysRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, natGatewayName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<NatGateway>(null, response.GetRawResponse());
                return Response.FromValue(new NatGateway(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="natGatewayName"> The name of the nat gateway. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="natGatewayName"/> is null. </exception>
        public async virtual Task<Response<NatGateway>> GetIfExistsAsync(string natGatewayName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (natGatewayName == null)
            {
                throw new ArgumentNullException(nameof(natGatewayName));
            }

            using var scope = _clientDiagnostics.CreateScope("NatGatewayCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _natGatewaysRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, natGatewayName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<NatGateway>(null, response.GetRawResponse());
                return Response.FromValue(new NatGateway(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="natGatewayName"> The name of the nat gateway. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="natGatewayName"/> is null. </exception>
        public virtual Response<bool> Exists(string natGatewayName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (natGatewayName == null)
            {
                throw new ArgumentNullException(nameof(natGatewayName));
            }

            using var scope = _clientDiagnostics.CreateScope("NatGatewayCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(natGatewayName, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="natGatewayName"> The name of the nat gateway. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="natGatewayName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string natGatewayName, string expand = null, CancellationToken cancellationToken = default)
        {
            if (natGatewayName == null)
            {
                throw new ArgumentNullException(nameof(natGatewayName));
            }

            using var scope = _clientDiagnostics.CreateScope("NatGatewayCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(natGatewayName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets all nat gateways in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NatGateway" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NatGateway> GetAll(CancellationToken cancellationToken = default)
        {
            Page<NatGateway> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("NatGatewayCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _natGatewaysRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new NatGateway(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<NatGateway> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("NatGatewayCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _natGatewaysRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new NatGateway(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets all nat gateways in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NatGateway" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NatGateway> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<NatGateway>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("NatGatewayCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _natGatewaysRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new NatGateway(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<NatGateway>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("NatGatewayCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _natGatewaysRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new NatGateway(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="NatGateway" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NatGatewayCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(NatGateway.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="NatGateway" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("NatGatewayCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(NatGateway.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<NatGateway> IEnumerable<NatGateway>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<NatGateway> IAsyncEnumerable<NatGateway>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, NatGateway, NatGatewayData> Construct() { }
    }
}
