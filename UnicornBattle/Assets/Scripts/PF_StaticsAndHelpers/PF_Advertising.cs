using System;
using System.Collections.Generic;
using PlayFab.ClientModels;
using PlayFab.Internal;
using PlayFab.Json;
using PlayFab.SharedModels;

public class PF_Advertising {

	

	public static void  GetAdPlacements(GetAdPlacementsRequest request, Action<GetAdPlacementsResult> resultCallback, Action<PlayFab.PlayFabError> errorCallback, object customData = null)
	{
		if (!PlayFabHttp.IsClientLoggedIn()) throw new Exception("Must be logged in to call this method");

		PlayFabHttp.MakeApiCall<GetAdPlacementsResult>("/Client/GetAdPlacements", request, AuthType.LoginSession, resultCallback, errorCallback, customData);
	}

	public static void  ReportAdActivity(ReportAdActivityRequest request, Action<ReportAdActivityResponse> resultCallback, Action<PlayFab.PlayFabError> errorCallback, object customData = null)
	{
		if (!PlayFabHttp.IsClientLoggedIn()) throw new Exception("Must be logged in to call this method");

		PlayFabHttp.MakeApiCall<ReportAdActivityResponse>("/Client/ReportAdActivity", request, AuthType.LoginSession, resultCallback, errorCallback, customData);
	}
}

public class GetAdPlacementsRequest : PlayFabRequestCommon
{
    public NameIdentifier Identifier { get; set; }
    public string AppId { get; set; }
}


public class NameIdentifier 
{
	public string Name { get; set; }
	public string Id { get; set; }

}

public class GetAdPlacementsResult : PlayFabResultCommon
{
    public AdPlacementDetails[] AdPlacements { get; set; }
}

public class AdPlacementDetails
{
    public string PlacementId { get; set; }
    public string PlacementName { get; set; }
    public string RewardId { get; set; }
    public string RewardName { get; set; }
    public string RewardDescription { get; set; }
    public string RewardAssetUrl { get; set; }
    public int? PlacementViewsRemaining { get; set; }
}

public class ReportAdActivityRequest : PlayFabRequestCommon
{
    public string PlacementId { get; set; }
    public string RewardId { get; set; }
}

public class ReportAdActivityResponse : PlayFabResultCommon
{
    public string AdActivityEventId { get; set; }
    public List<string> DebugResults { get; set; }
    public AdRewardResults RewardResults { get; set; }
}

public class AdRewardResults
{
    public List<AdRewardItemGranted> GrantedItems { get; set; }
    public Dictionary<string, int> GrantedVirtualCurrencies { get; set; }
	public Dictionary<string, int> IncrementedStatistics { get; set; }
}

public class AdRewardItemGranted
{
    public string ItemId { get; set; }
    public string CatalogId { get; set; }
    public string DisplayName { get; set; }
}