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
    /// <summary> A class representing collection of SecurityPartnerProvider and their operations over its parent. </summary>
    public partial class SecurityPartnerProviderCollection : ArmCollection, IEnumerable<SecurityPartnerProvider>, IAsyncEnumerable<SecurityPartnerProvider>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly SecurityPartnerProvidersRestOperations _securityPartnerProvidersRestClient;

        /// <summary> Initializes a new instance of the <see cref="SecurityPartnerProviderCollection"/> class for mocking. </summary>
        protected SecurityPartnerProviderCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SecurityPartnerProviderCollection"/> class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal SecurityPartnerProviderCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _securityPartnerProvidersRestClient = new SecurityPartnerProvidersRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
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

        /// <summary> Creates or updates the specified Security Partner Provider. </summary>
        /// <param name="securityPartnerProviderName"> The name of the Security Partner Provider. </param>
        /// <param name="parameters"> Parameters supplied to the create or update Security Partner Provider operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="securityPartnerProviderName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual SecurityPartnerProviderCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string securityPartnerProviderName, SecurityPartnerProviderData parameters, CancellationToken cancellationToken = default)
        {
            if (securityPartnerProviderName == null)
            {
                throw new ArgumentNullException(nameof(securityPartnerProviderName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("SecurityPartnerProviderCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _securityPartnerProvidersRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, securityPartnerProviderName, parameters, cancellationToken);
                var operation = new SecurityPartnerProviderCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _securityPartnerProvidersRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, securityPartnerProviderName, parameters).Request, response);
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

        /// <summary> Creates or updates the specified Security Partner Provider. </summary>
        /// <param name="securityPartnerProviderName"> The name of the Security Partner Provider. </param>
        /// <param name="parameters"> Parameters supplied to the create or update Security Partner Provider operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="securityPartnerProviderName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<SecurityPartnerProviderCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string securityPartnerProviderName, SecurityPartnerProviderData parameters, CancellationToken cancellationToken = default)
        {
            if (securityPartnerProviderName == null)
            {
                throw new ArgumentNullException(nameof(securityPartnerProviderName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("SecurityPartnerProviderCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _securityPartnerProvidersRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, securityPartnerProviderName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SecurityPartnerProviderCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _securityPartnerProvidersRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, securityPartnerProviderName, parameters).Request, response);
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

        /// <summary> Gets the specified Security Partner Provider. </summary>
        /// <param name="securityPartnerProviderName"> The name of the Security Partner Provider. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="securityPartnerProviderName"/> is null. </exception>
        public virtual Response<SecurityPartnerProvider> Get(string securityPartnerProviderName, CancellationToken cancellationToken = default)
        {
            if (securityPartnerProviderName == null)
            {
                throw new ArgumentNullException(nameof(securityPartnerProviderName));
            }

            using var scope = _clientDiagnostics.CreateScope("SecurityPartnerProviderCollection.Get");
            scope.Start();
            try
            {
                var response = _securityPartnerProvidersRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, securityPartnerProviderName, cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SecurityPartnerProvider(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the specified Security Partner Provider. </summary>
        /// <param name="securityPartnerProviderName"> The name of the Security Partner Provider. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="securityPartnerProviderName"/> is null. </exception>
        public async virtual Task<Response<SecurityPartnerProvider>> GetAsync(string securityPartnerProviderName, CancellationToken cancellationToken = default)
        {
            if (securityPartnerProviderName == null)
            {
                throw new ArgumentNullException(nameof(securityPartnerProviderName));
            }

            using var scope = _clientDiagnostics.CreateScope("SecurityPartnerProviderCollection.Get");
            scope.Start();
            try
            {
                var response = await _securityPartnerProvidersRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, securityPartnerProviderName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SecurityPartnerProvider(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="securityPartnerProviderName"> The name of the Security Partner Provider. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="securityPartnerProviderName"/> is null. </exception>
        public virtual Response<SecurityPartnerProvider> GetIfExists(string securityPartnerProviderName, CancellationToken cancellationToken = default)
        {
            if (securityPartnerProviderName == null)
            {
                throw new ArgumentNullException(nameof(securityPartnerProviderName));
            }

            using var scope = _clientDiagnostics.CreateScope("SecurityPartnerProviderCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _securityPartnerProvidersRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, securityPartnerProviderName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SecurityPartnerProvider>(null, response.GetRawResponse());
                return Response.FromValue(new SecurityPartnerProvider(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="securityPartnerProviderName"> The name of the Security Partner Provider. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="securityPartnerProviderName"/> is null. </exception>
        public async virtual Task<Response<SecurityPartnerProvider>> GetIfExistsAsync(string securityPartnerProviderName, CancellationToken cancellationToken = default)
        {
            if (securityPartnerProviderName == null)
            {
                throw new ArgumentNullException(nameof(securityPartnerProviderName));
            }

            using var scope = _clientDiagnostics.CreateScope("SecurityPartnerProviderCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _securityPartnerProvidersRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, securityPartnerProviderName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SecurityPartnerProvider>(null, response.GetRawResponse());
                return Response.FromValue(new SecurityPartnerProvider(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="securityPartnerProviderName"> The name of the Security Partner Provider. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="securityPartnerProviderName"/> is null. </exception>
        public virtual Response<bool> Exists(string securityPartnerProviderName, CancellationToken cancellationToken = default)
        {
            if (securityPartnerProviderName == null)
            {
                throw new ArgumentNullException(nameof(securityPartnerProviderName));
            }

            using var scope = _clientDiagnostics.CreateScope("SecurityPartnerProviderCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(securityPartnerProviderName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="securityPartnerProviderName"> The name of the Security Partner Provider. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="securityPartnerProviderName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string securityPartnerProviderName, CancellationToken cancellationToken = default)
        {
            if (securityPartnerProviderName == null)
            {
                throw new ArgumentNullException(nameof(securityPartnerProviderName));
            }

            using var scope = _clientDiagnostics.CreateScope("SecurityPartnerProviderCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(securityPartnerProviderName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all Security Partner Providers in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SecurityPartnerProvider" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SecurityPartnerProvider> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SecurityPartnerProvider> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SecurityPartnerProviderCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _securityPartnerProvidersRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityPartnerProvider(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SecurityPartnerProvider> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SecurityPartnerProviderCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _securityPartnerProvidersRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityPartnerProvider(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists all Security Partner Providers in a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SecurityPartnerProvider" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SecurityPartnerProvider> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SecurityPartnerProvider>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SecurityPartnerProviderCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _securityPartnerProvidersRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityPartnerProvider(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SecurityPartnerProvider>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("SecurityPartnerProviderCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _securityPartnerProvidersRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityPartnerProvider(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="SecurityPartnerProvider" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SecurityPartnerProviderCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SecurityPartnerProvider.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="SecurityPartnerProvider" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SecurityPartnerProviderCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SecurityPartnerProvider.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SecurityPartnerProvider> IEnumerable<SecurityPartnerProvider>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SecurityPartnerProvider> IAsyncEnumerable<SecurityPartnerProvider>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        // Builders.
        // public ArmBuilder<Azure.Core.ResourceIdentifier, SecurityPartnerProvider, SecurityPartnerProviderData> Construct() { }
    }
}
