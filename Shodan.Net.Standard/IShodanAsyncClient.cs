﻿using Shodan.Net.Models;
using Shodan.Net.Models.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shodan.Net
{
    internal interface IShodanAsyncClient
    {
        /// <summary>
        /// Returns all services that have been found on the given host IP.
        /// </summary>
        /// <param name="Ip">Host IP address</param>
        /// <param name="history">True if all historical banners should be returned (default: False) </param>
        /// <param name="minify">True to only return the list of ports and the general host information, no banners. (default: False) </param>
        /// <returns></returns>
        Task<Host> GetHostAsync(string Ip, bool history = false, bool minify = false);

        /// <summary>
        /// This method returns a list of port numbers that the crawlers are looking for.
        /// </summary>
        /// <returns></returns>
        Task<List<int>> GetPortsAsync();

        /// <summary>
        /// This method returns an object containing all the protocols that can be used when launching an Internet scan.
        /// </summary>
        /// <returns></returns>
        Task<Dictionary<string, string>> GetProtocolsAsync();

        /// <summary>
        /// Use this method to request Shodan to crawl a network
        /// <strong>Requirements:</strong> This method uses API scan credits: 1 IP consumes 1 scan credit. You must have a paid API plan (either one-time payment or subscription) in order to use this method
        /// </summary>
        /// <returns></returns>
        Task<ScanResult> RequstScanAsync(string ips);

        /// <summary>
        ///
        /// </summary>
        /// <param name="port"> The port that Shodan should crawl the Internet for. </param>
        /// <param name="protocol">The name of the protocol that should be used to interrogate the port. See /shodan/protocols for a list of supported protocols. </param>
        /// <returns></returns>
        Task<ScanPortResult> RequestInternetPortScanAsync(int port, string protocol);

        /// <summary>
        /// Check the progress of a previously submitted scan request
        /// </summary>
        /// <param name="id">the unique scan ID that was returned by /shodan/scan</param>
        /// <returns></returns>
        Task<ScanStatus> GetScanStatusAsync(string id);

        /// <summary>
        /// This method returns an object containing all the services that the Shodan crawlers look at. It can also be used as a quick and practical way to resolve a port number to the name of a service
        /// </summary>
        /// <returns></returns>
        Task<Dictionary<string, string>> GetServicesAsync();

        /// <summary>
        /// Use this method to obtain a list of search queries that users have saved in Shodan.
        /// </summary>
        /// <param name="page"> Page number to iterate over results; each page contains 10 items </param>
        /// <param name="options"> Sort the list based on a property. Possible values are: votes, timestamp </param>
        /// <param name="order">Whether to sort the list in ascending or descending order. Possible values are: asc, desc </param>
        /// <returns></returns>
        Task<SearchQueries> GetQueriesAsync(int? page = null, SortOptions? options = null, OrderOption? order = null);

        /// <summary>
        ///  Use this method to search the directory of search queries that users have saved in Shodan.
        /// </summary>
        /// <param name="query"> What to search for in the directory of saved search queries. </param>
        /// <param name="page">Page number to iterate over results; each page contains 10 items </param>
        /// <returns></returns>
        Task<SearchQueries> SearchQueriesAsync(string query, int? page = null);

        /// <summary>
        /// Use this method to obtain a list of popular tags for the saved search queries in Shodan.
        /// </summary>
        /// <param name="size">The number of tags to return </param>
        /// <returns></returns>
        Task<TagResult> GetTagsAsync(int size = 10);

        /// <summary>
        /// Returns information about the Shodan account linked to this API key.
        /// </summary>
        /// <returns></returns>
        Task<Profile> GetProfileAsync();

        /// <summary>
        /// Look up the IP address for the provided list of hostnames.
        /// </summary>
        /// <param name="hostnames">Comma-separated list of hostnames; example "google.com,bing.com" </param>
        /// <returns></returns>
        Task<Dictionary<string, string>> DnsLookupAsync(List<string> hostnames);

        /// <summary>
        /// Look up the hostnames that have been defined for the given list of IP addresses
        /// </summary>
        /// <param name="ips">Comma-separated list of IP addresses; example "74.125.227.230,204.79.197.200"</param>
        /// <returns></returns>
        Task<Dictionary<string, List<string>>> ReverseLookupAsync(string ips);

        /// <summary>
        /// Get your current IP address as seen from the Internet.
        /// </summary>
        /// <returns></returns>
        Task<string> GetMyIpAsync();

        /// <summary>
        /// Returns information about the API plan belonging to the given API key.
        /// </summary>
        /// <returns></returns>
        Task<ApiStatus> GetApiStatusAsync();

        /// <summary>
        /// Calculates a honeypot probability score rangin from 0 (not a honeypot) to 1.0 (is a honeypot).
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        Task<double> Experimental_GetHoneyPotScoreAsync(string ip);
    }
}