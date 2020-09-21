using PlayFab.SharedModels;
using PlayFab.Internal;

namespace PlayFab.Events {
  public partial class PlayFabEvents {
    public delegate void PlayFabErrorEvent(PlayFabRequestCommon request, PlayFabError error);

    public delegate void PlayFabResultEvent<in TResult>(TResult result) where TResult : PlayFabResultCommon;

    public delegate void PlayFabRequestEvent<in TRequest>(TRequest request) where TRequest : PlayFabRequestCommon;

    public event PlayFabErrorEvent OnGlobalErrorEvent;

    private static PlayFabEvents _instance;

    /// <summary>
    /// Private constructor because we call PlayFabEvents.init();
    /// </summary>
    private PlayFabEvents() { }

    public static PlayFabEvents Init() {
      if (_instance == null) _instance = new PlayFabEvents();
      PlayFabHttp.ApiProcessingEventHandler += _instance.OnProcessingEvent;
      PlayFabHttp.ApiProcessingErrorEventHandler += _instance.OnProcessingErrorEvent;
      return _instance;
    }

    public void UnregisterInstance(object instance) {
#if !DISABLE_PLAYFABCLIENT_API
      if (OnLoginResultEvent != null)
        foreach (var each in OnLoginResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLoginResultEvent -= (PlayFabResultEvent<ClientModels.LoginResult>) each;
#endif
#if ENABLE_PLAYFABADMIN_API
            if (OnAdminAbortTaskInstanceRequestEvent != null) { foreach (var each in OnAdminAbortTaskInstanceRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminAbortTaskInstanceRequestEvent
 -= (PlayFabRequestEvent<AdminModels.AbortTaskInstanceRequest>)each; } } }
            if (OnAdminAbortTaskInstanceResultEvent != null) { foreach (var each in OnAdminAbortTaskInstanceResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminAbortTaskInstanceResultEvent
 -= (PlayFabResultEvent<AdminModels.EmptyResponse>)each; } } }

            if (OnAdminAddLocalizedNewsRequestEvent != null) { foreach (var each in OnAdminAddLocalizedNewsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminAddLocalizedNewsRequestEvent
 -= (PlayFabRequestEvent<AdminModels.AddLocalizedNewsRequest>)each; } } }
            if (OnAdminAddLocalizedNewsResultEvent != null) { foreach (var each in OnAdminAddLocalizedNewsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminAddLocalizedNewsResultEvent
 -= (PlayFabResultEvent<AdminModels.AddLocalizedNewsResult>)each; } } }

            if (OnAdminAddNewsRequestEvent != null) { foreach (var each in OnAdminAddNewsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminAddNewsRequestEvent
 -= (PlayFabRequestEvent<AdminModels.AddNewsRequest>)each; } } }
            if (OnAdminAddNewsResultEvent != null) { foreach (var each in OnAdminAddNewsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminAddNewsResultEvent
 -= (PlayFabResultEvent<AdminModels.AddNewsResult>)each; } } }

            if (OnAdminAddPlayerTagRequestEvent != null) { foreach (var each in OnAdminAddPlayerTagRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminAddPlayerTagRequestEvent
 -= (PlayFabRequestEvent<AdminModels.AddPlayerTagRequest>)each; } } }
            if (OnAdminAddPlayerTagResultEvent != null) { foreach (var each in OnAdminAddPlayerTagResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminAddPlayerTagResultEvent
 -= (PlayFabResultEvent<AdminModels.AddPlayerTagResult>)each; } } }

            if (OnAdminAddServerBuildRequestEvent != null) { foreach (var each in OnAdminAddServerBuildRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminAddServerBuildRequestEvent
 -= (PlayFabRequestEvent<AdminModels.AddServerBuildRequest>)each; } } }
            if (OnAdminAddServerBuildResultEvent != null) { foreach (var each in OnAdminAddServerBuildResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminAddServerBuildResultEvent
 -= (PlayFabResultEvent<AdminModels.AddServerBuildResult>)each; } } }

            if (OnAdminAddUserVirtualCurrencyRequestEvent != null) { foreach (var each in OnAdminAddUserVirtualCurrencyRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminAddUserVirtualCurrencyRequestEvent
 -= (PlayFabRequestEvent<AdminModels.AddUserVirtualCurrencyRequest>)each; } } }
            if (OnAdminAddUserVirtualCurrencyResultEvent != null) { foreach (var each in OnAdminAddUserVirtualCurrencyResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminAddUserVirtualCurrencyResultEvent
 -= (PlayFabResultEvent<AdminModels.ModifyUserVirtualCurrencyResult>)each; } } }

            if (OnAdminAddVirtualCurrencyTypesRequestEvent != null) { foreach (var each in OnAdminAddVirtualCurrencyTypesRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminAddVirtualCurrencyTypesRequestEvent
 -= (PlayFabRequestEvent<AdminModels.AddVirtualCurrencyTypesRequest>)each; } } }
            if (OnAdminAddVirtualCurrencyTypesResultEvent != null) { foreach (var each in OnAdminAddVirtualCurrencyTypesResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminAddVirtualCurrencyTypesResultEvent
 -= (PlayFabResultEvent<AdminModels.BlankResult>)each; } } }

            if (OnAdminBanUsersRequestEvent != null) { foreach (var each in OnAdminBanUsersRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminBanUsersRequestEvent
 -= (PlayFabRequestEvent<AdminModels.BanUsersRequest>)each; } } }
            if (OnAdminBanUsersResultEvent != null) { foreach (var each in OnAdminBanUsersResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminBanUsersResultEvent
 -= (PlayFabResultEvent<AdminModels.BanUsersResult>)each; } } }

            if (OnAdminCheckLimitedEditionItemAvailabilityRequestEvent != null) { foreach (var each in OnAdminCheckLimitedEditionItemAvailabilityRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminCheckLimitedEditionItemAvailabilityRequestEvent
 -= (PlayFabRequestEvent<AdminModels.CheckLimitedEditionItemAvailabilityRequest>)each; } } }
            if (OnAdminCheckLimitedEditionItemAvailabilityResultEvent != null) { foreach (var each in OnAdminCheckLimitedEditionItemAvailabilityResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminCheckLimitedEditionItemAvailabilityResultEvent
 -= (PlayFabResultEvent<AdminModels.CheckLimitedEditionItemAvailabilityResult>)each; } } }

            if (OnAdminCreateActionsOnPlayersInSegmentTaskRequestEvent != null) { foreach (var each in OnAdminCreateActionsOnPlayersInSegmentTaskRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminCreateActionsOnPlayersInSegmentTaskRequestEvent
 -= (PlayFabRequestEvent<AdminModels.CreateActionsOnPlayerSegmentTaskRequest>)each; } } }
            if (OnAdminCreateActionsOnPlayersInSegmentTaskResultEvent != null) { foreach (var each in OnAdminCreateActionsOnPlayersInSegmentTaskResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminCreateActionsOnPlayersInSegmentTaskResultEvent
 -= (PlayFabResultEvent<AdminModels.CreateTaskResult>)each; } } }

            if (OnAdminCreateCloudScriptTaskRequestEvent != null) { foreach (var each in OnAdminCreateCloudScriptTaskRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminCreateCloudScriptTaskRequestEvent
 -= (PlayFabRequestEvent<AdminModels.CreateCloudScriptTaskRequest>)each; } } }
            if (OnAdminCreateCloudScriptTaskResultEvent != null) { foreach (var each in OnAdminCreateCloudScriptTaskResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminCreateCloudScriptTaskResultEvent
 -= (PlayFabResultEvent<AdminModels.CreateTaskResult>)each; } } }

            if (OnAdminCreateInsightsScheduledScalingTaskRequestEvent != null) { foreach (var each in OnAdminCreateInsightsScheduledScalingTaskRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminCreateInsightsScheduledScalingTaskRequestEvent
 -= (PlayFabRequestEvent<AdminModels.CreateInsightsScheduledScalingTaskRequest>)each; } } }
            if (OnAdminCreateInsightsScheduledScalingTaskResultEvent != null) { foreach (var each in OnAdminCreateInsightsScheduledScalingTaskResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminCreateInsightsScheduledScalingTaskResultEvent
 -= (PlayFabResultEvent<AdminModels.CreateTaskResult>)each; } } }

            if (OnAdminCreateOpenIdConnectionRequestEvent != null) { foreach (var each in OnAdminCreateOpenIdConnectionRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminCreateOpenIdConnectionRequestEvent
 -= (PlayFabRequestEvent<AdminModels.CreateOpenIdConnectionRequest>)each; } } }
            if (OnAdminCreateOpenIdConnectionResultEvent != null) { foreach (var each in OnAdminCreateOpenIdConnectionResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminCreateOpenIdConnectionResultEvent
 -= (PlayFabResultEvent<AdminModels.EmptyResponse>)each; } } }

            if (OnAdminCreatePlayerSharedSecretRequestEvent != null) { foreach (var each in OnAdminCreatePlayerSharedSecretRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminCreatePlayerSharedSecretRequestEvent
 -= (PlayFabRequestEvent<AdminModels.CreatePlayerSharedSecretRequest>)each; } } }
            if (OnAdminCreatePlayerSharedSecretResultEvent != null) { foreach (var each in OnAdminCreatePlayerSharedSecretResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminCreatePlayerSharedSecretResultEvent
 -= (PlayFabResultEvent<AdminModels.CreatePlayerSharedSecretResult>)each; } } }

            if (OnAdminCreatePlayerStatisticDefinitionRequestEvent != null) { foreach (var each in OnAdminCreatePlayerStatisticDefinitionRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminCreatePlayerStatisticDefinitionRequestEvent
 -= (PlayFabRequestEvent<AdminModels.CreatePlayerStatisticDefinitionRequest>)each; } } }
            if (OnAdminCreatePlayerStatisticDefinitionResultEvent != null) { foreach (var each in OnAdminCreatePlayerStatisticDefinitionResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminCreatePlayerStatisticDefinitionResultEvent
 -= (PlayFabResultEvent<AdminModels.CreatePlayerStatisticDefinitionResult>)each; } } }

            if (OnAdminDeleteContentRequestEvent != null) { foreach (var each in OnAdminDeleteContentRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminDeleteContentRequestEvent
 -= (PlayFabRequestEvent<AdminModels.DeleteContentRequest>)each; } } }
            if (OnAdminDeleteContentResultEvent != null) { foreach (var each in OnAdminDeleteContentResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminDeleteContentResultEvent
 -= (PlayFabResultEvent<AdminModels.BlankResult>)each; } } }

            if (OnAdminDeleteMasterPlayerAccountRequestEvent != null) { foreach (var each in OnAdminDeleteMasterPlayerAccountRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminDeleteMasterPlayerAccountRequestEvent
 -= (PlayFabRequestEvent<AdminModels.DeleteMasterPlayerAccountRequest>)each; } } }
            if (OnAdminDeleteMasterPlayerAccountResultEvent != null) { foreach (var each in OnAdminDeleteMasterPlayerAccountResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminDeleteMasterPlayerAccountResultEvent
 -= (PlayFabResultEvent<AdminModels.DeleteMasterPlayerAccountResult>)each; } } }

            if (OnAdminDeleteOpenIdConnectionRequestEvent != null) { foreach (var each in OnAdminDeleteOpenIdConnectionRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminDeleteOpenIdConnectionRequestEvent
 -= (PlayFabRequestEvent<AdminModels.DeleteOpenIdConnectionRequest>)each; } } }
            if (OnAdminDeleteOpenIdConnectionResultEvent != null) { foreach (var each in OnAdminDeleteOpenIdConnectionResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminDeleteOpenIdConnectionResultEvent
 -= (PlayFabResultEvent<AdminModels.EmptyResponse>)each; } } }

            if (OnAdminDeletePlayerRequestEvent != null) { foreach (var each in OnAdminDeletePlayerRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminDeletePlayerRequestEvent
 -= (PlayFabRequestEvent<AdminModels.DeletePlayerRequest>)each; } } }
            if (OnAdminDeletePlayerResultEvent != null) { foreach (var each in OnAdminDeletePlayerResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminDeletePlayerResultEvent
 -= (PlayFabResultEvent<AdminModels.DeletePlayerResult>)each; } } }

            if (OnAdminDeletePlayerSharedSecretRequestEvent != null) { foreach (var each in OnAdminDeletePlayerSharedSecretRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminDeletePlayerSharedSecretRequestEvent
 -= (PlayFabRequestEvent<AdminModels.DeletePlayerSharedSecretRequest>)each; } } }
            if (OnAdminDeletePlayerSharedSecretResultEvent != null) { foreach (var each in OnAdminDeletePlayerSharedSecretResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminDeletePlayerSharedSecretResultEvent
 -= (PlayFabResultEvent<AdminModels.DeletePlayerSharedSecretResult>)each; } } }

            if (OnAdminDeleteStoreRequestEvent != null) { foreach (var each in OnAdminDeleteStoreRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminDeleteStoreRequestEvent
 -= (PlayFabRequestEvent<AdminModels.DeleteStoreRequest>)each; } } }
            if (OnAdminDeleteStoreResultEvent != null) { foreach (var each in OnAdminDeleteStoreResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminDeleteStoreResultEvent
 -= (PlayFabResultEvent<AdminModels.DeleteStoreResult>)each; } } }

            if (OnAdminDeleteTaskRequestEvent != null) { foreach (var each in OnAdminDeleteTaskRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminDeleteTaskRequestEvent
 -= (PlayFabRequestEvent<AdminModels.DeleteTaskRequest>)each; } } }
            if (OnAdminDeleteTaskResultEvent != null) { foreach (var each in OnAdminDeleteTaskResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminDeleteTaskResultEvent
 -= (PlayFabResultEvent<AdminModels.EmptyResponse>)each; } } }

            if (OnAdminDeleteTitleRequestEvent != null) { foreach (var each in OnAdminDeleteTitleRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminDeleteTitleRequestEvent
 -= (PlayFabRequestEvent<AdminModels.DeleteTitleRequest>)each; } } }
            if (OnAdminDeleteTitleResultEvent != null) { foreach (var each in OnAdminDeleteTitleResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminDeleteTitleResultEvent
 -= (PlayFabResultEvent<AdminModels.DeleteTitleResult>)each; } } }

            if (OnAdminExportMasterPlayerDataRequestEvent != null) { foreach (var each in OnAdminExportMasterPlayerDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminExportMasterPlayerDataRequestEvent
 -= (PlayFabRequestEvent<AdminModels.ExportMasterPlayerDataRequest>)each; } } }
            if (OnAdminExportMasterPlayerDataResultEvent != null) { foreach (var each in OnAdminExportMasterPlayerDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminExportMasterPlayerDataResultEvent
 -= (PlayFabResultEvent<AdminModels.ExportMasterPlayerDataResult>)each; } } }

            if (OnAdminGetActionsOnPlayersInSegmentTaskInstanceRequestEvent != null) { foreach (var each in OnAdminGetActionsOnPlayersInSegmentTaskInstanceRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetActionsOnPlayersInSegmentTaskInstanceRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetTaskInstanceRequest>)each; } } }
            if (OnAdminGetActionsOnPlayersInSegmentTaskInstanceResultEvent != null) { foreach (var each in OnAdminGetActionsOnPlayersInSegmentTaskInstanceResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetActionsOnPlayersInSegmentTaskInstanceResultEvent
 -= (PlayFabResultEvent<AdminModels.GetActionsOnPlayersInSegmentTaskInstanceResult>)each; } } }

            if (OnAdminGetAllSegmentsRequestEvent != null) { foreach (var each in OnAdminGetAllSegmentsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetAllSegmentsRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetAllSegmentsRequest>)each; } } }
            if (OnAdminGetAllSegmentsResultEvent != null) { foreach (var each in OnAdminGetAllSegmentsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetAllSegmentsResultEvent
 -= (PlayFabResultEvent<AdminModels.GetAllSegmentsResult>)each; } } }

            if (OnAdminGetCatalogItemsRequestEvent != null) { foreach (var each in OnAdminGetCatalogItemsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetCatalogItemsRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetCatalogItemsRequest>)each; } } }
            if (OnAdminGetCatalogItemsResultEvent != null) { foreach (var each in OnAdminGetCatalogItemsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetCatalogItemsResultEvent
 -= (PlayFabResultEvent<AdminModels.GetCatalogItemsResult>)each; } } }

            if (OnAdminGetCloudScriptRevisionRequestEvent != null) { foreach (var each in OnAdminGetCloudScriptRevisionRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetCloudScriptRevisionRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetCloudScriptRevisionRequest>)each; } } }
            if (OnAdminGetCloudScriptRevisionResultEvent != null) { foreach (var each in OnAdminGetCloudScriptRevisionResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetCloudScriptRevisionResultEvent
 -= (PlayFabResultEvent<AdminModels.GetCloudScriptRevisionResult>)each; } } }

            if (OnAdminGetCloudScriptTaskInstanceRequestEvent != null) { foreach (var each in OnAdminGetCloudScriptTaskInstanceRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetCloudScriptTaskInstanceRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetTaskInstanceRequest>)each; } } }
            if (OnAdminGetCloudScriptTaskInstanceResultEvent != null) { foreach (var each in OnAdminGetCloudScriptTaskInstanceResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetCloudScriptTaskInstanceResultEvent
 -= (PlayFabResultEvent<AdminModels.GetCloudScriptTaskInstanceResult>)each; } } }

            if (OnAdminGetCloudScriptVersionsRequestEvent != null) { foreach (var each in OnAdminGetCloudScriptVersionsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetCloudScriptVersionsRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetCloudScriptVersionsRequest>)each; } } }
            if (OnAdminGetCloudScriptVersionsResultEvent != null) { foreach (var each in OnAdminGetCloudScriptVersionsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetCloudScriptVersionsResultEvent
 -= (PlayFabResultEvent<AdminModels.GetCloudScriptVersionsResult>)each; } } }

            if (OnAdminGetContentListRequestEvent != null) { foreach (var each in OnAdminGetContentListRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetContentListRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetContentListRequest>)each; } } }
            if (OnAdminGetContentListResultEvent != null) { foreach (var each in OnAdminGetContentListResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetContentListResultEvent
 -= (PlayFabResultEvent<AdminModels.GetContentListResult>)each; } } }

            if (OnAdminGetContentUploadUrlRequestEvent != null) { foreach (var each in OnAdminGetContentUploadUrlRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetContentUploadUrlRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetContentUploadUrlRequest>)each; } } }
            if (OnAdminGetContentUploadUrlResultEvent != null) { foreach (var each in OnAdminGetContentUploadUrlResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetContentUploadUrlResultEvent
 -= (PlayFabResultEvent<AdminModels.GetContentUploadUrlResult>)each; } } }

            if (OnAdminGetDataReportRequestEvent != null) { foreach (var each in OnAdminGetDataReportRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetDataReportRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetDataReportRequest>)each; } } }
            if (OnAdminGetDataReportResultEvent != null) { foreach (var each in OnAdminGetDataReportResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetDataReportResultEvent
 -= (PlayFabResultEvent<AdminModels.GetDataReportResult>)each; } } }

            if (OnAdminGetMatchmakerGameInfoRequestEvent != null) { foreach (var each in OnAdminGetMatchmakerGameInfoRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetMatchmakerGameInfoRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetMatchmakerGameInfoRequest>)each; } } }
            if (OnAdminGetMatchmakerGameInfoResultEvent != null) { foreach (var each in OnAdminGetMatchmakerGameInfoResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetMatchmakerGameInfoResultEvent
 -= (PlayFabResultEvent<AdminModels.GetMatchmakerGameInfoResult>)each; } } }

            if (OnAdminGetMatchmakerGameModesRequestEvent != null) { foreach (var each in OnAdminGetMatchmakerGameModesRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetMatchmakerGameModesRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetMatchmakerGameModesRequest>)each; } } }
            if (OnAdminGetMatchmakerGameModesResultEvent != null) { foreach (var each in OnAdminGetMatchmakerGameModesResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetMatchmakerGameModesResultEvent
 -= (PlayFabResultEvent<AdminModels.GetMatchmakerGameModesResult>)each; } } }

            if (OnAdminGetPlayedTitleListRequestEvent != null) { foreach (var each in OnAdminGetPlayedTitleListRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetPlayedTitleListRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetPlayedTitleListRequest>)each; } } }
            if (OnAdminGetPlayedTitleListResultEvent != null) { foreach (var each in OnAdminGetPlayedTitleListResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetPlayedTitleListResultEvent
 -= (PlayFabResultEvent<AdminModels.GetPlayedTitleListResult>)each; } } }

            if (OnAdminGetPlayerIdFromAuthTokenRequestEvent != null) { foreach (var each in OnAdminGetPlayerIdFromAuthTokenRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetPlayerIdFromAuthTokenRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetPlayerIdFromAuthTokenRequest>)each; } } }
            if (OnAdminGetPlayerIdFromAuthTokenResultEvent != null) { foreach (var each in OnAdminGetPlayerIdFromAuthTokenResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetPlayerIdFromAuthTokenResultEvent
 -= (PlayFabResultEvent<AdminModels.GetPlayerIdFromAuthTokenResult>)each; } } }

            if (OnAdminGetPlayerProfileRequestEvent != null) { foreach (var each in OnAdminGetPlayerProfileRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetPlayerProfileRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetPlayerProfileRequest>)each; } } }
            if (OnAdminGetPlayerProfileResultEvent != null) { foreach (var each in OnAdminGetPlayerProfileResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetPlayerProfileResultEvent
 -= (PlayFabResultEvent<AdminModels.GetPlayerProfileResult>)each; } } }

            if (OnAdminGetPlayerSegmentsRequestEvent != null) { foreach (var each in OnAdminGetPlayerSegmentsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetPlayerSegmentsRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetPlayersSegmentsRequest>)each; } } }
            if (OnAdminGetPlayerSegmentsResultEvent != null) { foreach (var each in OnAdminGetPlayerSegmentsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetPlayerSegmentsResultEvent
 -= (PlayFabResultEvent<AdminModels.GetPlayerSegmentsResult>)each; } } }

            if (OnAdminGetPlayerSharedSecretsRequestEvent != null) { foreach (var each in OnAdminGetPlayerSharedSecretsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetPlayerSharedSecretsRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetPlayerSharedSecretsRequest>)each; } } }
            if (OnAdminGetPlayerSharedSecretsResultEvent != null) { foreach (var each in OnAdminGetPlayerSharedSecretsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetPlayerSharedSecretsResultEvent
 -= (PlayFabResultEvent<AdminModels.GetPlayerSharedSecretsResult>)each; } } }

            if (OnAdminGetPlayersInSegmentRequestEvent != null) { foreach (var each in OnAdminGetPlayersInSegmentRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetPlayersInSegmentRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetPlayersInSegmentRequest>)each; } } }
            if (OnAdminGetPlayersInSegmentResultEvent != null) { foreach (var each in OnAdminGetPlayersInSegmentResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetPlayersInSegmentResultEvent
 -= (PlayFabResultEvent<AdminModels.GetPlayersInSegmentResult>)each; } } }

            if (OnAdminGetPlayerStatisticDefinitionsRequestEvent != null) { foreach (var each in OnAdminGetPlayerStatisticDefinitionsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetPlayerStatisticDefinitionsRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetPlayerStatisticDefinitionsRequest>)each; } } }
            if (OnAdminGetPlayerStatisticDefinitionsResultEvent != null) { foreach (var each in OnAdminGetPlayerStatisticDefinitionsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetPlayerStatisticDefinitionsResultEvent
 -= (PlayFabResultEvent<AdminModels.GetPlayerStatisticDefinitionsResult>)each; } } }

            if (OnAdminGetPlayerStatisticVersionsRequestEvent != null) { foreach (var each in OnAdminGetPlayerStatisticVersionsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetPlayerStatisticVersionsRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetPlayerStatisticVersionsRequest>)each; } } }
            if (OnAdminGetPlayerStatisticVersionsResultEvent != null) { foreach (var each in OnAdminGetPlayerStatisticVersionsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetPlayerStatisticVersionsResultEvent
 -= (PlayFabResultEvent<AdminModels.GetPlayerStatisticVersionsResult>)each; } } }

            if (OnAdminGetPlayerTagsRequestEvent != null) { foreach (var each in OnAdminGetPlayerTagsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetPlayerTagsRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetPlayerTagsRequest>)each; } } }
            if (OnAdminGetPlayerTagsResultEvent != null) { foreach (var each in OnAdminGetPlayerTagsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetPlayerTagsResultEvent
 -= (PlayFabResultEvent<AdminModels.GetPlayerTagsResult>)each; } } }

            if (OnAdminGetPolicyRequestEvent != null) { foreach (var each in OnAdminGetPolicyRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetPolicyRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetPolicyRequest>)each; } } }
            if (OnAdminGetPolicyResultEvent != null) { foreach (var each in OnAdminGetPolicyResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetPolicyResultEvent
 -= (PlayFabResultEvent<AdminModels.GetPolicyResponse>)each; } } }

            if (OnAdminGetPublisherDataRequestEvent != null) { foreach (var each in OnAdminGetPublisherDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetPublisherDataRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetPublisherDataRequest>)each; } } }
            if (OnAdminGetPublisherDataResultEvent != null) { foreach (var each in OnAdminGetPublisherDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetPublisherDataResultEvent
 -= (PlayFabResultEvent<AdminModels.GetPublisherDataResult>)each; } } }

            if (OnAdminGetRandomResultTablesRequestEvent != null) { foreach (var each in OnAdminGetRandomResultTablesRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetRandomResultTablesRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetRandomResultTablesRequest>)each; } } }
            if (OnAdminGetRandomResultTablesResultEvent != null) { foreach (var each in OnAdminGetRandomResultTablesResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetRandomResultTablesResultEvent
 -= (PlayFabResultEvent<AdminModels.GetRandomResultTablesResult>)each; } } }

            if (OnAdminGetServerBuildInfoRequestEvent != null) { foreach (var each in OnAdminGetServerBuildInfoRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetServerBuildInfoRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetServerBuildInfoRequest>)each; } } }
            if (OnAdminGetServerBuildInfoResultEvent != null) { foreach (var each in OnAdminGetServerBuildInfoResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetServerBuildInfoResultEvent
 -= (PlayFabResultEvent<AdminModels.GetServerBuildInfoResult>)each; } } }

            if (OnAdminGetServerBuildUploadUrlRequestEvent != null) { foreach (var each in OnAdminGetServerBuildUploadUrlRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetServerBuildUploadUrlRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetServerBuildUploadURLRequest>)each; } } }
            if (OnAdminGetServerBuildUploadUrlResultEvent != null) { foreach (var each in OnAdminGetServerBuildUploadUrlResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetServerBuildUploadUrlResultEvent
 -= (PlayFabResultEvent<AdminModels.GetServerBuildUploadURLResult>)each; } } }

            if (OnAdminGetStoreItemsRequestEvent != null) { foreach (var each in OnAdminGetStoreItemsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetStoreItemsRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetStoreItemsRequest>)each; } } }
            if (OnAdminGetStoreItemsResultEvent != null) { foreach (var each in OnAdminGetStoreItemsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetStoreItemsResultEvent
 -= (PlayFabResultEvent<AdminModels.GetStoreItemsResult>)each; } } }

            if (OnAdminGetTaskInstancesRequestEvent != null) { foreach (var each in OnAdminGetTaskInstancesRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetTaskInstancesRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetTaskInstancesRequest>)each; } } }
            if (OnAdminGetTaskInstancesResultEvent != null) { foreach (var each in OnAdminGetTaskInstancesResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetTaskInstancesResultEvent
 -= (PlayFabResultEvent<AdminModels.GetTaskInstancesResult>)each; } } }

            if (OnAdminGetTasksRequestEvent != null) { foreach (var each in OnAdminGetTasksRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetTasksRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetTasksRequest>)each; } } }
            if (OnAdminGetTasksResultEvent != null) { foreach (var each in OnAdminGetTasksResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetTasksResultEvent
 -= (PlayFabResultEvent<AdminModels.GetTasksResult>)each; } } }

            if (OnAdminGetTitleDataRequestEvent != null) { foreach (var each in OnAdminGetTitleDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetTitleDataRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetTitleDataRequest>)each; } } }
            if (OnAdminGetTitleDataResultEvent != null) { foreach (var each in OnAdminGetTitleDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetTitleDataResultEvent
 -= (PlayFabResultEvent<AdminModels.GetTitleDataResult>)each; } } }

            if (OnAdminGetTitleInternalDataRequestEvent != null) { foreach (var each in OnAdminGetTitleInternalDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetTitleInternalDataRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetTitleDataRequest>)each; } } }
            if (OnAdminGetTitleInternalDataResultEvent != null) { foreach (var each in OnAdminGetTitleInternalDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetTitleInternalDataResultEvent
 -= (PlayFabResultEvent<AdminModels.GetTitleDataResult>)each; } } }

            if (OnAdminGetUserAccountInfoRequestEvent != null) { foreach (var each in OnAdminGetUserAccountInfoRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetUserAccountInfoRequestEvent
 -= (PlayFabRequestEvent<AdminModels.LookupUserAccountInfoRequest>)each; } } }
            if (OnAdminGetUserAccountInfoResultEvent != null) { foreach (var each in OnAdminGetUserAccountInfoResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetUserAccountInfoResultEvent
 -= (PlayFabResultEvent<AdminModels.LookupUserAccountInfoResult>)each; } } }

            if (OnAdminGetUserBansRequestEvent != null) { foreach (var each in OnAdminGetUserBansRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetUserBansRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetUserBansRequest>)each; } } }
            if (OnAdminGetUserBansResultEvent != null) { foreach (var each in OnAdminGetUserBansResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetUserBansResultEvent
 -= (PlayFabResultEvent<AdminModels.GetUserBansResult>)each; } } }

            if (OnAdminGetUserDataRequestEvent != null) { foreach (var each in OnAdminGetUserDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetUserDataRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetUserDataRequest>)each; } } }
            if (OnAdminGetUserDataResultEvent != null) { foreach (var each in OnAdminGetUserDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetUserDataResultEvent
 -= (PlayFabResultEvent<AdminModels.GetUserDataResult>)each; } } }

            if (OnAdminGetUserInternalDataRequestEvent != null) { foreach (var each in OnAdminGetUserInternalDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetUserInternalDataRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetUserDataRequest>)each; } } }
            if (OnAdminGetUserInternalDataResultEvent != null) { foreach (var each in OnAdminGetUserInternalDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetUserInternalDataResultEvent
 -= (PlayFabResultEvent<AdminModels.GetUserDataResult>)each; } } }

            if (OnAdminGetUserInventoryRequestEvent != null) { foreach (var each in OnAdminGetUserInventoryRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetUserInventoryRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetUserInventoryRequest>)each; } } }
            if (OnAdminGetUserInventoryResultEvent != null) { foreach (var each in OnAdminGetUserInventoryResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetUserInventoryResultEvent
 -= (PlayFabResultEvent<AdminModels.GetUserInventoryResult>)each; } } }

            if (OnAdminGetUserPublisherDataRequestEvent != null) { foreach (var each in OnAdminGetUserPublisherDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetUserPublisherDataRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetUserDataRequest>)each; } } }
            if (OnAdminGetUserPublisherDataResultEvent != null) { foreach (var each in OnAdminGetUserPublisherDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetUserPublisherDataResultEvent
 -= (PlayFabResultEvent<AdminModels.GetUserDataResult>)each; } } }

            if (OnAdminGetUserPublisherInternalDataRequestEvent != null) { foreach (var each in OnAdminGetUserPublisherInternalDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetUserPublisherInternalDataRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetUserDataRequest>)each; } } }
            if (OnAdminGetUserPublisherInternalDataResultEvent != null) { foreach (var each in OnAdminGetUserPublisherInternalDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetUserPublisherInternalDataResultEvent
 -= (PlayFabResultEvent<AdminModels.GetUserDataResult>)each; } } }

            if (OnAdminGetUserPublisherReadOnlyDataRequestEvent != null) { foreach (var each in OnAdminGetUserPublisherReadOnlyDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetUserPublisherReadOnlyDataRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetUserDataRequest>)each; } } }
            if (OnAdminGetUserPublisherReadOnlyDataResultEvent != null) { foreach (var each in OnAdminGetUserPublisherReadOnlyDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetUserPublisherReadOnlyDataResultEvent
 -= (PlayFabResultEvent<AdminModels.GetUserDataResult>)each; } } }

            if (OnAdminGetUserReadOnlyDataRequestEvent != null) { foreach (var each in OnAdminGetUserReadOnlyDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetUserReadOnlyDataRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GetUserDataRequest>)each; } } }
            if (OnAdminGetUserReadOnlyDataResultEvent != null) { foreach (var each in OnAdminGetUserReadOnlyDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGetUserReadOnlyDataResultEvent
 -= (PlayFabResultEvent<AdminModels.GetUserDataResult>)each; } } }

            if (OnAdminGrantItemsToUsersRequestEvent != null) { foreach (var each in OnAdminGrantItemsToUsersRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGrantItemsToUsersRequestEvent
 -= (PlayFabRequestEvent<AdminModels.GrantItemsToUsersRequest>)each; } } }
            if (OnAdminGrantItemsToUsersResultEvent != null) { foreach (var each in OnAdminGrantItemsToUsersResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminGrantItemsToUsersResultEvent
 -= (PlayFabResultEvent<AdminModels.GrantItemsToUsersResult>)each; } } }

            if (OnAdminIncrementLimitedEditionItemAvailabilityRequestEvent != null) { foreach (var each in OnAdminIncrementLimitedEditionItemAvailabilityRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminIncrementLimitedEditionItemAvailabilityRequestEvent
 -= (PlayFabRequestEvent<AdminModels.IncrementLimitedEditionItemAvailabilityRequest>)each; } } }
            if (OnAdminIncrementLimitedEditionItemAvailabilityResultEvent != null) { foreach (var each in OnAdminIncrementLimitedEditionItemAvailabilityResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminIncrementLimitedEditionItemAvailabilityResultEvent
 -= (PlayFabResultEvent<AdminModels.IncrementLimitedEditionItemAvailabilityResult>)each; } } }

            if (OnAdminIncrementPlayerStatisticVersionRequestEvent != null) { foreach (var each in OnAdminIncrementPlayerStatisticVersionRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminIncrementPlayerStatisticVersionRequestEvent
 -= (PlayFabRequestEvent<AdminModels.IncrementPlayerStatisticVersionRequest>)each; } } }
            if (OnAdminIncrementPlayerStatisticVersionResultEvent != null) { foreach (var each in OnAdminIncrementPlayerStatisticVersionResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminIncrementPlayerStatisticVersionResultEvent
 -= (PlayFabResultEvent<AdminModels.IncrementPlayerStatisticVersionResult>)each; } } }

            if (OnAdminListOpenIdConnectionRequestEvent != null) { foreach (var each in OnAdminListOpenIdConnectionRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminListOpenIdConnectionRequestEvent
 -= (PlayFabRequestEvent<AdminModels.ListOpenIdConnectionRequest>)each; } } }
            if (OnAdminListOpenIdConnectionResultEvent != null) { foreach (var each in OnAdminListOpenIdConnectionResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminListOpenIdConnectionResultEvent
 -= (PlayFabResultEvent<AdminModels.ListOpenIdConnectionResponse>)each; } } }

            if (OnAdminListServerBuildsRequestEvent != null) { foreach (var each in OnAdminListServerBuildsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminListServerBuildsRequestEvent
 -= (PlayFabRequestEvent<AdminModels.ListBuildsRequest>)each; } } }
            if (OnAdminListServerBuildsResultEvent != null) { foreach (var each in OnAdminListServerBuildsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminListServerBuildsResultEvent
 -= (PlayFabResultEvent<AdminModels.ListBuildsResult>)each; } } }

            if (OnAdminListVirtualCurrencyTypesRequestEvent != null) { foreach (var each in OnAdminListVirtualCurrencyTypesRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminListVirtualCurrencyTypesRequestEvent
 -= (PlayFabRequestEvent<AdminModels.ListVirtualCurrencyTypesRequest>)each; } } }
            if (OnAdminListVirtualCurrencyTypesResultEvent != null) { foreach (var each in OnAdminListVirtualCurrencyTypesResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminListVirtualCurrencyTypesResultEvent
 -= (PlayFabResultEvent<AdminModels.ListVirtualCurrencyTypesResult>)each; } } }

            if (OnAdminModifyMatchmakerGameModesRequestEvent != null) { foreach (var each in OnAdminModifyMatchmakerGameModesRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminModifyMatchmakerGameModesRequestEvent
 -= (PlayFabRequestEvent<AdminModels.ModifyMatchmakerGameModesRequest>)each; } } }
            if (OnAdminModifyMatchmakerGameModesResultEvent != null) { foreach (var each in OnAdminModifyMatchmakerGameModesResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminModifyMatchmakerGameModesResultEvent
 -= (PlayFabResultEvent<AdminModels.ModifyMatchmakerGameModesResult>)each; } } }

            if (OnAdminModifyServerBuildRequestEvent != null) { foreach (var each in OnAdminModifyServerBuildRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminModifyServerBuildRequestEvent
 -= (PlayFabRequestEvent<AdminModels.ModifyServerBuildRequest>)each; } } }
            if (OnAdminModifyServerBuildResultEvent != null) { foreach (var each in OnAdminModifyServerBuildResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminModifyServerBuildResultEvent
 -= (PlayFabResultEvent<AdminModels.ModifyServerBuildResult>)each; } } }

            if (OnAdminRefundPurchaseRequestEvent != null) { foreach (var each in OnAdminRefundPurchaseRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminRefundPurchaseRequestEvent
 -= (PlayFabRequestEvent<AdminModels.RefundPurchaseRequest>)each; } } }
            if (OnAdminRefundPurchaseResultEvent != null) { foreach (var each in OnAdminRefundPurchaseResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminRefundPurchaseResultEvent
 -= (PlayFabResultEvent<AdminModels.RefundPurchaseResponse>)each; } } }

            if (OnAdminRemovePlayerTagRequestEvent != null) { foreach (var each in OnAdminRemovePlayerTagRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminRemovePlayerTagRequestEvent
 -= (PlayFabRequestEvent<AdminModels.RemovePlayerTagRequest>)each; } } }
            if (OnAdminRemovePlayerTagResultEvent != null) { foreach (var each in OnAdminRemovePlayerTagResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminRemovePlayerTagResultEvent
 -= (PlayFabResultEvent<AdminModels.RemovePlayerTagResult>)each; } } }

            if (OnAdminRemoveServerBuildRequestEvent != null) { foreach (var each in OnAdminRemoveServerBuildRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminRemoveServerBuildRequestEvent
 -= (PlayFabRequestEvent<AdminModels.RemoveServerBuildRequest>)each; } } }
            if (OnAdminRemoveServerBuildResultEvent != null) { foreach (var each in OnAdminRemoveServerBuildResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminRemoveServerBuildResultEvent
 -= (PlayFabResultEvent<AdminModels.RemoveServerBuildResult>)each; } } }

            if (OnAdminRemoveVirtualCurrencyTypesRequestEvent != null) { foreach (var each in OnAdminRemoveVirtualCurrencyTypesRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminRemoveVirtualCurrencyTypesRequestEvent
 -= (PlayFabRequestEvent<AdminModels.RemoveVirtualCurrencyTypesRequest>)each; } } }
            if (OnAdminRemoveVirtualCurrencyTypesResultEvent != null) { foreach (var each in OnAdminRemoveVirtualCurrencyTypesResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminRemoveVirtualCurrencyTypesResultEvent
 -= (PlayFabResultEvent<AdminModels.BlankResult>)each; } } }

            if (OnAdminResetCharacterStatisticsRequestEvent != null) { foreach (var each in OnAdminResetCharacterStatisticsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminResetCharacterStatisticsRequestEvent
 -= (PlayFabRequestEvent<AdminModels.ResetCharacterStatisticsRequest>)each; } } }
            if (OnAdminResetCharacterStatisticsResultEvent != null) { foreach (var each in OnAdminResetCharacterStatisticsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminResetCharacterStatisticsResultEvent
 -= (PlayFabResultEvent<AdminModels.ResetCharacterStatisticsResult>)each; } } }

            if (OnAdminResetPasswordRequestEvent != null) { foreach (var each in OnAdminResetPasswordRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminResetPasswordRequestEvent
 -= (PlayFabRequestEvent<AdminModels.ResetPasswordRequest>)each; } } }
            if (OnAdminResetPasswordResultEvent != null) { foreach (var each in OnAdminResetPasswordResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminResetPasswordResultEvent
 -= (PlayFabResultEvent<AdminModels.ResetPasswordResult>)each; } } }

            if (OnAdminResetUserStatisticsRequestEvent != null) { foreach (var each in OnAdminResetUserStatisticsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminResetUserStatisticsRequestEvent
 -= (PlayFabRequestEvent<AdminModels.ResetUserStatisticsRequest>)each; } } }
            if (OnAdminResetUserStatisticsResultEvent != null) { foreach (var each in OnAdminResetUserStatisticsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminResetUserStatisticsResultEvent
 -= (PlayFabResultEvent<AdminModels.ResetUserStatisticsResult>)each; } } }

            if (OnAdminResolvePurchaseDisputeRequestEvent != null) { foreach (var each in OnAdminResolvePurchaseDisputeRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminResolvePurchaseDisputeRequestEvent
 -= (PlayFabRequestEvent<AdminModels.ResolvePurchaseDisputeRequest>)each; } } }
            if (OnAdminResolvePurchaseDisputeResultEvent != null) { foreach (var each in OnAdminResolvePurchaseDisputeResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminResolvePurchaseDisputeResultEvent
 -= (PlayFabResultEvent<AdminModels.ResolvePurchaseDisputeResponse>)each; } } }

            if (OnAdminRevokeAllBansForUserRequestEvent != null) { foreach (var each in OnAdminRevokeAllBansForUserRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminRevokeAllBansForUserRequestEvent
 -= (PlayFabRequestEvent<AdminModels.RevokeAllBansForUserRequest>)each; } } }
            if (OnAdminRevokeAllBansForUserResultEvent != null) { foreach (var each in OnAdminRevokeAllBansForUserResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminRevokeAllBansForUserResultEvent
 -= (PlayFabResultEvent<AdminModels.RevokeAllBansForUserResult>)each; } } }

            if (OnAdminRevokeBansRequestEvent != null) { foreach (var each in OnAdminRevokeBansRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminRevokeBansRequestEvent
 -= (PlayFabRequestEvent<AdminModels.RevokeBansRequest>)each; } } }
            if (OnAdminRevokeBansResultEvent != null) { foreach (var each in OnAdminRevokeBansResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminRevokeBansResultEvent
 -= (PlayFabResultEvent<AdminModels.RevokeBansResult>)each; } } }

            if (OnAdminRevokeInventoryItemRequestEvent != null) { foreach (var each in OnAdminRevokeInventoryItemRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminRevokeInventoryItemRequestEvent
 -= (PlayFabRequestEvent<AdminModels.RevokeInventoryItemRequest>)each; } } }
            if (OnAdminRevokeInventoryItemResultEvent != null) { foreach (var each in OnAdminRevokeInventoryItemResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminRevokeInventoryItemResultEvent
 -= (PlayFabResultEvent<AdminModels.RevokeInventoryResult>)each; } } }

            if (OnAdminRevokeInventoryItemsRequestEvent != null) { foreach (var each in OnAdminRevokeInventoryItemsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminRevokeInventoryItemsRequestEvent
 -= (PlayFabRequestEvent<AdminModels.RevokeInventoryItemsRequest>)each; } } }
            if (OnAdminRevokeInventoryItemsResultEvent != null) { foreach (var each in OnAdminRevokeInventoryItemsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminRevokeInventoryItemsResultEvent
 -= (PlayFabResultEvent<AdminModels.RevokeInventoryItemsResult>)each; } } }

            if (OnAdminRunTaskRequestEvent != null) { foreach (var each in OnAdminRunTaskRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminRunTaskRequestEvent
 -= (PlayFabRequestEvent<AdminModels.RunTaskRequest>)each; } } }
            if (OnAdminRunTaskResultEvent != null) { foreach (var each in OnAdminRunTaskResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminRunTaskResultEvent
 -= (PlayFabResultEvent<AdminModels.RunTaskResult>)each; } } }

            if (OnAdminSendAccountRecoveryEmailRequestEvent != null) { foreach (var each in OnAdminSendAccountRecoveryEmailRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminSendAccountRecoveryEmailRequestEvent
 -= (PlayFabRequestEvent<AdminModels.SendAccountRecoveryEmailRequest>)each; } } }
            if (OnAdminSendAccountRecoveryEmailResultEvent != null) { foreach (var each in OnAdminSendAccountRecoveryEmailResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminSendAccountRecoveryEmailResultEvent
 -= (PlayFabResultEvent<AdminModels.SendAccountRecoveryEmailResult>)each; } } }

            if (OnAdminSetCatalogItemsRequestEvent != null) { foreach (var each in OnAdminSetCatalogItemsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminSetCatalogItemsRequestEvent
 -= (PlayFabRequestEvent<AdminModels.UpdateCatalogItemsRequest>)each; } } }
            if (OnAdminSetCatalogItemsResultEvent != null) { foreach (var each in OnAdminSetCatalogItemsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminSetCatalogItemsResultEvent
 -= (PlayFabResultEvent<AdminModels.UpdateCatalogItemsResult>)each; } } }

            if (OnAdminSetPlayerSecretRequestEvent != null) { foreach (var each in OnAdminSetPlayerSecretRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminSetPlayerSecretRequestEvent
 -= (PlayFabRequestEvent<AdminModels.SetPlayerSecretRequest>)each; } } }
            if (OnAdminSetPlayerSecretResultEvent != null) { foreach (var each in OnAdminSetPlayerSecretResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminSetPlayerSecretResultEvent
 -= (PlayFabResultEvent<AdminModels.SetPlayerSecretResult>)each; } } }

            if (OnAdminSetPublishedRevisionRequestEvent != null) { foreach (var each in OnAdminSetPublishedRevisionRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminSetPublishedRevisionRequestEvent
 -= (PlayFabRequestEvent<AdminModels.SetPublishedRevisionRequest>)each; } } }
            if (OnAdminSetPublishedRevisionResultEvent != null) { foreach (var each in OnAdminSetPublishedRevisionResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminSetPublishedRevisionResultEvent
 -= (PlayFabResultEvent<AdminModels.SetPublishedRevisionResult>)each; } } }

            if (OnAdminSetPublisherDataRequestEvent != null) { foreach (var each in OnAdminSetPublisherDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminSetPublisherDataRequestEvent
 -= (PlayFabRequestEvent<AdminModels.SetPublisherDataRequest>)each; } } }
            if (OnAdminSetPublisherDataResultEvent != null) { foreach (var each in OnAdminSetPublisherDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminSetPublisherDataResultEvent
 -= (PlayFabResultEvent<AdminModels.SetPublisherDataResult>)each; } } }

            if (OnAdminSetStoreItemsRequestEvent != null) { foreach (var each in OnAdminSetStoreItemsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminSetStoreItemsRequestEvent
 -= (PlayFabRequestEvent<AdminModels.UpdateStoreItemsRequest>)each; } } }
            if (OnAdminSetStoreItemsResultEvent != null) { foreach (var each in OnAdminSetStoreItemsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminSetStoreItemsResultEvent
 -= (PlayFabResultEvent<AdminModels.UpdateStoreItemsResult>)each; } } }

            if (OnAdminSetTitleDataRequestEvent != null) { foreach (var each in OnAdminSetTitleDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminSetTitleDataRequestEvent
 -= (PlayFabRequestEvent<AdminModels.SetTitleDataRequest>)each; } } }
            if (OnAdminSetTitleDataResultEvent != null) { foreach (var each in OnAdminSetTitleDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminSetTitleDataResultEvent
 -= (PlayFabResultEvent<AdminModels.SetTitleDataResult>)each; } } }

            if (OnAdminSetTitleInternalDataRequestEvent != null) { foreach (var each in OnAdminSetTitleInternalDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminSetTitleInternalDataRequestEvent
 -= (PlayFabRequestEvent<AdminModels.SetTitleDataRequest>)each; } } }
            if (OnAdminSetTitleInternalDataResultEvent != null) { foreach (var each in OnAdminSetTitleInternalDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminSetTitleInternalDataResultEvent
 -= (PlayFabResultEvent<AdminModels.SetTitleDataResult>)each; } } }

            if (OnAdminSetupPushNotificationRequestEvent != null) { foreach (var each in OnAdminSetupPushNotificationRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminSetupPushNotificationRequestEvent
 -= (PlayFabRequestEvent<AdminModels.SetupPushNotificationRequest>)each; } } }
            if (OnAdminSetupPushNotificationResultEvent != null) { foreach (var each in OnAdminSetupPushNotificationResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminSetupPushNotificationResultEvent
 -= (PlayFabResultEvent<AdminModels.SetupPushNotificationResult>)each; } } }

            if (OnAdminSubtractUserVirtualCurrencyRequestEvent != null) { foreach (var each in OnAdminSubtractUserVirtualCurrencyRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminSubtractUserVirtualCurrencyRequestEvent
 -= (PlayFabRequestEvent<AdminModels.SubtractUserVirtualCurrencyRequest>)each; } } }
            if (OnAdminSubtractUserVirtualCurrencyResultEvent != null) { foreach (var each in OnAdminSubtractUserVirtualCurrencyResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminSubtractUserVirtualCurrencyResultEvent
 -= (PlayFabResultEvent<AdminModels.ModifyUserVirtualCurrencyResult>)each; } } }

            if (OnAdminUpdateBansRequestEvent != null) { foreach (var each in OnAdminUpdateBansRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateBansRequestEvent
 -= (PlayFabRequestEvent<AdminModels.UpdateBansRequest>)each; } } }
            if (OnAdminUpdateBansResultEvent != null) { foreach (var each in OnAdminUpdateBansResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateBansResultEvent
 -= (PlayFabResultEvent<AdminModels.UpdateBansResult>)each; } } }

            if (OnAdminUpdateCatalogItemsRequestEvent != null) { foreach (var each in OnAdminUpdateCatalogItemsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateCatalogItemsRequestEvent
 -= (PlayFabRequestEvent<AdminModels.UpdateCatalogItemsRequest>)each; } } }
            if (OnAdminUpdateCatalogItemsResultEvent != null) { foreach (var each in OnAdminUpdateCatalogItemsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateCatalogItemsResultEvent
 -= (PlayFabResultEvent<AdminModels.UpdateCatalogItemsResult>)each; } } }

            if (OnAdminUpdateCloudScriptRequestEvent != null) { foreach (var each in OnAdminUpdateCloudScriptRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateCloudScriptRequestEvent
 -= (PlayFabRequestEvent<AdminModels.UpdateCloudScriptRequest>)each; } } }
            if (OnAdminUpdateCloudScriptResultEvent != null) { foreach (var each in OnAdminUpdateCloudScriptResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateCloudScriptResultEvent
 -= (PlayFabResultEvent<AdminModels.UpdateCloudScriptResult>)each; } } }

            if (OnAdminUpdateOpenIdConnectionRequestEvent != null) { foreach (var each in OnAdminUpdateOpenIdConnectionRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateOpenIdConnectionRequestEvent
 -= (PlayFabRequestEvent<AdminModels.UpdateOpenIdConnectionRequest>)each; } } }
            if (OnAdminUpdateOpenIdConnectionResultEvent != null) { foreach (var each in OnAdminUpdateOpenIdConnectionResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateOpenIdConnectionResultEvent
 -= (PlayFabResultEvent<AdminModels.EmptyResponse>)each; } } }

            if (OnAdminUpdatePlayerSharedSecretRequestEvent != null) { foreach (var each in OnAdminUpdatePlayerSharedSecretRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdatePlayerSharedSecretRequestEvent
 -= (PlayFabRequestEvent<AdminModels.UpdatePlayerSharedSecretRequest>)each; } } }
            if (OnAdminUpdatePlayerSharedSecretResultEvent != null) { foreach (var each in OnAdminUpdatePlayerSharedSecretResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdatePlayerSharedSecretResultEvent
 -= (PlayFabResultEvent<AdminModels.UpdatePlayerSharedSecretResult>)each; } } }

            if (OnAdminUpdatePlayerStatisticDefinitionRequestEvent != null) { foreach (var each in OnAdminUpdatePlayerStatisticDefinitionRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdatePlayerStatisticDefinitionRequestEvent
 -= (PlayFabRequestEvent<AdminModels.UpdatePlayerStatisticDefinitionRequest>)each; } } }
            if (OnAdminUpdatePlayerStatisticDefinitionResultEvent != null) { foreach (var each in OnAdminUpdatePlayerStatisticDefinitionResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdatePlayerStatisticDefinitionResultEvent
 -= (PlayFabResultEvent<AdminModels.UpdatePlayerStatisticDefinitionResult>)each; } } }

            if (OnAdminUpdatePolicyRequestEvent != null) { foreach (var each in OnAdminUpdatePolicyRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdatePolicyRequestEvent
 -= (PlayFabRequestEvent<AdminModels.UpdatePolicyRequest>)each; } } }
            if (OnAdminUpdatePolicyResultEvent != null) { foreach (var each in OnAdminUpdatePolicyResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdatePolicyResultEvent
 -= (PlayFabResultEvent<AdminModels.UpdatePolicyResponse>)each; } } }

            if (OnAdminUpdateRandomResultTablesRequestEvent != null) { foreach (var each in OnAdminUpdateRandomResultTablesRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateRandomResultTablesRequestEvent
 -= (PlayFabRequestEvent<AdminModels.UpdateRandomResultTablesRequest>)each; } } }
            if (OnAdminUpdateRandomResultTablesResultEvent != null) { foreach (var each in OnAdminUpdateRandomResultTablesResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateRandomResultTablesResultEvent
 -= (PlayFabResultEvent<AdminModels.UpdateRandomResultTablesResult>)each; } } }

            if (OnAdminUpdateStoreItemsRequestEvent != null) { foreach (var each in OnAdminUpdateStoreItemsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateStoreItemsRequestEvent
 -= (PlayFabRequestEvent<AdminModels.UpdateStoreItemsRequest>)each; } } }
            if (OnAdminUpdateStoreItemsResultEvent != null) { foreach (var each in OnAdminUpdateStoreItemsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateStoreItemsResultEvent
 -= (PlayFabResultEvent<AdminModels.UpdateStoreItemsResult>)each; } } }

            if (OnAdminUpdateTaskRequestEvent != null) { foreach (var each in OnAdminUpdateTaskRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateTaskRequestEvent
 -= (PlayFabRequestEvent<AdminModels.UpdateTaskRequest>)each; } } }
            if (OnAdminUpdateTaskResultEvent != null) { foreach (var each in OnAdminUpdateTaskResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateTaskResultEvent
 -= (PlayFabResultEvent<AdminModels.EmptyResponse>)each; } } }

            if (OnAdminUpdateUserDataRequestEvent != null) { foreach (var each in OnAdminUpdateUserDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateUserDataRequestEvent
 -= (PlayFabRequestEvent<AdminModels.UpdateUserDataRequest>)each; } } }
            if (OnAdminUpdateUserDataResultEvent != null) { foreach (var each in OnAdminUpdateUserDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateUserDataResultEvent
 -= (PlayFabResultEvent<AdminModels.UpdateUserDataResult>)each; } } }

            if (OnAdminUpdateUserInternalDataRequestEvent != null) { foreach (var each in OnAdminUpdateUserInternalDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateUserInternalDataRequestEvent
 -= (PlayFabRequestEvent<AdminModels.UpdateUserInternalDataRequest>)each; } } }
            if (OnAdminUpdateUserInternalDataResultEvent != null) { foreach (var each in OnAdminUpdateUserInternalDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateUserInternalDataResultEvent
 -= (PlayFabResultEvent<AdminModels.UpdateUserDataResult>)each; } } }

            if (OnAdminUpdateUserPublisherDataRequestEvent != null) { foreach (var each in OnAdminUpdateUserPublisherDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateUserPublisherDataRequestEvent
 -= (PlayFabRequestEvent<AdminModels.UpdateUserDataRequest>)each; } } }
            if (OnAdminUpdateUserPublisherDataResultEvent != null) { foreach (var each in OnAdminUpdateUserPublisherDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateUserPublisherDataResultEvent
 -= (PlayFabResultEvent<AdminModels.UpdateUserDataResult>)each; } } }

            if (OnAdminUpdateUserPublisherInternalDataRequestEvent != null) { foreach (var each in OnAdminUpdateUserPublisherInternalDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateUserPublisherInternalDataRequestEvent
 -= (PlayFabRequestEvent<AdminModels.UpdateUserInternalDataRequest>)each; } } }
            if (OnAdminUpdateUserPublisherInternalDataResultEvent != null) { foreach (var each in OnAdminUpdateUserPublisherInternalDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateUserPublisherInternalDataResultEvent
 -= (PlayFabResultEvent<AdminModels.UpdateUserDataResult>)each; } } }

            if (OnAdminUpdateUserPublisherReadOnlyDataRequestEvent != null) { foreach (var each in OnAdminUpdateUserPublisherReadOnlyDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateUserPublisherReadOnlyDataRequestEvent
 -= (PlayFabRequestEvent<AdminModels.UpdateUserDataRequest>)each; } } }
            if (OnAdminUpdateUserPublisherReadOnlyDataResultEvent != null) { foreach (var each in OnAdminUpdateUserPublisherReadOnlyDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateUserPublisherReadOnlyDataResultEvent
 -= (PlayFabResultEvent<AdminModels.UpdateUserDataResult>)each; } } }

            if (OnAdminUpdateUserReadOnlyDataRequestEvent != null) { foreach (var each in OnAdminUpdateUserReadOnlyDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateUserReadOnlyDataRequestEvent
 -= (PlayFabRequestEvent<AdminModels.UpdateUserDataRequest>)each; } } }
            if (OnAdminUpdateUserReadOnlyDataResultEvent != null) { foreach (var each in OnAdminUpdateUserReadOnlyDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateUserReadOnlyDataResultEvent
 -= (PlayFabResultEvent<AdminModels.UpdateUserDataResult>)each; } } }

            if (OnAdminUpdateUserTitleDisplayNameRequestEvent != null) { foreach (var each in OnAdminUpdateUserTitleDisplayNameRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateUserTitleDisplayNameRequestEvent
 -= (PlayFabRequestEvent<AdminModels.UpdateUserTitleDisplayNameRequest>)each; } } }
            if (OnAdminUpdateUserTitleDisplayNameResultEvent != null) { foreach (var each in OnAdminUpdateUserTitleDisplayNameResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnAdminUpdateUserTitleDisplayNameResultEvent
 -= (PlayFabResultEvent<AdminModels.UpdateUserTitleDisplayNameResult>)each; } } }

#endif
#if !DISABLE_PLAYFABCLIENT_API
      if (OnAcceptTradeRequestEvent != null)
        foreach (var each in OnAcceptTradeRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnAcceptTradeRequestEvent -= (PlayFabRequestEvent<ClientModels.AcceptTradeRequest>) each;
      if (OnAcceptTradeResultEvent != null)
        foreach (var each in OnAcceptTradeResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnAcceptTradeResultEvent -= (PlayFabResultEvent<ClientModels.AcceptTradeResponse>) each;

      if (OnAddFriendRequestEvent != null)
        foreach (var each in OnAddFriendRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnAddFriendRequestEvent -= (PlayFabRequestEvent<ClientModels.AddFriendRequest>) each;
      if (OnAddFriendResultEvent != null)
        foreach (var each in OnAddFriendResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnAddFriendResultEvent -= (PlayFabResultEvent<ClientModels.AddFriendResult>) each;

      if (OnAddGenericIDRequestEvent != null)
        foreach (var each in OnAddGenericIDRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnAddGenericIDRequestEvent -= (PlayFabRequestEvent<ClientModels.AddGenericIDRequest>) each;
      if (OnAddGenericIDResultEvent != null)
        foreach (var each in OnAddGenericIDResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnAddGenericIDResultEvent -= (PlayFabResultEvent<ClientModels.AddGenericIDResult>) each;

      if (OnAddOrUpdateContactEmailRequestEvent != null)
        foreach (var each in OnAddOrUpdateContactEmailRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnAddOrUpdateContactEmailRequestEvent -=
              (PlayFabRequestEvent<ClientModels.AddOrUpdateContactEmailRequest>) each;
      if (OnAddOrUpdateContactEmailResultEvent != null)
        foreach (var each in OnAddOrUpdateContactEmailResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnAddOrUpdateContactEmailResultEvent -=
              (PlayFabResultEvent<ClientModels.AddOrUpdateContactEmailResult>) each;

      if (OnAddSharedGroupMembersRequestEvent != null)
        foreach (var each in OnAddSharedGroupMembersRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnAddSharedGroupMembersRequestEvent -=
              (PlayFabRequestEvent<ClientModels.AddSharedGroupMembersRequest>) each;
      if (OnAddSharedGroupMembersResultEvent != null)
        foreach (var each in OnAddSharedGroupMembersResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnAddSharedGroupMembersResultEvent -= (PlayFabResultEvent<ClientModels.AddSharedGroupMembersResult>) each;

      if (OnAddUsernamePasswordRequestEvent != null)
        foreach (var each in OnAddUsernamePasswordRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnAddUsernamePasswordRequestEvent -= (PlayFabRequestEvent<ClientModels.AddUsernamePasswordRequest>) each;
      if (OnAddUsernamePasswordResultEvent != null)
        foreach (var each in OnAddUsernamePasswordResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnAddUsernamePasswordResultEvent -= (PlayFabResultEvent<ClientModels.AddUsernamePasswordResult>) each;

      if (OnAddUserVirtualCurrencyRequestEvent != null)
        foreach (var each in OnAddUserVirtualCurrencyRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnAddUserVirtualCurrencyRequestEvent -=
              (PlayFabRequestEvent<ClientModels.AddUserVirtualCurrencyRequest>) each;
      if (OnAddUserVirtualCurrencyResultEvent != null)
        foreach (var each in OnAddUserVirtualCurrencyResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnAddUserVirtualCurrencyResultEvent -=
              (PlayFabResultEvent<ClientModels.ModifyUserVirtualCurrencyResult>) each;

      if (OnAndroidDevicePushNotificationRegistrationRequestEvent != null)
        foreach (var each in OnAndroidDevicePushNotificationRegistrationRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnAndroidDevicePushNotificationRegistrationRequestEvent -=
              (PlayFabRequestEvent<ClientModels.AndroidDevicePushNotificationRegistrationRequest>) each;
      if (OnAndroidDevicePushNotificationRegistrationResultEvent != null)
        foreach (var each in OnAndroidDevicePushNotificationRegistrationResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnAndroidDevicePushNotificationRegistrationResultEvent -=
              (PlayFabResultEvent<ClientModels.AndroidDevicePushNotificationRegistrationResult>) each;

      if (OnAttributeInstallRequestEvent != null)
        foreach (var each in OnAttributeInstallRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnAttributeInstallRequestEvent -= (PlayFabRequestEvent<ClientModels.AttributeInstallRequest>) each;
      if (OnAttributeInstallResultEvent != null)
        foreach (var each in OnAttributeInstallResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnAttributeInstallResultEvent -= (PlayFabResultEvent<ClientModels.AttributeInstallResult>) each;

      if (OnCancelTradeRequestEvent != null)
        foreach (var each in OnCancelTradeRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCancelTradeRequestEvent -= (PlayFabRequestEvent<ClientModels.CancelTradeRequest>) each;
      if (OnCancelTradeResultEvent != null)
        foreach (var each in OnCancelTradeResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCancelTradeResultEvent -= (PlayFabResultEvent<ClientModels.CancelTradeResponse>) each;

      if (OnConfirmPurchaseRequestEvent != null)
        foreach (var each in OnConfirmPurchaseRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnConfirmPurchaseRequestEvent -= (PlayFabRequestEvent<ClientModels.ConfirmPurchaseRequest>) each;
      if (OnConfirmPurchaseResultEvent != null)
        foreach (var each in OnConfirmPurchaseResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnConfirmPurchaseResultEvent -= (PlayFabResultEvent<ClientModels.ConfirmPurchaseResult>) each;

      if (OnConsumeItemRequestEvent != null)
        foreach (var each in OnConsumeItemRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnConsumeItemRequestEvent -= (PlayFabRequestEvent<ClientModels.ConsumeItemRequest>) each;
      if (OnConsumeItemResultEvent != null)
        foreach (var each in OnConsumeItemResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnConsumeItemResultEvent -= (PlayFabResultEvent<ClientModels.ConsumeItemResult>) each;

      if (OnConsumePSNEntitlementsRequestEvent != null)
        foreach (var each in OnConsumePSNEntitlementsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnConsumePSNEntitlementsRequestEvent -=
              (PlayFabRequestEvent<ClientModels.ConsumePSNEntitlementsRequest>) each;
      if (OnConsumePSNEntitlementsResultEvent != null)
        foreach (var each in OnConsumePSNEntitlementsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnConsumePSNEntitlementsResultEvent -= (PlayFabResultEvent<ClientModels.ConsumePSNEntitlementsResult>) each;

      if (OnConsumeXboxEntitlementsRequestEvent != null)
        foreach (var each in OnConsumeXboxEntitlementsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnConsumeXboxEntitlementsRequestEvent -=
              (PlayFabRequestEvent<ClientModels.ConsumeXboxEntitlementsRequest>) each;
      if (OnConsumeXboxEntitlementsResultEvent != null)
        foreach (var each in OnConsumeXboxEntitlementsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnConsumeXboxEntitlementsResultEvent -=
              (PlayFabResultEvent<ClientModels.ConsumeXboxEntitlementsResult>) each;

      if (OnCreateSharedGroupRequestEvent != null)
        foreach (var each in OnCreateSharedGroupRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCreateSharedGroupRequestEvent -= (PlayFabRequestEvent<ClientModels.CreateSharedGroupRequest>) each;
      if (OnCreateSharedGroupResultEvent != null)
        foreach (var each in OnCreateSharedGroupResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCreateSharedGroupResultEvent -= (PlayFabResultEvent<ClientModels.CreateSharedGroupResult>) each;

      if (OnExecuteCloudScriptRequestEvent != null)
        foreach (var each in OnExecuteCloudScriptRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnExecuteCloudScriptRequestEvent -= (PlayFabRequestEvent<ClientModels.ExecuteCloudScriptRequest>) each;
      if (OnExecuteCloudScriptResultEvent != null)
        foreach (var each in OnExecuteCloudScriptResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnExecuteCloudScriptResultEvent -= (PlayFabResultEvent<ClientModels.ExecuteCloudScriptResult>) each;

      if (OnGetAccountInfoRequestEvent != null)
        foreach (var each in OnGetAccountInfoRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetAccountInfoRequestEvent -= (PlayFabRequestEvent<ClientModels.GetAccountInfoRequest>) each;
      if (OnGetAccountInfoResultEvent != null)
        foreach (var each in OnGetAccountInfoResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetAccountInfoResultEvent -= (PlayFabResultEvent<ClientModels.GetAccountInfoResult>) each;

      if (OnGetAdPlacementsRequestEvent != null)
        foreach (var each in OnGetAdPlacementsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetAdPlacementsRequestEvent -= (PlayFabRequestEvent<ClientModels.GetAdPlacementsRequest>) each;
      if (OnGetAdPlacementsResultEvent != null)
        foreach (var each in OnGetAdPlacementsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetAdPlacementsResultEvent -= (PlayFabResultEvent<ClientModels.GetAdPlacementsResult>) each;

      if (OnGetAllUsersCharactersRequestEvent != null)
        foreach (var each in OnGetAllUsersCharactersRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetAllUsersCharactersRequestEvent -= (PlayFabRequestEvent<ClientModels.ListUsersCharactersRequest>) each;
      if (OnGetAllUsersCharactersResultEvent != null)
        foreach (var each in OnGetAllUsersCharactersResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetAllUsersCharactersResultEvent -= (PlayFabResultEvent<ClientModels.ListUsersCharactersResult>) each;

      if (OnGetCatalogItemsRequestEvent != null)
        foreach (var each in OnGetCatalogItemsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetCatalogItemsRequestEvent -= (PlayFabRequestEvent<ClientModels.GetCatalogItemsRequest>) each;
      if (OnGetCatalogItemsResultEvent != null)
        foreach (var each in OnGetCatalogItemsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetCatalogItemsResultEvent -= (PlayFabResultEvent<ClientModels.GetCatalogItemsResult>) each;

      if (OnGetCharacterDataRequestEvent != null)
        foreach (var each in OnGetCharacterDataRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetCharacterDataRequestEvent -= (PlayFabRequestEvent<ClientModels.GetCharacterDataRequest>) each;
      if (OnGetCharacterDataResultEvent != null)
        foreach (var each in OnGetCharacterDataResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetCharacterDataResultEvent -= (PlayFabResultEvent<ClientModels.GetCharacterDataResult>) each;

      if (OnGetCharacterInventoryRequestEvent != null)
        foreach (var each in OnGetCharacterInventoryRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetCharacterInventoryRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetCharacterInventoryRequest>) each;
      if (OnGetCharacterInventoryResultEvent != null)
        foreach (var each in OnGetCharacterInventoryResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetCharacterInventoryResultEvent -= (PlayFabResultEvent<ClientModels.GetCharacterInventoryResult>) each;

      if (OnGetCharacterLeaderboardRequestEvent != null)
        foreach (var each in OnGetCharacterLeaderboardRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetCharacterLeaderboardRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetCharacterLeaderboardRequest>) each;
      if (OnGetCharacterLeaderboardResultEvent != null)
        foreach (var each in OnGetCharacterLeaderboardResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetCharacterLeaderboardResultEvent -=
              (PlayFabResultEvent<ClientModels.GetCharacterLeaderboardResult>) each;

      if (OnGetCharacterReadOnlyDataRequestEvent != null)
        foreach (var each in OnGetCharacterReadOnlyDataRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetCharacterReadOnlyDataRequestEvent -= (PlayFabRequestEvent<ClientModels.GetCharacterDataRequest>) each;
      if (OnGetCharacterReadOnlyDataResultEvent != null)
        foreach (var each in OnGetCharacterReadOnlyDataResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetCharacterReadOnlyDataResultEvent -= (PlayFabResultEvent<ClientModels.GetCharacterDataResult>) each;

      if (OnGetCharacterStatisticsRequestEvent != null)
        foreach (var each in OnGetCharacterStatisticsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetCharacterStatisticsRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetCharacterStatisticsRequest>) each;
      if (OnGetCharacterStatisticsResultEvent != null)
        foreach (var each in OnGetCharacterStatisticsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetCharacterStatisticsResultEvent -= (PlayFabResultEvent<ClientModels.GetCharacterStatisticsResult>) each;

      if (OnGetContentDownloadUrlRequestEvent != null)
        foreach (var each in OnGetContentDownloadUrlRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetContentDownloadUrlRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetContentDownloadUrlRequest>) each;
      if (OnGetContentDownloadUrlResultEvent != null)
        foreach (var each in OnGetContentDownloadUrlResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetContentDownloadUrlResultEvent -= (PlayFabResultEvent<ClientModels.GetContentDownloadUrlResult>) each;

      if (OnGetCurrentGamesRequestEvent != null)
        foreach (var each in OnGetCurrentGamesRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetCurrentGamesRequestEvent -= (PlayFabRequestEvent<ClientModels.CurrentGamesRequest>) each;
      if (OnGetCurrentGamesResultEvent != null)
        foreach (var each in OnGetCurrentGamesResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetCurrentGamesResultEvent -= (PlayFabResultEvent<ClientModels.CurrentGamesResult>) each;

      if (OnGetFriendLeaderboardRequestEvent != null)
        foreach (var each in OnGetFriendLeaderboardRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetFriendLeaderboardRequestEvent -= (PlayFabRequestEvent<ClientModels.GetFriendLeaderboardRequest>) each;
      if (OnGetFriendLeaderboardResultEvent != null)
        foreach (var each in OnGetFriendLeaderboardResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetFriendLeaderboardResultEvent -= (PlayFabResultEvent<ClientModels.GetLeaderboardResult>) each;

      if (OnGetFriendLeaderboardAroundPlayerRequestEvent != null)
        foreach (var each in OnGetFriendLeaderboardAroundPlayerRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetFriendLeaderboardAroundPlayerRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetFriendLeaderboardAroundPlayerRequest>) each;
      if (OnGetFriendLeaderboardAroundPlayerResultEvent != null)
        foreach (var each in OnGetFriendLeaderboardAroundPlayerResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetFriendLeaderboardAroundPlayerResultEvent -=
              (PlayFabResultEvent<ClientModels.GetFriendLeaderboardAroundPlayerResult>) each;

      if (OnGetFriendsListRequestEvent != null)
        foreach (var each in OnGetFriendsListRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetFriendsListRequestEvent -= (PlayFabRequestEvent<ClientModels.GetFriendsListRequest>) each;
      if (OnGetFriendsListResultEvent != null)
        foreach (var each in OnGetFriendsListResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetFriendsListResultEvent -= (PlayFabResultEvent<ClientModels.GetFriendsListResult>) each;

      if (OnGetGameServerRegionsRequestEvent != null)
        foreach (var each in OnGetGameServerRegionsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetGameServerRegionsRequestEvent -= (PlayFabRequestEvent<ClientModels.GameServerRegionsRequest>) each;
      if (OnGetGameServerRegionsResultEvent != null)
        foreach (var each in OnGetGameServerRegionsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetGameServerRegionsResultEvent -= (PlayFabResultEvent<ClientModels.GameServerRegionsResult>) each;

      if (OnGetLeaderboardRequestEvent != null)
        foreach (var each in OnGetLeaderboardRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetLeaderboardRequestEvent -= (PlayFabRequestEvent<ClientModels.GetLeaderboardRequest>) each;
      if (OnGetLeaderboardResultEvent != null)
        foreach (var each in OnGetLeaderboardResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetLeaderboardResultEvent -= (PlayFabResultEvent<ClientModels.GetLeaderboardResult>) each;

      if (OnGetLeaderboardAroundCharacterRequestEvent != null)
        foreach (var each in OnGetLeaderboardAroundCharacterRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetLeaderboardAroundCharacterRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetLeaderboardAroundCharacterRequest>) each;
      if (OnGetLeaderboardAroundCharacterResultEvent != null)
        foreach (var each in OnGetLeaderboardAroundCharacterResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetLeaderboardAroundCharacterResultEvent -=
              (PlayFabResultEvent<ClientModels.GetLeaderboardAroundCharacterResult>) each;

      if (OnGetLeaderboardAroundPlayerRequestEvent != null)
        foreach (var each in OnGetLeaderboardAroundPlayerRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetLeaderboardAroundPlayerRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetLeaderboardAroundPlayerRequest>) each;
      if (OnGetLeaderboardAroundPlayerResultEvent != null)
        foreach (var each in OnGetLeaderboardAroundPlayerResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetLeaderboardAroundPlayerResultEvent -=
              (PlayFabResultEvent<ClientModels.GetLeaderboardAroundPlayerResult>) each;

      if (OnGetLeaderboardForUserCharactersRequestEvent != null)
        foreach (var each in OnGetLeaderboardForUserCharactersRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetLeaderboardForUserCharactersRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetLeaderboardForUsersCharactersRequest>) each;
      if (OnGetLeaderboardForUserCharactersResultEvent != null)
        foreach (var each in OnGetLeaderboardForUserCharactersResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetLeaderboardForUserCharactersResultEvent -=
              (PlayFabResultEvent<ClientModels.GetLeaderboardForUsersCharactersResult>) each;

      if (OnGetPaymentTokenRequestEvent != null)
        foreach (var each in OnGetPaymentTokenRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPaymentTokenRequestEvent -= (PlayFabRequestEvent<ClientModels.GetPaymentTokenRequest>) each;
      if (OnGetPaymentTokenResultEvent != null)
        foreach (var each in OnGetPaymentTokenResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPaymentTokenResultEvent -= (PlayFabResultEvent<ClientModels.GetPaymentTokenResult>) each;

      if (OnGetPhotonAuthenticationTokenRequestEvent != null)
        foreach (var each in OnGetPhotonAuthenticationTokenRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPhotonAuthenticationTokenRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetPhotonAuthenticationTokenRequest>) each;
      if (OnGetPhotonAuthenticationTokenResultEvent != null)
        foreach (var each in OnGetPhotonAuthenticationTokenResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPhotonAuthenticationTokenResultEvent -=
              (PlayFabResultEvent<ClientModels.GetPhotonAuthenticationTokenResult>) each;

      if (OnGetPlayerCombinedInfoRequestEvent != null)
        foreach (var each in OnGetPlayerCombinedInfoRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayerCombinedInfoRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetPlayerCombinedInfoRequest>) each;
      if (OnGetPlayerCombinedInfoResultEvent != null)
        foreach (var each in OnGetPlayerCombinedInfoResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayerCombinedInfoResultEvent -= (PlayFabResultEvent<ClientModels.GetPlayerCombinedInfoResult>) each;

      if (OnGetPlayerProfileRequestEvent != null)
        foreach (var each in OnGetPlayerProfileRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayerProfileRequestEvent -= (PlayFabRequestEvent<ClientModels.GetPlayerProfileRequest>) each;
      if (OnGetPlayerProfileResultEvent != null)
        foreach (var each in OnGetPlayerProfileResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayerProfileResultEvent -= (PlayFabResultEvent<ClientModels.GetPlayerProfileResult>) each;

      if (OnGetPlayerSegmentsRequestEvent != null)
        foreach (var each in OnGetPlayerSegmentsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayerSegmentsRequestEvent -= (PlayFabRequestEvent<ClientModels.GetPlayerSegmentsRequest>) each;
      if (OnGetPlayerSegmentsResultEvent != null)
        foreach (var each in OnGetPlayerSegmentsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayerSegmentsResultEvent -= (PlayFabResultEvent<ClientModels.GetPlayerSegmentsResult>) each;

      if (OnGetPlayerStatisticsRequestEvent != null)
        foreach (var each in OnGetPlayerStatisticsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayerStatisticsRequestEvent -= (PlayFabRequestEvent<ClientModels.GetPlayerStatisticsRequest>) each;
      if (OnGetPlayerStatisticsResultEvent != null)
        foreach (var each in OnGetPlayerStatisticsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayerStatisticsResultEvent -= (PlayFabResultEvent<ClientModels.GetPlayerStatisticsResult>) each;

      if (OnGetPlayerStatisticVersionsRequestEvent != null)
        foreach (var each in OnGetPlayerStatisticVersionsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayerStatisticVersionsRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetPlayerStatisticVersionsRequest>) each;
      if (OnGetPlayerStatisticVersionsResultEvent != null)
        foreach (var each in OnGetPlayerStatisticVersionsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayerStatisticVersionsResultEvent -=
              (PlayFabResultEvent<ClientModels.GetPlayerStatisticVersionsResult>) each;

      if (OnGetPlayerTagsRequestEvent != null)
        foreach (var each in OnGetPlayerTagsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayerTagsRequestEvent -= (PlayFabRequestEvent<ClientModels.GetPlayerTagsRequest>) each;
      if (OnGetPlayerTagsResultEvent != null)
        foreach (var each in OnGetPlayerTagsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayerTagsResultEvent -= (PlayFabResultEvent<ClientModels.GetPlayerTagsResult>) each;

      if (OnGetPlayerTradesRequestEvent != null)
        foreach (var each in OnGetPlayerTradesRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayerTradesRequestEvent -= (PlayFabRequestEvent<ClientModels.GetPlayerTradesRequest>) each;
      if (OnGetPlayerTradesResultEvent != null)
        foreach (var each in OnGetPlayerTradesResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayerTradesResultEvent -= (PlayFabResultEvent<ClientModels.GetPlayerTradesResponse>) each;

      if (OnGetPlayFabIDsFromFacebookIDsRequestEvent != null)
        foreach (var each in OnGetPlayFabIDsFromFacebookIDsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayFabIDsFromFacebookIDsRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetPlayFabIDsFromFacebookIDsRequest>) each;
      if (OnGetPlayFabIDsFromFacebookIDsResultEvent != null)
        foreach (var each in OnGetPlayFabIDsFromFacebookIDsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayFabIDsFromFacebookIDsResultEvent -=
              (PlayFabResultEvent<ClientModels.GetPlayFabIDsFromFacebookIDsResult>) each;

      if (OnGetPlayFabIDsFromFacebookInstantGamesIdsRequestEvent != null)
        foreach (var each in OnGetPlayFabIDsFromFacebookInstantGamesIdsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayFabIDsFromFacebookInstantGamesIdsRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetPlayFabIDsFromFacebookInstantGamesIdsRequest>) each;
      if (OnGetPlayFabIDsFromFacebookInstantGamesIdsResultEvent != null)
        foreach (var each in OnGetPlayFabIDsFromFacebookInstantGamesIdsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayFabIDsFromFacebookInstantGamesIdsResultEvent -=
              (PlayFabResultEvent<ClientModels.GetPlayFabIDsFromFacebookInstantGamesIdsResult>) each;

      if (OnGetPlayFabIDsFromGameCenterIDsRequestEvent != null)
        foreach (var each in OnGetPlayFabIDsFromGameCenterIDsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayFabIDsFromGameCenterIDsRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetPlayFabIDsFromGameCenterIDsRequest>) each;
      if (OnGetPlayFabIDsFromGameCenterIDsResultEvent != null)
        foreach (var each in OnGetPlayFabIDsFromGameCenterIDsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayFabIDsFromGameCenterIDsResultEvent -=
              (PlayFabResultEvent<ClientModels.GetPlayFabIDsFromGameCenterIDsResult>) each;

      if (OnGetPlayFabIDsFromGenericIDsRequestEvent != null)
        foreach (var each in OnGetPlayFabIDsFromGenericIDsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayFabIDsFromGenericIDsRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetPlayFabIDsFromGenericIDsRequest>) each;
      if (OnGetPlayFabIDsFromGenericIDsResultEvent != null)
        foreach (var each in OnGetPlayFabIDsFromGenericIDsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayFabIDsFromGenericIDsResultEvent -=
              (PlayFabResultEvent<ClientModels.GetPlayFabIDsFromGenericIDsResult>) each;

      if (OnGetPlayFabIDsFromGoogleIDsRequestEvent != null)
        foreach (var each in OnGetPlayFabIDsFromGoogleIDsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayFabIDsFromGoogleIDsRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetPlayFabIDsFromGoogleIDsRequest>) each;
      if (OnGetPlayFabIDsFromGoogleIDsResultEvent != null)
        foreach (var each in OnGetPlayFabIDsFromGoogleIDsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayFabIDsFromGoogleIDsResultEvent -=
              (PlayFabResultEvent<ClientModels.GetPlayFabIDsFromGoogleIDsResult>) each;

      if (OnGetPlayFabIDsFromKongregateIDsRequestEvent != null)
        foreach (var each in OnGetPlayFabIDsFromKongregateIDsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayFabIDsFromKongregateIDsRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetPlayFabIDsFromKongregateIDsRequest>) each;
      if (OnGetPlayFabIDsFromKongregateIDsResultEvent != null)
        foreach (var each in OnGetPlayFabIDsFromKongregateIDsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayFabIDsFromKongregateIDsResultEvent -=
              (PlayFabResultEvent<ClientModels.GetPlayFabIDsFromKongregateIDsResult>) each;

      if (OnGetPlayFabIDsFromNintendoSwitchDeviceIdsRequestEvent != null)
        foreach (var each in OnGetPlayFabIDsFromNintendoSwitchDeviceIdsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayFabIDsFromNintendoSwitchDeviceIdsRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetPlayFabIDsFromNintendoSwitchDeviceIdsRequest>) each;
      if (OnGetPlayFabIDsFromNintendoSwitchDeviceIdsResultEvent != null)
        foreach (var each in OnGetPlayFabIDsFromNintendoSwitchDeviceIdsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayFabIDsFromNintendoSwitchDeviceIdsResultEvent -=
              (PlayFabResultEvent<ClientModels.GetPlayFabIDsFromNintendoSwitchDeviceIdsResult>) each;

      if (OnGetPlayFabIDsFromPSNAccountIDsRequestEvent != null)
        foreach (var each in OnGetPlayFabIDsFromPSNAccountIDsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayFabIDsFromPSNAccountIDsRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetPlayFabIDsFromPSNAccountIDsRequest>) each;
      if (OnGetPlayFabIDsFromPSNAccountIDsResultEvent != null)
        foreach (var each in OnGetPlayFabIDsFromPSNAccountIDsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayFabIDsFromPSNAccountIDsResultEvent -=
              (PlayFabResultEvent<ClientModels.GetPlayFabIDsFromPSNAccountIDsResult>) each;

      if (OnGetPlayFabIDsFromSteamIDsRequestEvent != null)
        foreach (var each in OnGetPlayFabIDsFromSteamIDsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayFabIDsFromSteamIDsRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetPlayFabIDsFromSteamIDsRequest>) each;
      if (OnGetPlayFabIDsFromSteamIDsResultEvent != null)
        foreach (var each in OnGetPlayFabIDsFromSteamIDsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayFabIDsFromSteamIDsResultEvent -=
              (PlayFabResultEvent<ClientModels.GetPlayFabIDsFromSteamIDsResult>) each;

      if (OnGetPlayFabIDsFromTwitchIDsRequestEvent != null)
        foreach (var each in OnGetPlayFabIDsFromTwitchIDsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayFabIDsFromTwitchIDsRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetPlayFabIDsFromTwitchIDsRequest>) each;
      if (OnGetPlayFabIDsFromTwitchIDsResultEvent != null)
        foreach (var each in OnGetPlayFabIDsFromTwitchIDsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayFabIDsFromTwitchIDsResultEvent -=
              (PlayFabResultEvent<ClientModels.GetPlayFabIDsFromTwitchIDsResult>) each;

      if (OnGetPlayFabIDsFromXboxLiveIDsRequestEvent != null)
        foreach (var each in OnGetPlayFabIDsFromXboxLiveIDsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayFabIDsFromXboxLiveIDsRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetPlayFabIDsFromXboxLiveIDsRequest>) each;
      if (OnGetPlayFabIDsFromXboxLiveIDsResultEvent != null)
        foreach (var each in OnGetPlayFabIDsFromXboxLiveIDsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPlayFabIDsFromXboxLiveIDsResultEvent -=
              (PlayFabResultEvent<ClientModels.GetPlayFabIDsFromXboxLiveIDsResult>) each;

      if (OnGetPublisherDataRequestEvent != null)
        foreach (var each in OnGetPublisherDataRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPublisherDataRequestEvent -= (PlayFabRequestEvent<ClientModels.GetPublisherDataRequest>) each;
      if (OnGetPublisherDataResultEvent != null)
        foreach (var each in OnGetPublisherDataResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPublisherDataResultEvent -= (PlayFabResultEvent<ClientModels.GetPublisherDataResult>) each;

      if (OnGetPurchaseRequestEvent != null)
        foreach (var each in OnGetPurchaseRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPurchaseRequestEvent -= (PlayFabRequestEvent<ClientModels.GetPurchaseRequest>) each;
      if (OnGetPurchaseResultEvent != null)
        foreach (var each in OnGetPurchaseResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetPurchaseResultEvent -= (PlayFabResultEvent<ClientModels.GetPurchaseResult>) each;

      if (OnGetSharedGroupDataRequestEvent != null)
        foreach (var each in OnGetSharedGroupDataRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetSharedGroupDataRequestEvent -= (PlayFabRequestEvent<ClientModels.GetSharedGroupDataRequest>) each;
      if (OnGetSharedGroupDataResultEvent != null)
        foreach (var each in OnGetSharedGroupDataResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetSharedGroupDataResultEvent -= (PlayFabResultEvent<ClientModels.GetSharedGroupDataResult>) each;

      if (OnGetStoreItemsRequestEvent != null)
        foreach (var each in OnGetStoreItemsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetStoreItemsRequestEvent -= (PlayFabRequestEvent<ClientModels.GetStoreItemsRequest>) each;
      if (OnGetStoreItemsResultEvent != null)
        foreach (var each in OnGetStoreItemsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetStoreItemsResultEvent -= (PlayFabResultEvent<ClientModels.GetStoreItemsResult>) each;

      if (OnGetTimeRequestEvent != null)
        foreach (var each in OnGetTimeRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetTimeRequestEvent -= (PlayFabRequestEvent<ClientModels.GetTimeRequest>) each;
      if (OnGetTimeResultEvent != null)
        foreach (var each in OnGetTimeResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetTimeResultEvent -= (PlayFabResultEvent<ClientModels.GetTimeResult>) each;

      if (OnGetTitleDataRequestEvent != null)
        foreach (var each in OnGetTitleDataRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetTitleDataRequestEvent -= (PlayFabRequestEvent<ClientModels.GetTitleDataRequest>) each;
      if (OnGetTitleDataResultEvent != null)
        foreach (var each in OnGetTitleDataResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetTitleDataResultEvent -= (PlayFabResultEvent<ClientModels.GetTitleDataResult>) each;

      if (OnGetTitleNewsRequestEvent != null)
        foreach (var each in OnGetTitleNewsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetTitleNewsRequestEvent -= (PlayFabRequestEvent<ClientModels.GetTitleNewsRequest>) each;
      if (OnGetTitleNewsResultEvent != null)
        foreach (var each in OnGetTitleNewsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetTitleNewsResultEvent -= (PlayFabResultEvent<ClientModels.GetTitleNewsResult>) each;

      if (OnGetTitlePublicKeyRequestEvent != null)
        foreach (var each in OnGetTitlePublicKeyRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetTitlePublicKeyRequestEvent -= (PlayFabRequestEvent<ClientModels.GetTitlePublicKeyRequest>) each;
      if (OnGetTitlePublicKeyResultEvent != null)
        foreach (var each in OnGetTitlePublicKeyResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetTitlePublicKeyResultEvent -= (PlayFabResultEvent<ClientModels.GetTitlePublicKeyResult>) each;

      if (OnGetTradeStatusRequestEvent != null)
        foreach (var each in OnGetTradeStatusRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetTradeStatusRequestEvent -= (PlayFabRequestEvent<ClientModels.GetTradeStatusRequest>) each;
      if (OnGetTradeStatusResultEvent != null)
        foreach (var each in OnGetTradeStatusResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetTradeStatusResultEvent -= (PlayFabResultEvent<ClientModels.GetTradeStatusResponse>) each;

      if (OnGetUserDataRequestEvent != null)
        foreach (var each in OnGetUserDataRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetUserDataRequestEvent -= (PlayFabRequestEvent<ClientModels.GetUserDataRequest>) each;
      if (OnGetUserDataResultEvent != null)
        foreach (var each in OnGetUserDataResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetUserDataResultEvent -= (PlayFabResultEvent<ClientModels.GetUserDataResult>) each;

      if (OnGetUserInventoryRequestEvent != null)
        foreach (var each in OnGetUserInventoryRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetUserInventoryRequestEvent -= (PlayFabRequestEvent<ClientModels.GetUserInventoryRequest>) each;
      if (OnGetUserInventoryResultEvent != null)
        foreach (var each in OnGetUserInventoryResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetUserInventoryResultEvent -= (PlayFabResultEvent<ClientModels.GetUserInventoryResult>) each;

      if (OnGetUserPublisherDataRequestEvent != null)
        foreach (var each in OnGetUserPublisherDataRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetUserPublisherDataRequestEvent -= (PlayFabRequestEvent<ClientModels.GetUserDataRequest>) each;
      if (OnGetUserPublisherDataResultEvent != null)
        foreach (var each in OnGetUserPublisherDataResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetUserPublisherDataResultEvent -= (PlayFabResultEvent<ClientModels.GetUserDataResult>) each;

      if (OnGetUserPublisherReadOnlyDataRequestEvent != null)
        foreach (var each in OnGetUserPublisherReadOnlyDataRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetUserPublisherReadOnlyDataRequestEvent -= (PlayFabRequestEvent<ClientModels.GetUserDataRequest>) each;
      if (OnGetUserPublisherReadOnlyDataResultEvent != null)
        foreach (var each in OnGetUserPublisherReadOnlyDataResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetUserPublisherReadOnlyDataResultEvent -= (PlayFabResultEvent<ClientModels.GetUserDataResult>) each;

      if (OnGetUserReadOnlyDataRequestEvent != null)
        foreach (var each in OnGetUserReadOnlyDataRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetUserReadOnlyDataRequestEvent -= (PlayFabRequestEvent<ClientModels.GetUserDataRequest>) each;
      if (OnGetUserReadOnlyDataResultEvent != null)
        foreach (var each in OnGetUserReadOnlyDataResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetUserReadOnlyDataResultEvent -= (PlayFabResultEvent<ClientModels.GetUserDataResult>) each;

      if (OnGetWindowsHelloChallengeRequestEvent != null)
        foreach (var each in OnGetWindowsHelloChallengeRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetWindowsHelloChallengeRequestEvent -=
              (PlayFabRequestEvent<ClientModels.GetWindowsHelloChallengeRequest>) each;
      if (OnGetWindowsHelloChallengeResultEvent != null)
        foreach (var each in OnGetWindowsHelloChallengeResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGetWindowsHelloChallengeResultEvent -=
              (PlayFabResultEvent<ClientModels.GetWindowsHelloChallengeResponse>) each;

      if (OnGrantCharacterToUserRequestEvent != null)
        foreach (var each in OnGrantCharacterToUserRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGrantCharacterToUserRequestEvent -= (PlayFabRequestEvent<ClientModels.GrantCharacterToUserRequest>) each;
      if (OnGrantCharacterToUserResultEvent != null)
        foreach (var each in OnGrantCharacterToUserResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGrantCharacterToUserResultEvent -= (PlayFabResultEvent<ClientModels.GrantCharacterToUserResult>) each;

      if (OnLinkAndroidDeviceIDRequestEvent != null)
        foreach (var each in OnLinkAndroidDeviceIDRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkAndroidDeviceIDRequestEvent -= (PlayFabRequestEvent<ClientModels.LinkAndroidDeviceIDRequest>) each;
      if (OnLinkAndroidDeviceIDResultEvent != null)
        foreach (var each in OnLinkAndroidDeviceIDResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkAndroidDeviceIDResultEvent -= (PlayFabResultEvent<ClientModels.LinkAndroidDeviceIDResult>) each;

      if (OnLinkAppleRequestEvent != null)
        foreach (var each in OnLinkAppleRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkAppleRequestEvent -= (PlayFabRequestEvent<ClientModels.LinkAppleRequest>) each;
      if (OnLinkAppleResultEvent != null)
        foreach (var each in OnLinkAppleResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkAppleResultEvent -= (PlayFabResultEvent<ClientModels.EmptyResult>) each;

      if (OnLinkCustomIDRequestEvent != null)
        foreach (var each in OnLinkCustomIDRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkCustomIDRequestEvent -= (PlayFabRequestEvent<ClientModels.LinkCustomIDRequest>) each;
      if (OnLinkCustomIDResultEvent != null)
        foreach (var each in OnLinkCustomIDResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkCustomIDResultEvent -= (PlayFabResultEvent<ClientModels.LinkCustomIDResult>) each;

      if (OnLinkFacebookAccountRequestEvent != null)
        foreach (var each in OnLinkFacebookAccountRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkFacebookAccountRequestEvent -= (PlayFabRequestEvent<ClientModels.LinkFacebookAccountRequest>) each;
      if (OnLinkFacebookAccountResultEvent != null)
        foreach (var each in OnLinkFacebookAccountResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkFacebookAccountResultEvent -= (PlayFabResultEvent<ClientModels.LinkFacebookAccountResult>) each;

      if (OnLinkFacebookInstantGamesIdRequestEvent != null)
        foreach (var each in OnLinkFacebookInstantGamesIdRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkFacebookInstantGamesIdRequestEvent -=
              (PlayFabRequestEvent<ClientModels.LinkFacebookInstantGamesIdRequest>) each;
      if (OnLinkFacebookInstantGamesIdResultEvent != null)
        foreach (var each in OnLinkFacebookInstantGamesIdResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkFacebookInstantGamesIdResultEvent -=
              (PlayFabResultEvent<ClientModels.LinkFacebookInstantGamesIdResult>) each;

      if (OnLinkGameCenterAccountRequestEvent != null)
        foreach (var each in OnLinkGameCenterAccountRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkGameCenterAccountRequestEvent -=
              (PlayFabRequestEvent<ClientModels.LinkGameCenterAccountRequest>) each;
      if (OnLinkGameCenterAccountResultEvent != null)
        foreach (var each in OnLinkGameCenterAccountResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkGameCenterAccountResultEvent -= (PlayFabResultEvent<ClientModels.LinkGameCenterAccountResult>) each;

      if (OnLinkGoogleAccountRequestEvent != null)
        foreach (var each in OnLinkGoogleAccountRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkGoogleAccountRequestEvent -= (PlayFabRequestEvent<ClientModels.LinkGoogleAccountRequest>) each;
      if (OnLinkGoogleAccountResultEvent != null)
        foreach (var each in OnLinkGoogleAccountResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkGoogleAccountResultEvent -= (PlayFabResultEvent<ClientModels.LinkGoogleAccountResult>) each;

      if (OnLinkIOSDeviceIDRequestEvent != null)
        foreach (var each in OnLinkIOSDeviceIDRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkIOSDeviceIDRequestEvent -= (PlayFabRequestEvent<ClientModels.LinkIOSDeviceIDRequest>) each;
      if (OnLinkIOSDeviceIDResultEvent != null)
        foreach (var each in OnLinkIOSDeviceIDResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkIOSDeviceIDResultEvent -= (PlayFabResultEvent<ClientModels.LinkIOSDeviceIDResult>) each;

      if (OnLinkKongregateRequestEvent != null)
        foreach (var each in OnLinkKongregateRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkKongregateRequestEvent -= (PlayFabRequestEvent<ClientModels.LinkKongregateAccountRequest>) each;
      if (OnLinkKongregateResultEvent != null)
        foreach (var each in OnLinkKongregateResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkKongregateResultEvent -= (PlayFabResultEvent<ClientModels.LinkKongregateAccountResult>) each;

      if (OnLinkNintendoAccountRequestEvent != null)
        foreach (var each in OnLinkNintendoAccountRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkNintendoAccountRequestEvent -= (PlayFabRequestEvent<ClientModels.LinkNintendoAccountRequest>) each;
      if (OnLinkNintendoAccountResultEvent != null)
        foreach (var each in OnLinkNintendoAccountResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkNintendoAccountResultEvent -= (PlayFabResultEvent<ClientModels.EmptyResult>) each;

      if (OnLinkNintendoSwitchDeviceIdRequestEvent != null)
        foreach (var each in OnLinkNintendoSwitchDeviceIdRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkNintendoSwitchDeviceIdRequestEvent -=
              (PlayFabRequestEvent<ClientModels.LinkNintendoSwitchDeviceIdRequest>) each;
      if (OnLinkNintendoSwitchDeviceIdResultEvent != null)
        foreach (var each in OnLinkNintendoSwitchDeviceIdResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkNintendoSwitchDeviceIdResultEvent -=
              (PlayFabResultEvent<ClientModels.LinkNintendoSwitchDeviceIdResult>) each;

      if (OnLinkOpenIdConnectRequestEvent != null)
        foreach (var each in OnLinkOpenIdConnectRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkOpenIdConnectRequestEvent -= (PlayFabRequestEvent<ClientModels.LinkOpenIdConnectRequest>) each;
      if (OnLinkOpenIdConnectResultEvent != null)
        foreach (var each in OnLinkOpenIdConnectResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkOpenIdConnectResultEvent -= (PlayFabResultEvent<ClientModels.EmptyResult>) each;

      if (OnLinkPSNAccountRequestEvent != null)
        foreach (var each in OnLinkPSNAccountRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkPSNAccountRequestEvent -= (PlayFabRequestEvent<ClientModels.LinkPSNAccountRequest>) each;
      if (OnLinkPSNAccountResultEvent != null)
        foreach (var each in OnLinkPSNAccountResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkPSNAccountResultEvent -= (PlayFabResultEvent<ClientModels.LinkPSNAccountResult>) each;

      if (OnLinkSteamAccountRequestEvent != null)
        foreach (var each in OnLinkSteamAccountRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkSteamAccountRequestEvent -= (PlayFabRequestEvent<ClientModels.LinkSteamAccountRequest>) each;
      if (OnLinkSteamAccountResultEvent != null)
        foreach (var each in OnLinkSteamAccountResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkSteamAccountResultEvent -= (PlayFabResultEvent<ClientModels.LinkSteamAccountResult>) each;

      if (OnLinkTwitchRequestEvent != null)
        foreach (var each in OnLinkTwitchRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkTwitchRequestEvent -= (PlayFabRequestEvent<ClientModels.LinkTwitchAccountRequest>) each;
      if (OnLinkTwitchResultEvent != null)
        foreach (var each in OnLinkTwitchResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkTwitchResultEvent -= (PlayFabResultEvent<ClientModels.LinkTwitchAccountResult>) each;

      if (OnLinkWindowsHelloRequestEvent != null)
        foreach (var each in OnLinkWindowsHelloRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkWindowsHelloRequestEvent -= (PlayFabRequestEvent<ClientModels.LinkWindowsHelloAccountRequest>) each;
      if (OnLinkWindowsHelloResultEvent != null)
        foreach (var each in OnLinkWindowsHelloResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkWindowsHelloResultEvent -= (PlayFabResultEvent<ClientModels.LinkWindowsHelloAccountResponse>) each;

      if (OnLinkXboxAccountRequestEvent != null)
        foreach (var each in OnLinkXboxAccountRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkXboxAccountRequestEvent -= (PlayFabRequestEvent<ClientModels.LinkXboxAccountRequest>) each;
      if (OnLinkXboxAccountResultEvent != null)
        foreach (var each in OnLinkXboxAccountResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLinkXboxAccountResultEvent -= (PlayFabResultEvent<ClientModels.LinkXboxAccountResult>) each;

      if (OnLoginWithAndroidDeviceIDRequestEvent != null)
        foreach (var each in OnLoginWithAndroidDeviceIDRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLoginWithAndroidDeviceIDRequestEvent -=
              (PlayFabRequestEvent<ClientModels.LoginWithAndroidDeviceIDRequest>) each;

      if (OnLoginWithAppleRequestEvent != null)
        foreach (var each in OnLoginWithAppleRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLoginWithAppleRequestEvent -= (PlayFabRequestEvent<ClientModels.LoginWithAppleRequest>) each;

      if (OnLoginWithCustomIDRequestEvent != null)
        foreach (var each in OnLoginWithCustomIDRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLoginWithCustomIDRequestEvent -= (PlayFabRequestEvent<ClientModels.LoginWithCustomIDRequest>) each;

      if (OnLoginWithEmailAddressRequestEvent != null)
        foreach (var each in OnLoginWithEmailAddressRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLoginWithEmailAddressRequestEvent -=
              (PlayFabRequestEvent<ClientModels.LoginWithEmailAddressRequest>) each;

      if (OnLoginWithFacebookRequestEvent != null)
        foreach (var each in OnLoginWithFacebookRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLoginWithFacebookRequestEvent -= (PlayFabRequestEvent<ClientModels.LoginWithFacebookRequest>) each;

      if (OnLoginWithFacebookInstantGamesIdRequestEvent != null)
        foreach (var each in OnLoginWithFacebookInstantGamesIdRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLoginWithFacebookInstantGamesIdRequestEvent -=
              (PlayFabRequestEvent<ClientModels.LoginWithFacebookInstantGamesIdRequest>) each;

      if (OnLoginWithGameCenterRequestEvent != null)
        foreach (var each in OnLoginWithGameCenterRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLoginWithGameCenterRequestEvent -= (PlayFabRequestEvent<ClientModels.LoginWithGameCenterRequest>) each;

      if (OnLoginWithGoogleAccountRequestEvent != null)
        foreach (var each in OnLoginWithGoogleAccountRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLoginWithGoogleAccountRequestEvent -=
              (PlayFabRequestEvent<ClientModels.LoginWithGoogleAccountRequest>) each;

      if (OnLoginWithIOSDeviceIDRequestEvent != null)
        foreach (var each in OnLoginWithIOSDeviceIDRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLoginWithIOSDeviceIDRequestEvent -= (PlayFabRequestEvent<ClientModels.LoginWithIOSDeviceIDRequest>) each;

      if (OnLoginWithKongregateRequestEvent != null)
        foreach (var each in OnLoginWithKongregateRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLoginWithKongregateRequestEvent -= (PlayFabRequestEvent<ClientModels.LoginWithKongregateRequest>) each;

      if (OnLoginWithNintendoAccountRequestEvent != null)
        foreach (var each in OnLoginWithNintendoAccountRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLoginWithNintendoAccountRequestEvent -=
              (PlayFabRequestEvent<ClientModels.LoginWithNintendoAccountRequest>) each;

      if (OnLoginWithNintendoSwitchDeviceIdRequestEvent != null)
        foreach (var each in OnLoginWithNintendoSwitchDeviceIdRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLoginWithNintendoSwitchDeviceIdRequestEvent -=
              (PlayFabRequestEvent<ClientModels.LoginWithNintendoSwitchDeviceIdRequest>) each;

      if (OnLoginWithOpenIdConnectRequestEvent != null)
        foreach (var each in OnLoginWithOpenIdConnectRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLoginWithOpenIdConnectRequestEvent -=
              (PlayFabRequestEvent<ClientModels.LoginWithOpenIdConnectRequest>) each;

      if (OnLoginWithPlayFabRequestEvent != null)
        foreach (var each in OnLoginWithPlayFabRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLoginWithPlayFabRequestEvent -= (PlayFabRequestEvent<ClientModels.LoginWithPlayFabRequest>) each;

      if (OnLoginWithPSNRequestEvent != null)
        foreach (var each in OnLoginWithPSNRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLoginWithPSNRequestEvent -= (PlayFabRequestEvent<ClientModels.LoginWithPSNRequest>) each;

      if (OnLoginWithSteamRequestEvent != null)
        foreach (var each in OnLoginWithSteamRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLoginWithSteamRequestEvent -= (PlayFabRequestEvent<ClientModels.LoginWithSteamRequest>) each;

      if (OnLoginWithTwitchRequestEvent != null)
        foreach (var each in OnLoginWithTwitchRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLoginWithTwitchRequestEvent -= (PlayFabRequestEvent<ClientModels.LoginWithTwitchRequest>) each;

      if (OnLoginWithWindowsHelloRequestEvent != null)
        foreach (var each in OnLoginWithWindowsHelloRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLoginWithWindowsHelloRequestEvent -=
              (PlayFabRequestEvent<ClientModels.LoginWithWindowsHelloRequest>) each;

      if (OnLoginWithXboxRequestEvent != null)
        foreach (var each in OnLoginWithXboxRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLoginWithXboxRequestEvent -= (PlayFabRequestEvent<ClientModels.LoginWithXboxRequest>) each;

      if (OnMatchmakeRequestEvent != null)
        foreach (var each in OnMatchmakeRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMatchmakeRequestEvent -= (PlayFabRequestEvent<ClientModels.MatchmakeRequest>) each;
      if (OnMatchmakeResultEvent != null)
        foreach (var each in OnMatchmakeResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMatchmakeResultEvent -= (PlayFabResultEvent<ClientModels.MatchmakeResult>) each;

      if (OnOpenTradeRequestEvent != null)
        foreach (var each in OnOpenTradeRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnOpenTradeRequestEvent -= (PlayFabRequestEvent<ClientModels.OpenTradeRequest>) each;
      if (OnOpenTradeResultEvent != null)
        foreach (var each in OnOpenTradeResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnOpenTradeResultEvent -= (PlayFabResultEvent<ClientModels.OpenTradeResponse>) each;

      if (OnPayForPurchaseRequestEvent != null)
        foreach (var each in OnPayForPurchaseRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnPayForPurchaseRequestEvent -= (PlayFabRequestEvent<ClientModels.PayForPurchaseRequest>) each;
      if (OnPayForPurchaseResultEvent != null)
        foreach (var each in OnPayForPurchaseResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnPayForPurchaseResultEvent -= (PlayFabResultEvent<ClientModels.PayForPurchaseResult>) each;

      if (OnPurchaseItemRequestEvent != null)
        foreach (var each in OnPurchaseItemRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnPurchaseItemRequestEvent -= (PlayFabRequestEvent<ClientModels.PurchaseItemRequest>) each;
      if (OnPurchaseItemResultEvent != null)
        foreach (var each in OnPurchaseItemResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnPurchaseItemResultEvent -= (PlayFabResultEvent<ClientModels.PurchaseItemResult>) each;

      if (OnRedeemCouponRequestEvent != null)
        foreach (var each in OnRedeemCouponRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnRedeemCouponRequestEvent -= (PlayFabRequestEvent<ClientModels.RedeemCouponRequest>) each;
      if (OnRedeemCouponResultEvent != null)
        foreach (var each in OnRedeemCouponResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnRedeemCouponResultEvent -= (PlayFabResultEvent<ClientModels.RedeemCouponResult>) each;

      if (OnRefreshPSNAuthTokenRequestEvent != null)
        foreach (var each in OnRefreshPSNAuthTokenRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnRefreshPSNAuthTokenRequestEvent -= (PlayFabRequestEvent<ClientModels.RefreshPSNAuthTokenRequest>) each;
      if (OnRefreshPSNAuthTokenResultEvent != null)
        foreach (var each in OnRefreshPSNAuthTokenResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnRefreshPSNAuthTokenResultEvent -= (PlayFabResultEvent<ClientModels.EmptyResponse>) each;

      if (OnRegisterForIOSPushNotificationRequestEvent != null)
        foreach (var each in OnRegisterForIOSPushNotificationRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnRegisterForIOSPushNotificationRequestEvent -=
              (PlayFabRequestEvent<ClientModels.RegisterForIOSPushNotificationRequest>) each;
      if (OnRegisterForIOSPushNotificationResultEvent != null)
        foreach (var each in OnRegisterForIOSPushNotificationResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnRegisterForIOSPushNotificationResultEvent -=
              (PlayFabResultEvent<ClientModels.RegisterForIOSPushNotificationResult>) each;

      if (OnRegisterPlayFabUserRequestEvent != null)
        foreach (var each in OnRegisterPlayFabUserRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnRegisterPlayFabUserRequestEvent -= (PlayFabRequestEvent<ClientModels.RegisterPlayFabUserRequest>) each;
      if (OnRegisterPlayFabUserResultEvent != null)
        foreach (var each in OnRegisterPlayFabUserResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnRegisterPlayFabUserResultEvent -= (PlayFabResultEvent<ClientModels.RegisterPlayFabUserResult>) each;

      if (OnRegisterWithWindowsHelloRequestEvent != null)
        foreach (var each in OnRegisterWithWindowsHelloRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnRegisterWithWindowsHelloRequestEvent -=
              (PlayFabRequestEvent<ClientModels.RegisterWithWindowsHelloRequest>) each;

      if (OnRemoveContactEmailRequestEvent != null)
        foreach (var each in OnRemoveContactEmailRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnRemoveContactEmailRequestEvent -= (PlayFabRequestEvent<ClientModels.RemoveContactEmailRequest>) each;
      if (OnRemoveContactEmailResultEvent != null)
        foreach (var each in OnRemoveContactEmailResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnRemoveContactEmailResultEvent -= (PlayFabResultEvent<ClientModels.RemoveContactEmailResult>) each;

      if (OnRemoveFriendRequestEvent != null)
        foreach (var each in OnRemoveFriendRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnRemoveFriendRequestEvent -= (PlayFabRequestEvent<ClientModels.RemoveFriendRequest>) each;
      if (OnRemoveFriendResultEvent != null)
        foreach (var each in OnRemoveFriendResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnRemoveFriendResultEvent -= (PlayFabResultEvent<ClientModels.RemoveFriendResult>) each;

      if (OnRemoveGenericIDRequestEvent != null)
        foreach (var each in OnRemoveGenericIDRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnRemoveGenericIDRequestEvent -= (PlayFabRequestEvent<ClientModels.RemoveGenericIDRequest>) each;
      if (OnRemoveGenericIDResultEvent != null)
        foreach (var each in OnRemoveGenericIDResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnRemoveGenericIDResultEvent -= (PlayFabResultEvent<ClientModels.RemoveGenericIDResult>) each;

      if (OnRemoveSharedGroupMembersRequestEvent != null)
        foreach (var each in OnRemoveSharedGroupMembersRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnRemoveSharedGroupMembersRequestEvent -=
              (PlayFabRequestEvent<ClientModels.RemoveSharedGroupMembersRequest>) each;
      if (OnRemoveSharedGroupMembersResultEvent != null)
        foreach (var each in OnRemoveSharedGroupMembersResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnRemoveSharedGroupMembersResultEvent -=
              (PlayFabResultEvent<ClientModels.RemoveSharedGroupMembersResult>) each;

      if (OnReportAdActivityRequestEvent != null)
        foreach (var each in OnReportAdActivityRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnReportAdActivityRequestEvent -= (PlayFabRequestEvent<ClientModels.ReportAdActivityRequest>) each;
      if (OnReportAdActivityResultEvent != null)
        foreach (var each in OnReportAdActivityResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnReportAdActivityResultEvent -= (PlayFabResultEvent<ClientModels.ReportAdActivityResult>) each;

      if (OnReportDeviceInfoRequestEvent != null)
        foreach (var each in OnReportDeviceInfoRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnReportDeviceInfoRequestEvent -= (PlayFabRequestEvent<ClientModels.DeviceInfoRequest>) each;
      if (OnReportDeviceInfoResultEvent != null)
        foreach (var each in OnReportDeviceInfoResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnReportDeviceInfoResultEvent -= (PlayFabResultEvent<ClientModels.EmptyResponse>) each;

      if (OnReportPlayerRequestEvent != null)
        foreach (var each in OnReportPlayerRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnReportPlayerRequestEvent -= (PlayFabRequestEvent<ClientModels.ReportPlayerClientRequest>) each;
      if (OnReportPlayerResultEvent != null)
        foreach (var each in OnReportPlayerResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnReportPlayerResultEvent -= (PlayFabResultEvent<ClientModels.ReportPlayerClientResult>) each;

      if (OnRestoreIOSPurchasesRequestEvent != null)
        foreach (var each in OnRestoreIOSPurchasesRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnRestoreIOSPurchasesRequestEvent -= (PlayFabRequestEvent<ClientModels.RestoreIOSPurchasesRequest>) each;
      if (OnRestoreIOSPurchasesResultEvent != null)
        foreach (var each in OnRestoreIOSPurchasesResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnRestoreIOSPurchasesResultEvent -= (PlayFabResultEvent<ClientModels.RestoreIOSPurchasesResult>) each;

      if (OnRewardAdActivityRequestEvent != null)
        foreach (var each in OnRewardAdActivityRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnRewardAdActivityRequestEvent -= (PlayFabRequestEvent<ClientModels.RewardAdActivityRequest>) each;
      if (OnRewardAdActivityResultEvent != null)
        foreach (var each in OnRewardAdActivityResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnRewardAdActivityResultEvent -= (PlayFabResultEvent<ClientModels.RewardAdActivityResult>) each;

      if (OnSendAccountRecoveryEmailRequestEvent != null)
        foreach (var each in OnSendAccountRecoveryEmailRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnSendAccountRecoveryEmailRequestEvent -=
              (PlayFabRequestEvent<ClientModels.SendAccountRecoveryEmailRequest>) each;
      if (OnSendAccountRecoveryEmailResultEvent != null)
        foreach (var each in OnSendAccountRecoveryEmailResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnSendAccountRecoveryEmailResultEvent -=
              (PlayFabResultEvent<ClientModels.SendAccountRecoveryEmailResult>) each;

      if (OnSetFriendTagsRequestEvent != null)
        foreach (var each in OnSetFriendTagsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnSetFriendTagsRequestEvent -= (PlayFabRequestEvent<ClientModels.SetFriendTagsRequest>) each;
      if (OnSetFriendTagsResultEvent != null)
        foreach (var each in OnSetFriendTagsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnSetFriendTagsResultEvent -= (PlayFabResultEvent<ClientModels.SetFriendTagsResult>) each;

      if (OnSetPlayerSecretRequestEvent != null)
        foreach (var each in OnSetPlayerSecretRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnSetPlayerSecretRequestEvent -= (PlayFabRequestEvent<ClientModels.SetPlayerSecretRequest>) each;
      if (OnSetPlayerSecretResultEvent != null)
        foreach (var each in OnSetPlayerSecretResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnSetPlayerSecretResultEvent -= (PlayFabResultEvent<ClientModels.SetPlayerSecretResult>) each;

      if (OnStartGameRequestEvent != null)
        foreach (var each in OnStartGameRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnStartGameRequestEvent -= (PlayFabRequestEvent<ClientModels.StartGameRequest>) each;
      if (OnStartGameResultEvent != null)
        foreach (var each in OnStartGameResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnStartGameResultEvent -= (PlayFabResultEvent<ClientModels.StartGameResult>) each;

      if (OnStartPurchaseRequestEvent != null)
        foreach (var each in OnStartPurchaseRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnStartPurchaseRequestEvent -= (PlayFabRequestEvent<ClientModels.StartPurchaseRequest>) each;
      if (OnStartPurchaseResultEvent != null)
        foreach (var each in OnStartPurchaseResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnStartPurchaseResultEvent -= (PlayFabResultEvent<ClientModels.StartPurchaseResult>) each;

      if (OnSubtractUserVirtualCurrencyRequestEvent != null)
        foreach (var each in OnSubtractUserVirtualCurrencyRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnSubtractUserVirtualCurrencyRequestEvent -=
              (PlayFabRequestEvent<ClientModels.SubtractUserVirtualCurrencyRequest>) each;
      if (OnSubtractUserVirtualCurrencyResultEvent != null)
        foreach (var each in OnSubtractUserVirtualCurrencyResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnSubtractUserVirtualCurrencyResultEvent -=
              (PlayFabResultEvent<ClientModels.ModifyUserVirtualCurrencyResult>) each;

      if (OnUnlinkAndroidDeviceIDRequestEvent != null)
        foreach (var each in OnUnlinkAndroidDeviceIDRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkAndroidDeviceIDRequestEvent -=
              (PlayFabRequestEvent<ClientModels.UnlinkAndroidDeviceIDRequest>) each;
      if (OnUnlinkAndroidDeviceIDResultEvent != null)
        foreach (var each in OnUnlinkAndroidDeviceIDResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkAndroidDeviceIDResultEvent -= (PlayFabResultEvent<ClientModels.UnlinkAndroidDeviceIDResult>) each;

      if (OnUnlinkAppleRequestEvent != null)
        foreach (var each in OnUnlinkAppleRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkAppleRequestEvent -= (PlayFabRequestEvent<ClientModels.UnlinkAppleRequest>) each;
      if (OnUnlinkAppleResultEvent != null)
        foreach (var each in OnUnlinkAppleResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkAppleResultEvent -= (PlayFabResultEvent<ClientModels.EmptyResponse>) each;

      if (OnUnlinkCustomIDRequestEvent != null)
        foreach (var each in OnUnlinkCustomIDRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkCustomIDRequestEvent -= (PlayFabRequestEvent<ClientModels.UnlinkCustomIDRequest>) each;
      if (OnUnlinkCustomIDResultEvent != null)
        foreach (var each in OnUnlinkCustomIDResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkCustomIDResultEvent -= (PlayFabResultEvent<ClientModels.UnlinkCustomIDResult>) each;

      if (OnUnlinkFacebookAccountRequestEvent != null)
        foreach (var each in OnUnlinkFacebookAccountRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkFacebookAccountRequestEvent -=
              (PlayFabRequestEvent<ClientModels.UnlinkFacebookAccountRequest>) each;
      if (OnUnlinkFacebookAccountResultEvent != null)
        foreach (var each in OnUnlinkFacebookAccountResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkFacebookAccountResultEvent -= (PlayFabResultEvent<ClientModels.UnlinkFacebookAccountResult>) each;

      if (OnUnlinkFacebookInstantGamesIdRequestEvent != null)
        foreach (var each in OnUnlinkFacebookInstantGamesIdRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkFacebookInstantGamesIdRequestEvent -=
              (PlayFabRequestEvent<ClientModels.UnlinkFacebookInstantGamesIdRequest>) each;
      if (OnUnlinkFacebookInstantGamesIdResultEvent != null)
        foreach (var each in OnUnlinkFacebookInstantGamesIdResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkFacebookInstantGamesIdResultEvent -=
              (PlayFabResultEvent<ClientModels.UnlinkFacebookInstantGamesIdResult>) each;

      if (OnUnlinkGameCenterAccountRequestEvent != null)
        foreach (var each in OnUnlinkGameCenterAccountRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkGameCenterAccountRequestEvent -=
              (PlayFabRequestEvent<ClientModels.UnlinkGameCenterAccountRequest>) each;
      if (OnUnlinkGameCenterAccountResultEvent != null)
        foreach (var each in OnUnlinkGameCenterAccountResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkGameCenterAccountResultEvent -=
              (PlayFabResultEvent<ClientModels.UnlinkGameCenterAccountResult>) each;

      if (OnUnlinkGoogleAccountRequestEvent != null)
        foreach (var each in OnUnlinkGoogleAccountRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkGoogleAccountRequestEvent -= (PlayFabRequestEvent<ClientModels.UnlinkGoogleAccountRequest>) each;
      if (OnUnlinkGoogleAccountResultEvent != null)
        foreach (var each in OnUnlinkGoogleAccountResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkGoogleAccountResultEvent -= (PlayFabResultEvent<ClientModels.UnlinkGoogleAccountResult>) each;

      if (OnUnlinkIOSDeviceIDRequestEvent != null)
        foreach (var each in OnUnlinkIOSDeviceIDRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkIOSDeviceIDRequestEvent -= (PlayFabRequestEvent<ClientModels.UnlinkIOSDeviceIDRequest>) each;
      if (OnUnlinkIOSDeviceIDResultEvent != null)
        foreach (var each in OnUnlinkIOSDeviceIDResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkIOSDeviceIDResultEvent -= (PlayFabResultEvent<ClientModels.UnlinkIOSDeviceIDResult>) each;

      if (OnUnlinkKongregateRequestEvent != null)
        foreach (var each in OnUnlinkKongregateRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkKongregateRequestEvent -= (PlayFabRequestEvent<ClientModels.UnlinkKongregateAccountRequest>) each;
      if (OnUnlinkKongregateResultEvent != null)
        foreach (var each in OnUnlinkKongregateResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkKongregateResultEvent -= (PlayFabResultEvent<ClientModels.UnlinkKongregateAccountResult>) each;

      if (OnUnlinkNintendoAccountRequestEvent != null)
        foreach (var each in OnUnlinkNintendoAccountRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkNintendoAccountRequestEvent -=
              (PlayFabRequestEvent<ClientModels.UnlinkNintendoAccountRequest>) each;
      if (OnUnlinkNintendoAccountResultEvent != null)
        foreach (var each in OnUnlinkNintendoAccountResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkNintendoAccountResultEvent -= (PlayFabResultEvent<ClientModels.EmptyResponse>) each;

      if (OnUnlinkNintendoSwitchDeviceIdRequestEvent != null)
        foreach (var each in OnUnlinkNintendoSwitchDeviceIdRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkNintendoSwitchDeviceIdRequestEvent -=
              (PlayFabRequestEvent<ClientModels.UnlinkNintendoSwitchDeviceIdRequest>) each;
      if (OnUnlinkNintendoSwitchDeviceIdResultEvent != null)
        foreach (var each in OnUnlinkNintendoSwitchDeviceIdResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkNintendoSwitchDeviceIdResultEvent -=
              (PlayFabResultEvent<ClientModels.UnlinkNintendoSwitchDeviceIdResult>) each;

      if (OnUnlinkOpenIdConnectRequestEvent != null)
        foreach (var each in OnUnlinkOpenIdConnectRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkOpenIdConnectRequestEvent -= (PlayFabRequestEvent<ClientModels.UnlinkOpenIdConnectRequest>) each;
      if (OnUnlinkOpenIdConnectResultEvent != null)
        foreach (var each in OnUnlinkOpenIdConnectResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkOpenIdConnectResultEvent -= (PlayFabResultEvent<ClientModels.EmptyResponse>) each;

      if (OnUnlinkPSNAccountRequestEvent != null)
        foreach (var each in OnUnlinkPSNAccountRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkPSNAccountRequestEvent -= (PlayFabRequestEvent<ClientModels.UnlinkPSNAccountRequest>) each;
      if (OnUnlinkPSNAccountResultEvent != null)
        foreach (var each in OnUnlinkPSNAccountResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkPSNAccountResultEvent -= (PlayFabResultEvent<ClientModels.UnlinkPSNAccountResult>) each;

      if (OnUnlinkSteamAccountRequestEvent != null)
        foreach (var each in OnUnlinkSteamAccountRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkSteamAccountRequestEvent -= (PlayFabRequestEvent<ClientModels.UnlinkSteamAccountRequest>) each;
      if (OnUnlinkSteamAccountResultEvent != null)
        foreach (var each in OnUnlinkSteamAccountResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkSteamAccountResultEvent -= (PlayFabResultEvent<ClientModels.UnlinkSteamAccountResult>) each;

      if (OnUnlinkTwitchRequestEvent != null)
        foreach (var each in OnUnlinkTwitchRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkTwitchRequestEvent -= (PlayFabRequestEvent<ClientModels.UnlinkTwitchAccountRequest>) each;
      if (OnUnlinkTwitchResultEvent != null)
        foreach (var each in OnUnlinkTwitchResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkTwitchResultEvent -= (PlayFabResultEvent<ClientModels.UnlinkTwitchAccountResult>) each;

      if (OnUnlinkWindowsHelloRequestEvent != null)
        foreach (var each in OnUnlinkWindowsHelloRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkWindowsHelloRequestEvent -=
              (PlayFabRequestEvent<ClientModels.UnlinkWindowsHelloAccountRequest>) each;
      if (OnUnlinkWindowsHelloResultEvent != null)
        foreach (var each in OnUnlinkWindowsHelloResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkWindowsHelloResultEvent -=
              (PlayFabResultEvent<ClientModels.UnlinkWindowsHelloAccountResponse>) each;

      if (OnUnlinkXboxAccountRequestEvent != null)
        foreach (var each in OnUnlinkXboxAccountRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkXboxAccountRequestEvent -= (PlayFabRequestEvent<ClientModels.UnlinkXboxAccountRequest>) each;
      if (OnUnlinkXboxAccountResultEvent != null)
        foreach (var each in OnUnlinkXboxAccountResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlinkXboxAccountResultEvent -= (PlayFabResultEvent<ClientModels.UnlinkXboxAccountResult>) each;

      if (OnUnlockContainerInstanceRequestEvent != null)
        foreach (var each in OnUnlockContainerInstanceRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlockContainerInstanceRequestEvent -=
              (PlayFabRequestEvent<ClientModels.UnlockContainerInstanceRequest>) each;
      if (OnUnlockContainerInstanceResultEvent != null)
        foreach (var each in OnUnlockContainerInstanceResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlockContainerInstanceResultEvent -= (PlayFabResultEvent<ClientModels.UnlockContainerItemResult>) each;

      if (OnUnlockContainerItemRequestEvent != null)
        foreach (var each in OnUnlockContainerItemRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlockContainerItemRequestEvent -= (PlayFabRequestEvent<ClientModels.UnlockContainerItemRequest>) each;
      if (OnUnlockContainerItemResultEvent != null)
        foreach (var each in OnUnlockContainerItemResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUnlockContainerItemResultEvent -= (PlayFabResultEvent<ClientModels.UnlockContainerItemResult>) each;

      if (OnUpdateAvatarUrlRequestEvent != null)
        foreach (var each in OnUpdateAvatarUrlRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUpdateAvatarUrlRequestEvent -= (PlayFabRequestEvent<ClientModels.UpdateAvatarUrlRequest>) each;
      if (OnUpdateAvatarUrlResultEvent != null)
        foreach (var each in OnUpdateAvatarUrlResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUpdateAvatarUrlResultEvent -= (PlayFabResultEvent<ClientModels.EmptyResponse>) each;

      if (OnUpdateCharacterDataRequestEvent != null)
        foreach (var each in OnUpdateCharacterDataRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUpdateCharacterDataRequestEvent -= (PlayFabRequestEvent<ClientModels.UpdateCharacterDataRequest>) each;
      if (OnUpdateCharacterDataResultEvent != null)
        foreach (var each in OnUpdateCharacterDataResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUpdateCharacterDataResultEvent -= (PlayFabResultEvent<ClientModels.UpdateCharacterDataResult>) each;

      if (OnUpdateCharacterStatisticsRequestEvent != null)
        foreach (var each in OnUpdateCharacterStatisticsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUpdateCharacterStatisticsRequestEvent -=
              (PlayFabRequestEvent<ClientModels.UpdateCharacterStatisticsRequest>) each;
      if (OnUpdateCharacterStatisticsResultEvent != null)
        foreach (var each in OnUpdateCharacterStatisticsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUpdateCharacterStatisticsResultEvent -=
              (PlayFabResultEvent<ClientModels.UpdateCharacterStatisticsResult>) each;

      if (OnUpdatePlayerStatisticsRequestEvent != null)
        foreach (var each in OnUpdatePlayerStatisticsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUpdatePlayerStatisticsRequestEvent -=
              (PlayFabRequestEvent<ClientModels.UpdatePlayerStatisticsRequest>) each;
      if (OnUpdatePlayerStatisticsResultEvent != null)
        foreach (var each in OnUpdatePlayerStatisticsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUpdatePlayerStatisticsResultEvent -= (PlayFabResultEvent<ClientModels.UpdatePlayerStatisticsResult>) each;

      if (OnUpdateSharedGroupDataRequestEvent != null)
        foreach (var each in OnUpdateSharedGroupDataRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUpdateSharedGroupDataRequestEvent -=
              (PlayFabRequestEvent<ClientModels.UpdateSharedGroupDataRequest>) each;
      if (OnUpdateSharedGroupDataResultEvent != null)
        foreach (var each in OnUpdateSharedGroupDataResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUpdateSharedGroupDataResultEvent -= (PlayFabResultEvent<ClientModels.UpdateSharedGroupDataResult>) each;

      if (OnUpdateUserDataRequestEvent != null)
        foreach (var each in OnUpdateUserDataRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUpdateUserDataRequestEvent -= (PlayFabRequestEvent<ClientModels.UpdateUserDataRequest>) each;
      if (OnUpdateUserDataResultEvent != null)
        foreach (var each in OnUpdateUserDataResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUpdateUserDataResultEvent -= (PlayFabResultEvent<ClientModels.UpdateUserDataResult>) each;

      if (OnUpdateUserPublisherDataRequestEvent != null)
        foreach (var each in OnUpdateUserPublisherDataRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUpdateUserPublisherDataRequestEvent -= (PlayFabRequestEvent<ClientModels.UpdateUserDataRequest>) each;
      if (OnUpdateUserPublisherDataResultEvent != null)
        foreach (var each in OnUpdateUserPublisherDataResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUpdateUserPublisherDataResultEvent -= (PlayFabResultEvent<ClientModels.UpdateUserDataResult>) each;

      if (OnUpdateUserTitleDisplayNameRequestEvent != null)
        foreach (var each in OnUpdateUserTitleDisplayNameRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUpdateUserTitleDisplayNameRequestEvent -=
              (PlayFabRequestEvent<ClientModels.UpdateUserTitleDisplayNameRequest>) each;
      if (OnUpdateUserTitleDisplayNameResultEvent != null)
        foreach (var each in OnUpdateUserTitleDisplayNameResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnUpdateUserTitleDisplayNameResultEvent -=
              (PlayFabResultEvent<ClientModels.UpdateUserTitleDisplayNameResult>) each;

      if (OnValidateAmazonIAPReceiptRequestEvent != null)
        foreach (var each in OnValidateAmazonIAPReceiptRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnValidateAmazonIAPReceiptRequestEvent -=
              (PlayFabRequestEvent<ClientModels.ValidateAmazonReceiptRequest>) each;
      if (OnValidateAmazonIAPReceiptResultEvent != null)
        foreach (var each in OnValidateAmazonIAPReceiptResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnValidateAmazonIAPReceiptResultEvent -=
              (PlayFabResultEvent<ClientModels.ValidateAmazonReceiptResult>) each;

      if (OnValidateGooglePlayPurchaseRequestEvent != null)
        foreach (var each in OnValidateGooglePlayPurchaseRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnValidateGooglePlayPurchaseRequestEvent -=
              (PlayFabRequestEvent<ClientModels.ValidateGooglePlayPurchaseRequest>) each;
      if (OnValidateGooglePlayPurchaseResultEvent != null)
        foreach (var each in OnValidateGooglePlayPurchaseResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnValidateGooglePlayPurchaseResultEvent -=
              (PlayFabResultEvent<ClientModels.ValidateGooglePlayPurchaseResult>) each;

      if (OnValidateIOSReceiptRequestEvent != null)
        foreach (var each in OnValidateIOSReceiptRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnValidateIOSReceiptRequestEvent -= (PlayFabRequestEvent<ClientModels.ValidateIOSReceiptRequest>) each;
      if (OnValidateIOSReceiptResultEvent != null)
        foreach (var each in OnValidateIOSReceiptResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnValidateIOSReceiptResultEvent -= (PlayFabResultEvent<ClientModels.ValidateIOSReceiptResult>) each;

      if (OnValidateWindowsStoreReceiptRequestEvent != null)
        foreach (var each in OnValidateWindowsStoreReceiptRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnValidateWindowsStoreReceiptRequestEvent -=
              (PlayFabRequestEvent<ClientModels.ValidateWindowsReceiptRequest>) each;
      if (OnValidateWindowsStoreReceiptResultEvent != null)
        foreach (var each in OnValidateWindowsStoreReceiptResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnValidateWindowsStoreReceiptResultEvent -=
              (PlayFabResultEvent<ClientModels.ValidateWindowsReceiptResult>) each;

      if (OnWriteCharacterEventRequestEvent != null)
        foreach (var each in OnWriteCharacterEventRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnWriteCharacterEventRequestEvent -=
              (PlayFabRequestEvent<ClientModels.WriteClientCharacterEventRequest>) each;
      if (OnWriteCharacterEventResultEvent != null)
        foreach (var each in OnWriteCharacterEventResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnWriteCharacterEventResultEvent -= (PlayFabResultEvent<ClientModels.WriteEventResponse>) each;

      if (OnWritePlayerEventRequestEvent != null)
        foreach (var each in OnWritePlayerEventRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnWritePlayerEventRequestEvent -= (PlayFabRequestEvent<ClientModels.WriteClientPlayerEventRequest>) each;
      if (OnWritePlayerEventResultEvent != null)
        foreach (var each in OnWritePlayerEventResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnWritePlayerEventResultEvent -= (PlayFabResultEvent<ClientModels.WriteEventResponse>) each;

      if (OnWriteTitleEventRequestEvent != null)
        foreach (var each in OnWriteTitleEventRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnWriteTitleEventRequestEvent -= (PlayFabRequestEvent<ClientModels.WriteTitleEventRequest>) each;
      if (OnWriteTitleEventResultEvent != null)
        foreach (var each in OnWriteTitleEventResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnWriteTitleEventResultEvent -= (PlayFabResultEvent<ClientModels.WriteEventResponse>) each;

#endif
#if ENABLE_PLAYFABSERVER_API
            if (OnMatchmakerAuthUserRequestEvent != null) { foreach (var each in OnMatchmakerAuthUserRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnMatchmakerAuthUserRequestEvent
 -= (PlayFabRequestEvent<MatchmakerModels.AuthUserRequest>)each; } } }
            if (OnMatchmakerAuthUserResultEvent != null) { foreach (var each in OnMatchmakerAuthUserResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnMatchmakerAuthUserResultEvent
 -= (PlayFabResultEvent<MatchmakerModels.AuthUserResponse>)each; } } }

            if (OnMatchmakerPlayerJoinedRequestEvent != null) { foreach (var each in OnMatchmakerPlayerJoinedRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnMatchmakerPlayerJoinedRequestEvent
 -= (PlayFabRequestEvent<MatchmakerModels.PlayerJoinedRequest>)each; } } }
            if (OnMatchmakerPlayerJoinedResultEvent != null) { foreach (var each in OnMatchmakerPlayerJoinedResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnMatchmakerPlayerJoinedResultEvent
 -= (PlayFabResultEvent<MatchmakerModels.PlayerJoinedResponse>)each; } } }

            if (OnMatchmakerPlayerLeftRequestEvent != null) { foreach (var each in OnMatchmakerPlayerLeftRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnMatchmakerPlayerLeftRequestEvent
 -= (PlayFabRequestEvent<MatchmakerModels.PlayerLeftRequest>)each; } } }
            if (OnMatchmakerPlayerLeftResultEvent != null) { foreach (var each in OnMatchmakerPlayerLeftResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnMatchmakerPlayerLeftResultEvent
 -= (PlayFabResultEvent<MatchmakerModels.PlayerLeftResponse>)each; } } }

            if (OnMatchmakerStartGameRequestEvent != null) { foreach (var each in OnMatchmakerStartGameRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnMatchmakerStartGameRequestEvent
 -= (PlayFabRequestEvent<MatchmakerModels.StartGameRequest>)each; } } }
            if (OnMatchmakerStartGameResultEvent != null) { foreach (var each in OnMatchmakerStartGameResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnMatchmakerStartGameResultEvent
 -= (PlayFabResultEvent<MatchmakerModels.StartGameResponse>)each; } } }

            if (OnMatchmakerUserInfoRequestEvent != null) { foreach (var each in OnMatchmakerUserInfoRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnMatchmakerUserInfoRequestEvent
 -= (PlayFabRequestEvent<MatchmakerModels.UserInfoRequest>)each; } } }
            if (OnMatchmakerUserInfoResultEvent != null) { foreach (var each in OnMatchmakerUserInfoResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnMatchmakerUserInfoResultEvent
 -= (PlayFabResultEvent<MatchmakerModels.UserInfoResponse>)each; } } }

#endif
#if ENABLE_PLAYFABSERVER_API
            if (OnServerAddCharacterVirtualCurrencyRequestEvent != null) { foreach (var each in OnServerAddCharacterVirtualCurrencyRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerAddCharacterVirtualCurrencyRequestEvent
 -= (PlayFabRequestEvent<ServerModels.AddCharacterVirtualCurrencyRequest>)each; } } }
            if (OnServerAddCharacterVirtualCurrencyResultEvent != null) { foreach (var each in OnServerAddCharacterVirtualCurrencyResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerAddCharacterVirtualCurrencyResultEvent
 -= (PlayFabResultEvent<ServerModels.ModifyCharacterVirtualCurrencyResult>)each; } } }

            if (OnServerAddFriendRequestEvent != null) { foreach (var each in OnServerAddFriendRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerAddFriendRequestEvent
 -= (PlayFabRequestEvent<ServerModels.AddFriendRequest>)each; } } }
            if (OnServerAddFriendResultEvent != null) { foreach (var each in OnServerAddFriendResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerAddFriendResultEvent
 -= (PlayFabResultEvent<ServerModels.EmptyResponse>)each; } } }

            if (OnServerAddGenericIDRequestEvent != null) { foreach (var each in OnServerAddGenericIDRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerAddGenericIDRequestEvent
 -= (PlayFabRequestEvent<ServerModels.AddGenericIDRequest>)each; } } }
            if (OnServerAddGenericIDResultEvent != null) { foreach (var each in OnServerAddGenericIDResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerAddGenericIDResultEvent
 -= (PlayFabResultEvent<ServerModels.EmptyResult>)each; } } }

            if (OnServerAddPlayerTagRequestEvent != null) { foreach (var each in OnServerAddPlayerTagRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerAddPlayerTagRequestEvent
 -= (PlayFabRequestEvent<ServerModels.AddPlayerTagRequest>)each; } } }
            if (OnServerAddPlayerTagResultEvent != null) { foreach (var each in OnServerAddPlayerTagResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerAddPlayerTagResultEvent
 -= (PlayFabResultEvent<ServerModels.AddPlayerTagResult>)each; } } }

            if (OnServerAddSharedGroupMembersRequestEvent != null) { foreach (var each in OnServerAddSharedGroupMembersRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerAddSharedGroupMembersRequestEvent
 -= (PlayFabRequestEvent<ServerModels.AddSharedGroupMembersRequest>)each; } } }
            if (OnServerAddSharedGroupMembersResultEvent != null) { foreach (var each in OnServerAddSharedGroupMembersResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerAddSharedGroupMembersResultEvent
 -= (PlayFabResultEvent<ServerModels.AddSharedGroupMembersResult>)each; } } }

            if (OnServerAddUserVirtualCurrencyRequestEvent != null) { foreach (var each in OnServerAddUserVirtualCurrencyRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerAddUserVirtualCurrencyRequestEvent
 -= (PlayFabRequestEvent<ServerModels.AddUserVirtualCurrencyRequest>)each; } } }
            if (OnServerAddUserVirtualCurrencyResultEvent != null) { foreach (var each in OnServerAddUserVirtualCurrencyResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerAddUserVirtualCurrencyResultEvent
 -= (PlayFabResultEvent<ServerModels.ModifyUserVirtualCurrencyResult>)each; } } }

            if (OnServerAuthenticateSessionTicketRequestEvent != null) { foreach (var each in OnServerAuthenticateSessionTicketRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerAuthenticateSessionTicketRequestEvent
 -= (PlayFabRequestEvent<ServerModels.AuthenticateSessionTicketRequest>)each; } } }
            if (OnServerAuthenticateSessionTicketResultEvent != null) { foreach (var each in OnServerAuthenticateSessionTicketResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerAuthenticateSessionTicketResultEvent
 -= (PlayFabResultEvent<ServerModels.AuthenticateSessionTicketResult>)each; } } }

            if (OnServerAwardSteamAchievementRequestEvent != null) { foreach (var each in OnServerAwardSteamAchievementRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerAwardSteamAchievementRequestEvent
 -= (PlayFabRequestEvent<ServerModels.AwardSteamAchievementRequest>)each; } } }
            if (OnServerAwardSteamAchievementResultEvent != null) { foreach (var each in OnServerAwardSteamAchievementResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerAwardSteamAchievementResultEvent
 -= (PlayFabResultEvent<ServerModels.AwardSteamAchievementResult>)each; } } }

            if (OnServerBanUsersRequestEvent != null) { foreach (var each in OnServerBanUsersRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerBanUsersRequestEvent
 -= (PlayFabRequestEvent<ServerModels.BanUsersRequest>)each; } } }
            if (OnServerBanUsersResultEvent != null) { foreach (var each in OnServerBanUsersResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerBanUsersResultEvent
 -= (PlayFabResultEvent<ServerModels.BanUsersResult>)each; } } }

            if (OnServerConsumeItemRequestEvent != null) { foreach (var each in OnServerConsumeItemRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerConsumeItemRequestEvent
 -= (PlayFabRequestEvent<ServerModels.ConsumeItemRequest>)each; } } }
            if (OnServerConsumeItemResultEvent != null) { foreach (var each in OnServerConsumeItemResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerConsumeItemResultEvent
 -= (PlayFabResultEvent<ServerModels.ConsumeItemResult>)each; } } }

            if (OnServerCreateSharedGroupRequestEvent != null) { foreach (var each in OnServerCreateSharedGroupRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerCreateSharedGroupRequestEvent
 -= (PlayFabRequestEvent<ServerModels.CreateSharedGroupRequest>)each; } } }
            if (OnServerCreateSharedGroupResultEvent != null) { foreach (var each in OnServerCreateSharedGroupResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerCreateSharedGroupResultEvent
 -= (PlayFabResultEvent<ServerModels.CreateSharedGroupResult>)each; } } }

            if (OnServerDeleteCharacterFromUserRequestEvent != null) { foreach (var each in OnServerDeleteCharacterFromUserRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerDeleteCharacterFromUserRequestEvent
 -= (PlayFabRequestEvent<ServerModels.DeleteCharacterFromUserRequest>)each; } } }
            if (OnServerDeleteCharacterFromUserResultEvent != null) { foreach (var each in OnServerDeleteCharacterFromUserResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerDeleteCharacterFromUserResultEvent
 -= (PlayFabResultEvent<ServerModels.DeleteCharacterFromUserResult>)each; } } }

            if (OnServerDeletePlayerRequestEvent != null) { foreach (var each in OnServerDeletePlayerRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerDeletePlayerRequestEvent
 -= (PlayFabRequestEvent<ServerModels.DeletePlayerRequest>)each; } } }
            if (OnServerDeletePlayerResultEvent != null) { foreach (var each in OnServerDeletePlayerResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerDeletePlayerResultEvent
 -= (PlayFabResultEvent<ServerModels.DeletePlayerResult>)each; } } }

            if (OnServerDeletePushNotificationTemplateRequestEvent != null) { foreach (var each in OnServerDeletePushNotificationTemplateRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerDeletePushNotificationTemplateRequestEvent
 -= (PlayFabRequestEvent<ServerModels.DeletePushNotificationTemplateRequest>)each; } } }
            if (OnServerDeletePushNotificationTemplateResultEvent != null) { foreach (var each in OnServerDeletePushNotificationTemplateResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerDeletePushNotificationTemplateResultEvent
 -= (PlayFabResultEvent<ServerModels.DeletePushNotificationTemplateResult>)each; } } }

            if (OnServerDeleteSharedGroupRequestEvent != null) { foreach (var each in OnServerDeleteSharedGroupRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerDeleteSharedGroupRequestEvent
 -= (PlayFabRequestEvent<ServerModels.DeleteSharedGroupRequest>)each; } } }
            if (OnServerDeleteSharedGroupResultEvent != null) { foreach (var each in OnServerDeleteSharedGroupResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerDeleteSharedGroupResultEvent
 -= (PlayFabResultEvent<ServerModels.EmptyResponse>)each; } } }

            if (OnServerDeregisterGameRequestEvent != null) { foreach (var each in OnServerDeregisterGameRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerDeregisterGameRequestEvent
 -= (PlayFabRequestEvent<ServerModels.DeregisterGameRequest>)each; } } }
            if (OnServerDeregisterGameResultEvent != null) { foreach (var each in OnServerDeregisterGameResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerDeregisterGameResultEvent
 -= (PlayFabResultEvent<ServerModels.DeregisterGameResponse>)each; } } }

            if (OnServerEvaluateRandomResultTableRequestEvent != null) { foreach (var each in OnServerEvaluateRandomResultTableRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerEvaluateRandomResultTableRequestEvent
 -= (PlayFabRequestEvent<ServerModels.EvaluateRandomResultTableRequest>)each; } } }
            if (OnServerEvaluateRandomResultTableResultEvent != null) { foreach (var each in OnServerEvaluateRandomResultTableResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerEvaluateRandomResultTableResultEvent
 -= (PlayFabResultEvent<ServerModels.EvaluateRandomResultTableResult>)each; } } }

            if (OnServerExecuteCloudScriptRequestEvent != null) { foreach (var each in OnServerExecuteCloudScriptRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerExecuteCloudScriptRequestEvent
 -= (PlayFabRequestEvent<ServerModels.ExecuteCloudScriptServerRequest>)each; } } }
            if (OnServerExecuteCloudScriptResultEvent != null) { foreach (var each in OnServerExecuteCloudScriptResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerExecuteCloudScriptResultEvent
 -= (PlayFabResultEvent<ServerModels.ExecuteCloudScriptResult>)each; } } }

            if (OnServerGetAllSegmentsRequestEvent != null) { foreach (var each in OnServerGetAllSegmentsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetAllSegmentsRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetAllSegmentsRequest>)each; } } }
            if (OnServerGetAllSegmentsResultEvent != null) { foreach (var each in OnServerGetAllSegmentsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetAllSegmentsResultEvent
 -= (PlayFabResultEvent<ServerModels.GetAllSegmentsResult>)each; } } }

            if (OnServerGetAllUsersCharactersRequestEvent != null) { foreach (var each in OnServerGetAllUsersCharactersRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetAllUsersCharactersRequestEvent
 -= (PlayFabRequestEvent<ServerModels.ListUsersCharactersRequest>)each; } } }
            if (OnServerGetAllUsersCharactersResultEvent != null) { foreach (var each in OnServerGetAllUsersCharactersResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetAllUsersCharactersResultEvent
 -= (PlayFabResultEvent<ServerModels.ListUsersCharactersResult>)each; } } }

            if (OnServerGetCatalogItemsRequestEvent != null) { foreach (var each in OnServerGetCatalogItemsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetCatalogItemsRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetCatalogItemsRequest>)each; } } }
            if (OnServerGetCatalogItemsResultEvent != null) { foreach (var each in OnServerGetCatalogItemsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetCatalogItemsResultEvent
 -= (PlayFabResultEvent<ServerModels.GetCatalogItemsResult>)each; } } }

            if (OnServerGetCharacterDataRequestEvent != null) { foreach (var each in OnServerGetCharacterDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetCharacterDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetCharacterDataRequest>)each; } } }
            if (OnServerGetCharacterDataResultEvent != null) { foreach (var each in OnServerGetCharacterDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetCharacterDataResultEvent
 -= (PlayFabResultEvent<ServerModels.GetCharacterDataResult>)each; } } }

            if (OnServerGetCharacterInternalDataRequestEvent != null) { foreach (var each in OnServerGetCharacterInternalDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetCharacterInternalDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetCharacterDataRequest>)each; } } }
            if (OnServerGetCharacterInternalDataResultEvent != null) { foreach (var each in OnServerGetCharacterInternalDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetCharacterInternalDataResultEvent
 -= (PlayFabResultEvent<ServerModels.GetCharacterDataResult>)each; } } }

            if (OnServerGetCharacterInventoryRequestEvent != null) { foreach (var each in OnServerGetCharacterInventoryRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetCharacterInventoryRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetCharacterInventoryRequest>)each; } } }
            if (OnServerGetCharacterInventoryResultEvent != null) { foreach (var each in OnServerGetCharacterInventoryResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetCharacterInventoryResultEvent
 -= (PlayFabResultEvent<ServerModels.GetCharacterInventoryResult>)each; } } }

            if (OnServerGetCharacterLeaderboardRequestEvent != null) { foreach (var each in OnServerGetCharacterLeaderboardRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetCharacterLeaderboardRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetCharacterLeaderboardRequest>)each; } } }
            if (OnServerGetCharacterLeaderboardResultEvent != null) { foreach (var each in OnServerGetCharacterLeaderboardResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetCharacterLeaderboardResultEvent
 -= (PlayFabResultEvent<ServerModels.GetCharacterLeaderboardResult>)each; } } }

            if (OnServerGetCharacterReadOnlyDataRequestEvent != null) { foreach (var each in OnServerGetCharacterReadOnlyDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetCharacterReadOnlyDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetCharacterDataRequest>)each; } } }
            if (OnServerGetCharacterReadOnlyDataResultEvent != null) { foreach (var each in OnServerGetCharacterReadOnlyDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetCharacterReadOnlyDataResultEvent
 -= (PlayFabResultEvent<ServerModels.GetCharacterDataResult>)each; } } }

            if (OnServerGetCharacterStatisticsRequestEvent != null) { foreach (var each in OnServerGetCharacterStatisticsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetCharacterStatisticsRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetCharacterStatisticsRequest>)each; } } }
            if (OnServerGetCharacterStatisticsResultEvent != null) { foreach (var each in OnServerGetCharacterStatisticsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetCharacterStatisticsResultEvent
 -= (PlayFabResultEvent<ServerModels.GetCharacterStatisticsResult>)each; } } }

            if (OnServerGetContentDownloadUrlRequestEvent != null) { foreach (var each in OnServerGetContentDownloadUrlRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetContentDownloadUrlRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetContentDownloadUrlRequest>)each; } } }
            if (OnServerGetContentDownloadUrlResultEvent != null) { foreach (var each in OnServerGetContentDownloadUrlResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetContentDownloadUrlResultEvent
 -= (PlayFabResultEvent<ServerModels.GetContentDownloadUrlResult>)each; } } }

            if (OnServerGetFriendLeaderboardRequestEvent != null) { foreach (var each in OnServerGetFriendLeaderboardRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetFriendLeaderboardRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetFriendLeaderboardRequest>)each; } } }
            if (OnServerGetFriendLeaderboardResultEvent != null) { foreach (var each in OnServerGetFriendLeaderboardResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetFriendLeaderboardResultEvent
 -= (PlayFabResultEvent<ServerModels.GetLeaderboardResult>)each; } } }

            if (OnServerGetFriendsListRequestEvent != null) { foreach (var each in OnServerGetFriendsListRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetFriendsListRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetFriendsListRequest>)each; } } }
            if (OnServerGetFriendsListResultEvent != null) { foreach (var each in OnServerGetFriendsListResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetFriendsListResultEvent
 -= (PlayFabResultEvent<ServerModels.GetFriendsListResult>)each; } } }

            if (OnServerGetLeaderboardRequestEvent != null) { foreach (var each in OnServerGetLeaderboardRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetLeaderboardRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetLeaderboardRequest>)each; } } }
            if (OnServerGetLeaderboardResultEvent != null) { foreach (var each in OnServerGetLeaderboardResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetLeaderboardResultEvent
 -= (PlayFabResultEvent<ServerModels.GetLeaderboardResult>)each; } } }

            if (OnServerGetLeaderboardAroundCharacterRequestEvent != null) { foreach (var each in OnServerGetLeaderboardAroundCharacterRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetLeaderboardAroundCharacterRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetLeaderboardAroundCharacterRequest>)each; } } }
            if (OnServerGetLeaderboardAroundCharacterResultEvent != null) { foreach (var each in OnServerGetLeaderboardAroundCharacterResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetLeaderboardAroundCharacterResultEvent
 -= (PlayFabResultEvent<ServerModels.GetLeaderboardAroundCharacterResult>)each; } } }

            if (OnServerGetLeaderboardAroundUserRequestEvent != null) { foreach (var each in OnServerGetLeaderboardAroundUserRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetLeaderboardAroundUserRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetLeaderboardAroundUserRequest>)each; } } }
            if (OnServerGetLeaderboardAroundUserResultEvent != null) { foreach (var each in OnServerGetLeaderboardAroundUserResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetLeaderboardAroundUserResultEvent
 -= (PlayFabResultEvent<ServerModels.GetLeaderboardAroundUserResult>)each; } } }

            if (OnServerGetLeaderboardForUserCharactersRequestEvent != null) { foreach (var each in OnServerGetLeaderboardForUserCharactersRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetLeaderboardForUserCharactersRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetLeaderboardForUsersCharactersRequest>)each; } } }
            if (OnServerGetLeaderboardForUserCharactersResultEvent != null) { foreach (var each in OnServerGetLeaderboardForUserCharactersResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetLeaderboardForUserCharactersResultEvent
 -= (PlayFabResultEvent<ServerModels.GetLeaderboardForUsersCharactersResult>)each; } } }

            if (OnServerGetPlayerCombinedInfoRequestEvent != null) { foreach (var each in OnServerGetPlayerCombinedInfoRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayerCombinedInfoRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetPlayerCombinedInfoRequest>)each; } } }
            if (OnServerGetPlayerCombinedInfoResultEvent != null) { foreach (var each in OnServerGetPlayerCombinedInfoResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayerCombinedInfoResultEvent
 -= (PlayFabResultEvent<ServerModels.GetPlayerCombinedInfoResult>)each; } } }

            if (OnServerGetPlayerProfileRequestEvent != null) { foreach (var each in OnServerGetPlayerProfileRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayerProfileRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetPlayerProfileRequest>)each; } } }
            if (OnServerGetPlayerProfileResultEvent != null) { foreach (var each in OnServerGetPlayerProfileResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayerProfileResultEvent
 -= (PlayFabResultEvent<ServerModels.GetPlayerProfileResult>)each; } } }

            if (OnServerGetPlayerSegmentsRequestEvent != null) { foreach (var each in OnServerGetPlayerSegmentsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayerSegmentsRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetPlayersSegmentsRequest>)each; } } }
            if (OnServerGetPlayerSegmentsResultEvent != null) { foreach (var each in OnServerGetPlayerSegmentsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayerSegmentsResultEvent
 -= (PlayFabResultEvent<ServerModels.GetPlayerSegmentsResult>)each; } } }

            if (OnServerGetPlayersInSegmentRequestEvent != null) { foreach (var each in OnServerGetPlayersInSegmentRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayersInSegmentRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetPlayersInSegmentRequest>)each; } } }
            if (OnServerGetPlayersInSegmentResultEvent != null) { foreach (var each in OnServerGetPlayersInSegmentResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayersInSegmentResultEvent
 -= (PlayFabResultEvent<ServerModels.GetPlayersInSegmentResult>)each; } } }

            if (OnServerGetPlayerStatisticsRequestEvent != null) { foreach (var each in OnServerGetPlayerStatisticsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayerStatisticsRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetPlayerStatisticsRequest>)each; } } }
            if (OnServerGetPlayerStatisticsResultEvent != null) { foreach (var each in OnServerGetPlayerStatisticsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayerStatisticsResultEvent
 -= (PlayFabResultEvent<ServerModels.GetPlayerStatisticsResult>)each; } } }

            if (OnServerGetPlayerStatisticVersionsRequestEvent != null) { foreach (var each in OnServerGetPlayerStatisticVersionsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayerStatisticVersionsRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetPlayerStatisticVersionsRequest>)each; } } }
            if (OnServerGetPlayerStatisticVersionsResultEvent != null) { foreach (var each in OnServerGetPlayerStatisticVersionsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayerStatisticVersionsResultEvent
 -= (PlayFabResultEvent<ServerModels.GetPlayerStatisticVersionsResult>)each; } } }

            if (OnServerGetPlayerTagsRequestEvent != null) { foreach (var each in OnServerGetPlayerTagsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayerTagsRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetPlayerTagsRequest>)each; } } }
            if (OnServerGetPlayerTagsResultEvent != null) { foreach (var each in OnServerGetPlayerTagsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayerTagsResultEvent
 -= (PlayFabResultEvent<ServerModels.GetPlayerTagsResult>)each; } } }

            if (OnServerGetPlayFabIDsFromFacebookIDsRequestEvent != null) { foreach (var each in OnServerGetPlayFabIDsFromFacebookIDsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayFabIDsFromFacebookIDsRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetPlayFabIDsFromFacebookIDsRequest>)each; } } }
            if (OnServerGetPlayFabIDsFromFacebookIDsResultEvent != null) { foreach (var each in OnServerGetPlayFabIDsFromFacebookIDsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayFabIDsFromFacebookIDsResultEvent
 -= (PlayFabResultEvent<ServerModels.GetPlayFabIDsFromFacebookIDsResult>)each; } } }

            if (OnServerGetPlayFabIDsFromFacebookInstantGamesIdsRequestEvent != null) { foreach (var each in OnServerGetPlayFabIDsFromFacebookInstantGamesIdsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayFabIDsFromFacebookInstantGamesIdsRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetPlayFabIDsFromFacebookInstantGamesIdsRequest>)each; } } }
            if (OnServerGetPlayFabIDsFromFacebookInstantGamesIdsResultEvent != null) { foreach (var each in OnServerGetPlayFabIDsFromFacebookInstantGamesIdsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayFabIDsFromFacebookInstantGamesIdsResultEvent
 -= (PlayFabResultEvent<ServerModels.GetPlayFabIDsFromFacebookInstantGamesIdsResult>)each; } } }

            if (OnServerGetPlayFabIDsFromGenericIDsRequestEvent != null) { foreach (var each in OnServerGetPlayFabIDsFromGenericIDsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayFabIDsFromGenericIDsRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetPlayFabIDsFromGenericIDsRequest>)each; } } }
            if (OnServerGetPlayFabIDsFromGenericIDsResultEvent != null) { foreach (var each in OnServerGetPlayFabIDsFromGenericIDsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayFabIDsFromGenericIDsResultEvent
 -= (PlayFabResultEvent<ServerModels.GetPlayFabIDsFromGenericIDsResult>)each; } } }

            if (OnServerGetPlayFabIDsFromNintendoSwitchDeviceIdsRequestEvent != null) { foreach (var each in OnServerGetPlayFabIDsFromNintendoSwitchDeviceIdsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayFabIDsFromNintendoSwitchDeviceIdsRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetPlayFabIDsFromNintendoSwitchDeviceIdsRequest>)each; } } }
            if (OnServerGetPlayFabIDsFromNintendoSwitchDeviceIdsResultEvent != null) { foreach (var each in OnServerGetPlayFabIDsFromNintendoSwitchDeviceIdsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayFabIDsFromNintendoSwitchDeviceIdsResultEvent
 -= (PlayFabResultEvent<ServerModels.GetPlayFabIDsFromNintendoSwitchDeviceIdsResult>)each; } } }

            if (OnServerGetPlayFabIDsFromPSNAccountIDsRequestEvent != null) { foreach (var each in OnServerGetPlayFabIDsFromPSNAccountIDsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayFabIDsFromPSNAccountIDsRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetPlayFabIDsFromPSNAccountIDsRequest>)each; } } }
            if (OnServerGetPlayFabIDsFromPSNAccountIDsResultEvent != null) { foreach (var each in OnServerGetPlayFabIDsFromPSNAccountIDsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayFabIDsFromPSNAccountIDsResultEvent
 -= (PlayFabResultEvent<ServerModels.GetPlayFabIDsFromPSNAccountIDsResult>)each; } } }

            if (OnServerGetPlayFabIDsFromSteamIDsRequestEvent != null) { foreach (var each in OnServerGetPlayFabIDsFromSteamIDsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayFabIDsFromSteamIDsRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetPlayFabIDsFromSteamIDsRequest>)each; } } }
            if (OnServerGetPlayFabIDsFromSteamIDsResultEvent != null) { foreach (var each in OnServerGetPlayFabIDsFromSteamIDsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayFabIDsFromSteamIDsResultEvent
 -= (PlayFabResultEvent<ServerModels.GetPlayFabIDsFromSteamIDsResult>)each; } } }

            if (OnServerGetPlayFabIDsFromXboxLiveIDsRequestEvent != null) { foreach (var each in OnServerGetPlayFabIDsFromXboxLiveIDsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayFabIDsFromXboxLiveIDsRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetPlayFabIDsFromXboxLiveIDsRequest>)each; } } }
            if (OnServerGetPlayFabIDsFromXboxLiveIDsResultEvent != null) { foreach (var each in OnServerGetPlayFabIDsFromXboxLiveIDsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPlayFabIDsFromXboxLiveIDsResultEvent
 -= (PlayFabResultEvent<ServerModels.GetPlayFabIDsFromXboxLiveIDsResult>)each; } } }

            if (OnServerGetPublisherDataRequestEvent != null) { foreach (var each in OnServerGetPublisherDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPublisherDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetPublisherDataRequest>)each; } } }
            if (OnServerGetPublisherDataResultEvent != null) { foreach (var each in OnServerGetPublisherDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetPublisherDataResultEvent
 -= (PlayFabResultEvent<ServerModels.GetPublisherDataResult>)each; } } }

            if (OnServerGetRandomResultTablesRequestEvent != null) { foreach (var each in OnServerGetRandomResultTablesRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetRandomResultTablesRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetRandomResultTablesRequest>)each; } } }
            if (OnServerGetRandomResultTablesResultEvent != null) { foreach (var each in OnServerGetRandomResultTablesResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetRandomResultTablesResultEvent
 -= (PlayFabResultEvent<ServerModels.GetRandomResultTablesResult>)each; } } }

            if (OnServerGetServerCustomIDsFromPlayFabIDsRequestEvent != null) { foreach (var each in OnServerGetServerCustomIDsFromPlayFabIDsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetServerCustomIDsFromPlayFabIDsRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetServerCustomIDsFromPlayFabIDsRequest>)each; } } }
            if (OnServerGetServerCustomIDsFromPlayFabIDsResultEvent != null) { foreach (var each in OnServerGetServerCustomIDsFromPlayFabIDsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetServerCustomIDsFromPlayFabIDsResultEvent
 -= (PlayFabResultEvent<ServerModels.GetServerCustomIDsFromPlayFabIDsResult>)each; } } }

            if (OnServerGetSharedGroupDataRequestEvent != null) { foreach (var each in OnServerGetSharedGroupDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetSharedGroupDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetSharedGroupDataRequest>)each; } } }
            if (OnServerGetSharedGroupDataResultEvent != null) { foreach (var each in OnServerGetSharedGroupDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetSharedGroupDataResultEvent
 -= (PlayFabResultEvent<ServerModels.GetSharedGroupDataResult>)each; } } }

            if (OnServerGetStoreItemsRequestEvent != null) { foreach (var each in OnServerGetStoreItemsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetStoreItemsRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetStoreItemsServerRequest>)each; } } }
            if (OnServerGetStoreItemsResultEvent != null) { foreach (var each in OnServerGetStoreItemsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetStoreItemsResultEvent
 -= (PlayFabResultEvent<ServerModels.GetStoreItemsResult>)each; } } }

            if (OnServerGetTimeRequestEvent != null) { foreach (var each in OnServerGetTimeRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetTimeRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetTimeRequest>)each; } } }
            if (OnServerGetTimeResultEvent != null) { foreach (var each in OnServerGetTimeResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetTimeResultEvent
 -= (PlayFabResultEvent<ServerModels.GetTimeResult>)each; } } }

            if (OnServerGetTitleDataRequestEvent != null) { foreach (var each in OnServerGetTitleDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetTitleDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetTitleDataRequest>)each; } } }
            if (OnServerGetTitleDataResultEvent != null) { foreach (var each in OnServerGetTitleDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetTitleDataResultEvent
 -= (PlayFabResultEvent<ServerModels.GetTitleDataResult>)each; } } }

            if (OnServerGetTitleInternalDataRequestEvent != null) { foreach (var each in OnServerGetTitleInternalDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetTitleInternalDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetTitleDataRequest>)each; } } }
            if (OnServerGetTitleInternalDataResultEvent != null) { foreach (var each in OnServerGetTitleInternalDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetTitleInternalDataResultEvent
 -= (PlayFabResultEvent<ServerModels.GetTitleDataResult>)each; } } }

            if (OnServerGetTitleNewsRequestEvent != null) { foreach (var each in OnServerGetTitleNewsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetTitleNewsRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetTitleNewsRequest>)each; } } }
            if (OnServerGetTitleNewsResultEvent != null) { foreach (var each in OnServerGetTitleNewsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetTitleNewsResultEvent
 -= (PlayFabResultEvent<ServerModels.GetTitleNewsResult>)each; } } }

            if (OnServerGetUserAccountInfoRequestEvent != null) { foreach (var each in OnServerGetUserAccountInfoRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetUserAccountInfoRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetUserAccountInfoRequest>)each; } } }
            if (OnServerGetUserAccountInfoResultEvent != null) { foreach (var each in OnServerGetUserAccountInfoResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetUserAccountInfoResultEvent
 -= (PlayFabResultEvent<ServerModels.GetUserAccountInfoResult>)each; } } }

            if (OnServerGetUserBansRequestEvent != null) { foreach (var each in OnServerGetUserBansRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetUserBansRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetUserBansRequest>)each; } } }
            if (OnServerGetUserBansResultEvent != null) { foreach (var each in OnServerGetUserBansResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetUserBansResultEvent
 -= (PlayFabResultEvent<ServerModels.GetUserBansResult>)each; } } }

            if (OnServerGetUserDataRequestEvent != null) { foreach (var each in OnServerGetUserDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetUserDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetUserDataRequest>)each; } } }
            if (OnServerGetUserDataResultEvent != null) { foreach (var each in OnServerGetUserDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetUserDataResultEvent
 -= (PlayFabResultEvent<ServerModels.GetUserDataResult>)each; } } }

            if (OnServerGetUserInternalDataRequestEvent != null) { foreach (var each in OnServerGetUserInternalDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetUserInternalDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetUserDataRequest>)each; } } }
            if (OnServerGetUserInternalDataResultEvent != null) { foreach (var each in OnServerGetUserInternalDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetUserInternalDataResultEvent
 -= (PlayFabResultEvent<ServerModels.GetUserDataResult>)each; } } }

            if (OnServerGetUserInventoryRequestEvent != null) { foreach (var each in OnServerGetUserInventoryRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetUserInventoryRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetUserInventoryRequest>)each; } } }
            if (OnServerGetUserInventoryResultEvent != null) { foreach (var each in OnServerGetUserInventoryResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetUserInventoryResultEvent
 -= (PlayFabResultEvent<ServerModels.GetUserInventoryResult>)each; } } }

            if (OnServerGetUserPublisherDataRequestEvent != null) { foreach (var each in OnServerGetUserPublisherDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetUserPublisherDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetUserDataRequest>)each; } } }
            if (OnServerGetUserPublisherDataResultEvent != null) { foreach (var each in OnServerGetUserPublisherDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetUserPublisherDataResultEvent
 -= (PlayFabResultEvent<ServerModels.GetUserDataResult>)each; } } }

            if (OnServerGetUserPublisherInternalDataRequestEvent != null) { foreach (var each in OnServerGetUserPublisherInternalDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetUserPublisherInternalDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetUserDataRequest>)each; } } }
            if (OnServerGetUserPublisherInternalDataResultEvent != null) { foreach (var each in OnServerGetUserPublisherInternalDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetUserPublisherInternalDataResultEvent
 -= (PlayFabResultEvent<ServerModels.GetUserDataResult>)each; } } }

            if (OnServerGetUserPublisherReadOnlyDataRequestEvent != null) { foreach (var each in OnServerGetUserPublisherReadOnlyDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetUserPublisherReadOnlyDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetUserDataRequest>)each; } } }
            if (OnServerGetUserPublisherReadOnlyDataResultEvent != null) { foreach (var each in OnServerGetUserPublisherReadOnlyDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetUserPublisherReadOnlyDataResultEvent
 -= (PlayFabResultEvent<ServerModels.GetUserDataResult>)each; } } }

            if (OnServerGetUserReadOnlyDataRequestEvent != null) { foreach (var each in OnServerGetUserReadOnlyDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetUserReadOnlyDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GetUserDataRequest>)each; } } }
            if (OnServerGetUserReadOnlyDataResultEvent != null) { foreach (var each in OnServerGetUserReadOnlyDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGetUserReadOnlyDataResultEvent
 -= (PlayFabResultEvent<ServerModels.GetUserDataResult>)each; } } }

            if (OnServerGrantCharacterToUserRequestEvent != null) { foreach (var each in OnServerGrantCharacterToUserRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGrantCharacterToUserRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GrantCharacterToUserRequest>)each; } } }
            if (OnServerGrantCharacterToUserResultEvent != null) { foreach (var each in OnServerGrantCharacterToUserResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGrantCharacterToUserResultEvent
 -= (PlayFabResultEvent<ServerModels.GrantCharacterToUserResult>)each; } } }

            if (OnServerGrantItemsToCharacterRequestEvent != null) { foreach (var each in OnServerGrantItemsToCharacterRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGrantItemsToCharacterRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GrantItemsToCharacterRequest>)each; } } }
            if (OnServerGrantItemsToCharacterResultEvent != null) { foreach (var each in OnServerGrantItemsToCharacterResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGrantItemsToCharacterResultEvent
 -= (PlayFabResultEvent<ServerModels.GrantItemsToCharacterResult>)each; } } }

            if (OnServerGrantItemsToUserRequestEvent != null) { foreach (var each in OnServerGrantItemsToUserRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGrantItemsToUserRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GrantItemsToUserRequest>)each; } } }
            if (OnServerGrantItemsToUserResultEvent != null) { foreach (var each in OnServerGrantItemsToUserResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGrantItemsToUserResultEvent
 -= (PlayFabResultEvent<ServerModels.GrantItemsToUserResult>)each; } } }

            if (OnServerGrantItemsToUsersRequestEvent != null) { foreach (var each in OnServerGrantItemsToUsersRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGrantItemsToUsersRequestEvent
 -= (PlayFabRequestEvent<ServerModels.GrantItemsToUsersRequest>)each; } } }
            if (OnServerGrantItemsToUsersResultEvent != null) { foreach (var each in OnServerGrantItemsToUsersResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerGrantItemsToUsersResultEvent
 -= (PlayFabResultEvent<ServerModels.GrantItemsToUsersResult>)each; } } }

            if (OnServerLinkPSNAccountRequestEvent != null) { foreach (var each in OnServerLinkPSNAccountRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerLinkPSNAccountRequestEvent
 -= (PlayFabRequestEvent<ServerModels.LinkPSNAccountRequest>)each; } } }
            if (OnServerLinkPSNAccountResultEvent != null) { foreach (var each in OnServerLinkPSNAccountResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerLinkPSNAccountResultEvent
 -= (PlayFabResultEvent<ServerModels.LinkPSNAccountResult>)each; } } }

            if (OnServerLinkServerCustomIdRequestEvent != null) { foreach (var each in OnServerLinkServerCustomIdRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerLinkServerCustomIdRequestEvent
 -= (PlayFabRequestEvent<ServerModels.LinkServerCustomIdRequest>)each; } } }
            if (OnServerLinkServerCustomIdResultEvent != null) { foreach (var each in OnServerLinkServerCustomIdResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerLinkServerCustomIdResultEvent
 -= (PlayFabResultEvent<ServerModels.LinkServerCustomIdResult>)each; } } }

            if (OnServerLinkXboxAccountRequestEvent != null) { foreach (var each in OnServerLinkXboxAccountRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerLinkXboxAccountRequestEvent
 -= (PlayFabRequestEvent<ServerModels.LinkXboxAccountRequest>)each; } } }
            if (OnServerLinkXboxAccountResultEvent != null) { foreach (var each in OnServerLinkXboxAccountResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerLinkXboxAccountResultEvent
 -= (PlayFabResultEvent<ServerModels.LinkXboxAccountResult>)each; } } }

            if (OnServerLoginWithServerCustomIdRequestEvent != null) { foreach (var each in OnServerLoginWithServerCustomIdRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerLoginWithServerCustomIdRequestEvent
 -= (PlayFabRequestEvent<ServerModels.LoginWithServerCustomIdRequest>)each; } } }
            if (OnServerLoginWithServerCustomIdResultEvent != null) { foreach (var each in OnServerLoginWithServerCustomIdResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerLoginWithServerCustomIdResultEvent
 -= (PlayFabResultEvent<ServerModels.ServerLoginResult>)each; } } }

            if (OnServerLoginWithXboxRequestEvent != null) { foreach (var each in OnServerLoginWithXboxRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerLoginWithXboxRequestEvent
 -= (PlayFabRequestEvent<ServerModels.LoginWithXboxRequest>)each; } } }
            if (OnServerLoginWithXboxResultEvent != null) { foreach (var each in OnServerLoginWithXboxResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerLoginWithXboxResultEvent
 -= (PlayFabResultEvent<ServerModels.ServerLoginResult>)each; } } }

            if (OnServerLoginWithXboxIdRequestEvent != null) { foreach (var each in OnServerLoginWithXboxIdRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerLoginWithXboxIdRequestEvent
 -= (PlayFabRequestEvent<ServerModels.LoginWithXboxIdRequest>)each; } } }
            if (OnServerLoginWithXboxIdResultEvent != null) { foreach (var each in OnServerLoginWithXboxIdResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerLoginWithXboxIdResultEvent
 -= (PlayFabResultEvent<ServerModels.ServerLoginResult>)each; } } }

            if (OnServerModifyItemUsesRequestEvent != null) { foreach (var each in OnServerModifyItemUsesRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerModifyItemUsesRequestEvent
 -= (PlayFabRequestEvent<ServerModels.ModifyItemUsesRequest>)each; } } }
            if (OnServerModifyItemUsesResultEvent != null) { foreach (var each in OnServerModifyItemUsesResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerModifyItemUsesResultEvent
 -= (PlayFabResultEvent<ServerModels.ModifyItemUsesResult>)each; } } }

            if (OnServerMoveItemToCharacterFromCharacterRequestEvent != null) { foreach (var each in OnServerMoveItemToCharacterFromCharacterRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerMoveItemToCharacterFromCharacterRequestEvent
 -= (PlayFabRequestEvent<ServerModels.MoveItemToCharacterFromCharacterRequest>)each; } } }
            if (OnServerMoveItemToCharacterFromCharacterResultEvent != null) { foreach (var each in OnServerMoveItemToCharacterFromCharacterResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerMoveItemToCharacterFromCharacterResultEvent
 -= (PlayFabResultEvent<ServerModels.MoveItemToCharacterFromCharacterResult>)each; } } }

            if (OnServerMoveItemToCharacterFromUserRequestEvent != null) { foreach (var each in OnServerMoveItemToCharacterFromUserRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerMoveItemToCharacterFromUserRequestEvent
 -= (PlayFabRequestEvent<ServerModels.MoveItemToCharacterFromUserRequest>)each; } } }
            if (OnServerMoveItemToCharacterFromUserResultEvent != null) { foreach (var each in OnServerMoveItemToCharacterFromUserResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerMoveItemToCharacterFromUserResultEvent
 -= (PlayFabResultEvent<ServerModels.MoveItemToCharacterFromUserResult>)each; } } }

            if (OnServerMoveItemToUserFromCharacterRequestEvent != null) { foreach (var each in OnServerMoveItemToUserFromCharacterRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerMoveItemToUserFromCharacterRequestEvent
 -= (PlayFabRequestEvent<ServerModels.MoveItemToUserFromCharacterRequest>)each; } } }
            if (OnServerMoveItemToUserFromCharacterResultEvent != null) { foreach (var each in OnServerMoveItemToUserFromCharacterResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerMoveItemToUserFromCharacterResultEvent
 -= (PlayFabResultEvent<ServerModels.MoveItemToUserFromCharacterResult>)each; } } }

            if (OnServerNotifyMatchmakerPlayerLeftRequestEvent != null) { foreach (var each in OnServerNotifyMatchmakerPlayerLeftRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerNotifyMatchmakerPlayerLeftRequestEvent
 -= (PlayFabRequestEvent<ServerModels.NotifyMatchmakerPlayerLeftRequest>)each; } } }
            if (OnServerNotifyMatchmakerPlayerLeftResultEvent != null) { foreach (var each in OnServerNotifyMatchmakerPlayerLeftResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerNotifyMatchmakerPlayerLeftResultEvent
 -= (PlayFabResultEvent<ServerModels.NotifyMatchmakerPlayerLeftResult>)each; } } }

            if (OnServerRedeemCouponRequestEvent != null) { foreach (var each in OnServerRedeemCouponRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRedeemCouponRequestEvent
 -= (PlayFabRequestEvent<ServerModels.RedeemCouponRequest>)each; } } }
            if (OnServerRedeemCouponResultEvent != null) { foreach (var each in OnServerRedeemCouponResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRedeemCouponResultEvent
 -= (PlayFabResultEvent<ServerModels.RedeemCouponResult>)each; } } }

            if (OnServerRedeemMatchmakerTicketRequestEvent != null) { foreach (var each in OnServerRedeemMatchmakerTicketRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRedeemMatchmakerTicketRequestEvent
 -= (PlayFabRequestEvent<ServerModels.RedeemMatchmakerTicketRequest>)each; } } }
            if (OnServerRedeemMatchmakerTicketResultEvent != null) { foreach (var each in OnServerRedeemMatchmakerTicketResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRedeemMatchmakerTicketResultEvent
 -= (PlayFabResultEvent<ServerModels.RedeemMatchmakerTicketResult>)each; } } }

            if (OnServerRefreshGameServerInstanceHeartbeatRequestEvent != null) { foreach (var each in OnServerRefreshGameServerInstanceHeartbeatRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRefreshGameServerInstanceHeartbeatRequestEvent
 -= (PlayFabRequestEvent<ServerModels.RefreshGameServerInstanceHeartbeatRequest>)each; } } }
            if (OnServerRefreshGameServerInstanceHeartbeatResultEvent != null) { foreach (var each in OnServerRefreshGameServerInstanceHeartbeatResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRefreshGameServerInstanceHeartbeatResultEvent
 -= (PlayFabResultEvent<ServerModels.RefreshGameServerInstanceHeartbeatResult>)each; } } }

            if (OnServerRegisterGameRequestEvent != null) { foreach (var each in OnServerRegisterGameRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRegisterGameRequestEvent
 -= (PlayFabRequestEvent<ServerModels.RegisterGameRequest>)each; } } }
            if (OnServerRegisterGameResultEvent != null) { foreach (var each in OnServerRegisterGameResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRegisterGameResultEvent
 -= (PlayFabResultEvent<ServerModels.RegisterGameResponse>)each; } } }

            if (OnServerRemoveFriendRequestEvent != null) { foreach (var each in OnServerRemoveFriendRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRemoveFriendRequestEvent
 -= (PlayFabRequestEvent<ServerModels.RemoveFriendRequest>)each; } } }
            if (OnServerRemoveFriendResultEvent != null) { foreach (var each in OnServerRemoveFriendResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRemoveFriendResultEvent
 -= (PlayFabResultEvent<ServerModels.EmptyResponse>)each; } } }

            if (OnServerRemoveGenericIDRequestEvent != null) { foreach (var each in OnServerRemoveGenericIDRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRemoveGenericIDRequestEvent
 -= (PlayFabRequestEvent<ServerModels.RemoveGenericIDRequest>)each; } } }
            if (OnServerRemoveGenericIDResultEvent != null) { foreach (var each in OnServerRemoveGenericIDResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRemoveGenericIDResultEvent
 -= (PlayFabResultEvent<ServerModels.EmptyResult>)each; } } }

            if (OnServerRemovePlayerTagRequestEvent != null) { foreach (var each in OnServerRemovePlayerTagRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRemovePlayerTagRequestEvent
 -= (PlayFabRequestEvent<ServerModels.RemovePlayerTagRequest>)each; } } }
            if (OnServerRemovePlayerTagResultEvent != null) { foreach (var each in OnServerRemovePlayerTagResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRemovePlayerTagResultEvent
 -= (PlayFabResultEvent<ServerModels.RemovePlayerTagResult>)each; } } }

            if (OnServerRemoveSharedGroupMembersRequestEvent != null) { foreach (var each in OnServerRemoveSharedGroupMembersRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRemoveSharedGroupMembersRequestEvent
 -= (PlayFabRequestEvent<ServerModels.RemoveSharedGroupMembersRequest>)each; } } }
            if (OnServerRemoveSharedGroupMembersResultEvent != null) { foreach (var each in OnServerRemoveSharedGroupMembersResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRemoveSharedGroupMembersResultEvent
 -= (PlayFabResultEvent<ServerModels.RemoveSharedGroupMembersResult>)each; } } }

            if (OnServerReportPlayerRequestEvent != null) { foreach (var each in OnServerReportPlayerRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerReportPlayerRequestEvent
 -= (PlayFabRequestEvent<ServerModels.ReportPlayerServerRequest>)each; } } }
            if (OnServerReportPlayerResultEvent != null) { foreach (var each in OnServerReportPlayerResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerReportPlayerResultEvent
 -= (PlayFabResultEvent<ServerModels.ReportPlayerServerResult>)each; } } }

            if (OnServerRevokeAllBansForUserRequestEvent != null) { foreach (var each in OnServerRevokeAllBansForUserRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRevokeAllBansForUserRequestEvent
 -= (PlayFabRequestEvent<ServerModels.RevokeAllBansForUserRequest>)each; } } }
            if (OnServerRevokeAllBansForUserResultEvent != null) { foreach (var each in OnServerRevokeAllBansForUserResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRevokeAllBansForUserResultEvent
 -= (PlayFabResultEvent<ServerModels.RevokeAllBansForUserResult>)each; } } }

            if (OnServerRevokeBansRequestEvent != null) { foreach (var each in OnServerRevokeBansRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRevokeBansRequestEvent
 -= (PlayFabRequestEvent<ServerModels.RevokeBansRequest>)each; } } }
            if (OnServerRevokeBansResultEvent != null) { foreach (var each in OnServerRevokeBansResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRevokeBansResultEvent
 -= (PlayFabResultEvent<ServerModels.RevokeBansResult>)each; } } }

            if (OnServerRevokeInventoryItemRequestEvent != null) { foreach (var each in OnServerRevokeInventoryItemRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRevokeInventoryItemRequestEvent
 -= (PlayFabRequestEvent<ServerModels.RevokeInventoryItemRequest>)each; } } }
            if (OnServerRevokeInventoryItemResultEvent != null) { foreach (var each in OnServerRevokeInventoryItemResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRevokeInventoryItemResultEvent
 -= (PlayFabResultEvent<ServerModels.RevokeInventoryResult>)each; } } }

            if (OnServerRevokeInventoryItemsRequestEvent != null) { foreach (var each in OnServerRevokeInventoryItemsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRevokeInventoryItemsRequestEvent
 -= (PlayFabRequestEvent<ServerModels.RevokeInventoryItemsRequest>)each; } } }
            if (OnServerRevokeInventoryItemsResultEvent != null) { foreach (var each in OnServerRevokeInventoryItemsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerRevokeInventoryItemsResultEvent
 -= (PlayFabResultEvent<ServerModels.RevokeInventoryItemsResult>)each; } } }

            if (OnServerSavePushNotificationTemplateRequestEvent != null) { foreach (var each in OnServerSavePushNotificationTemplateRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSavePushNotificationTemplateRequestEvent
 -= (PlayFabRequestEvent<ServerModels.SavePushNotificationTemplateRequest>)each; } } }
            if (OnServerSavePushNotificationTemplateResultEvent != null) { foreach (var each in OnServerSavePushNotificationTemplateResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSavePushNotificationTemplateResultEvent
 -= (PlayFabResultEvent<ServerModels.SavePushNotificationTemplateResult>)each; } } }

            if (OnServerSendCustomAccountRecoveryEmailRequestEvent != null) { foreach (var each in OnServerSendCustomAccountRecoveryEmailRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSendCustomAccountRecoveryEmailRequestEvent
 -= (PlayFabRequestEvent<ServerModels.SendCustomAccountRecoveryEmailRequest>)each; } } }
            if (OnServerSendCustomAccountRecoveryEmailResultEvent != null) { foreach (var each in OnServerSendCustomAccountRecoveryEmailResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSendCustomAccountRecoveryEmailResultEvent
 -= (PlayFabResultEvent<ServerModels.SendCustomAccountRecoveryEmailResult>)each; } } }

            if (OnServerSendEmailFromTemplateRequestEvent != null) { foreach (var each in OnServerSendEmailFromTemplateRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSendEmailFromTemplateRequestEvent
 -= (PlayFabRequestEvent<ServerModels.SendEmailFromTemplateRequest>)each; } } }
            if (OnServerSendEmailFromTemplateResultEvent != null) { foreach (var each in OnServerSendEmailFromTemplateResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSendEmailFromTemplateResultEvent
 -= (PlayFabResultEvent<ServerModels.SendEmailFromTemplateResult>)each; } } }

            if (OnServerSendPushNotificationRequestEvent != null) { foreach (var each in OnServerSendPushNotificationRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSendPushNotificationRequestEvent
 -= (PlayFabRequestEvent<ServerModels.SendPushNotificationRequest>)each; } } }
            if (OnServerSendPushNotificationResultEvent != null) { foreach (var each in OnServerSendPushNotificationResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSendPushNotificationResultEvent
 -= (PlayFabResultEvent<ServerModels.SendPushNotificationResult>)each; } } }

            if (OnServerSendPushNotificationFromTemplateRequestEvent != null) { foreach (var each in OnServerSendPushNotificationFromTemplateRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSendPushNotificationFromTemplateRequestEvent
 -= (PlayFabRequestEvent<ServerModels.SendPushNotificationFromTemplateRequest>)each; } } }
            if (OnServerSendPushNotificationFromTemplateResultEvent != null) { foreach (var each in OnServerSendPushNotificationFromTemplateResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSendPushNotificationFromTemplateResultEvent
 -= (PlayFabResultEvent<ServerModels.SendPushNotificationResult>)each; } } }

            if (OnServerSetFriendTagsRequestEvent != null) { foreach (var each in OnServerSetFriendTagsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSetFriendTagsRequestEvent
 -= (PlayFabRequestEvent<ServerModels.SetFriendTagsRequest>)each; } } }
            if (OnServerSetFriendTagsResultEvent != null) { foreach (var each in OnServerSetFriendTagsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSetFriendTagsResultEvent
 -= (PlayFabResultEvent<ServerModels.EmptyResponse>)each; } } }

            if (OnServerSetGameServerInstanceDataRequestEvent != null) { foreach (var each in OnServerSetGameServerInstanceDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSetGameServerInstanceDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.SetGameServerInstanceDataRequest>)each; } } }
            if (OnServerSetGameServerInstanceDataResultEvent != null) { foreach (var each in OnServerSetGameServerInstanceDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSetGameServerInstanceDataResultEvent
 -= (PlayFabResultEvent<ServerModels.SetGameServerInstanceDataResult>)each; } } }

            if (OnServerSetGameServerInstanceStateRequestEvent != null) { foreach (var each in OnServerSetGameServerInstanceStateRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSetGameServerInstanceStateRequestEvent
 -= (PlayFabRequestEvent<ServerModels.SetGameServerInstanceStateRequest>)each; } } }
            if (OnServerSetGameServerInstanceStateResultEvent != null) { foreach (var each in OnServerSetGameServerInstanceStateResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSetGameServerInstanceStateResultEvent
 -= (PlayFabResultEvent<ServerModels.SetGameServerInstanceStateResult>)each; } } }

            if (OnServerSetGameServerInstanceTagsRequestEvent != null) { foreach (var each in OnServerSetGameServerInstanceTagsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSetGameServerInstanceTagsRequestEvent
 -= (PlayFabRequestEvent<ServerModels.SetGameServerInstanceTagsRequest>)each; } } }
            if (OnServerSetGameServerInstanceTagsResultEvent != null) { foreach (var each in OnServerSetGameServerInstanceTagsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSetGameServerInstanceTagsResultEvent
 -= (PlayFabResultEvent<ServerModels.SetGameServerInstanceTagsResult>)each; } } }

            if (OnServerSetPlayerSecretRequestEvent != null) { foreach (var each in OnServerSetPlayerSecretRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSetPlayerSecretRequestEvent
 -= (PlayFabRequestEvent<ServerModels.SetPlayerSecretRequest>)each; } } }
            if (OnServerSetPlayerSecretResultEvent != null) { foreach (var each in OnServerSetPlayerSecretResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSetPlayerSecretResultEvent
 -= (PlayFabResultEvent<ServerModels.SetPlayerSecretResult>)each; } } }

            if (OnServerSetPublisherDataRequestEvent != null) { foreach (var each in OnServerSetPublisherDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSetPublisherDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.SetPublisherDataRequest>)each; } } }
            if (OnServerSetPublisherDataResultEvent != null) { foreach (var each in OnServerSetPublisherDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSetPublisherDataResultEvent
 -= (PlayFabResultEvent<ServerModels.SetPublisherDataResult>)each; } } }

            if (OnServerSetTitleDataRequestEvent != null) { foreach (var each in OnServerSetTitleDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSetTitleDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.SetTitleDataRequest>)each; } } }
            if (OnServerSetTitleDataResultEvent != null) { foreach (var each in OnServerSetTitleDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSetTitleDataResultEvent
 -= (PlayFabResultEvent<ServerModels.SetTitleDataResult>)each; } } }

            if (OnServerSetTitleInternalDataRequestEvent != null) { foreach (var each in OnServerSetTitleInternalDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSetTitleInternalDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.SetTitleDataRequest>)each; } } }
            if (OnServerSetTitleInternalDataResultEvent != null) { foreach (var each in OnServerSetTitleInternalDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSetTitleInternalDataResultEvent
 -= (PlayFabResultEvent<ServerModels.SetTitleDataResult>)each; } } }

            if (OnServerSubtractCharacterVirtualCurrencyRequestEvent != null) { foreach (var each in OnServerSubtractCharacterVirtualCurrencyRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSubtractCharacterVirtualCurrencyRequestEvent
 -= (PlayFabRequestEvent<ServerModels.SubtractCharacterVirtualCurrencyRequest>)each; } } }
            if (OnServerSubtractCharacterVirtualCurrencyResultEvent != null) { foreach (var each in OnServerSubtractCharacterVirtualCurrencyResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSubtractCharacterVirtualCurrencyResultEvent
 -= (PlayFabResultEvent<ServerModels.ModifyCharacterVirtualCurrencyResult>)each; } } }

            if (OnServerSubtractUserVirtualCurrencyRequestEvent != null) { foreach (var each in OnServerSubtractUserVirtualCurrencyRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSubtractUserVirtualCurrencyRequestEvent
 -= (PlayFabRequestEvent<ServerModels.SubtractUserVirtualCurrencyRequest>)each; } } }
            if (OnServerSubtractUserVirtualCurrencyResultEvent != null) { foreach (var each in OnServerSubtractUserVirtualCurrencyResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerSubtractUserVirtualCurrencyResultEvent
 -= (PlayFabResultEvent<ServerModels.ModifyUserVirtualCurrencyResult>)each; } } }

            if (OnServerUnlinkPSNAccountRequestEvent != null) { foreach (var each in OnServerUnlinkPSNAccountRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUnlinkPSNAccountRequestEvent
 -= (PlayFabRequestEvent<ServerModels.UnlinkPSNAccountRequest>)each; } } }
            if (OnServerUnlinkPSNAccountResultEvent != null) { foreach (var each in OnServerUnlinkPSNAccountResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUnlinkPSNAccountResultEvent
 -= (PlayFabResultEvent<ServerModels.UnlinkPSNAccountResult>)each; } } }

            if (OnServerUnlinkServerCustomIdRequestEvent != null) { foreach (var each in OnServerUnlinkServerCustomIdRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUnlinkServerCustomIdRequestEvent
 -= (PlayFabRequestEvent<ServerModels.UnlinkServerCustomIdRequest>)each; } } }
            if (OnServerUnlinkServerCustomIdResultEvent != null) { foreach (var each in OnServerUnlinkServerCustomIdResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUnlinkServerCustomIdResultEvent
 -= (PlayFabResultEvent<ServerModels.UnlinkServerCustomIdResult>)each; } } }

            if (OnServerUnlinkXboxAccountRequestEvent != null) { foreach (var each in OnServerUnlinkXboxAccountRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUnlinkXboxAccountRequestEvent
 -= (PlayFabRequestEvent<ServerModels.UnlinkXboxAccountRequest>)each; } } }
            if (OnServerUnlinkXboxAccountResultEvent != null) { foreach (var each in OnServerUnlinkXboxAccountResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUnlinkXboxAccountResultEvent
 -= (PlayFabResultEvent<ServerModels.UnlinkXboxAccountResult>)each; } } }

            if (OnServerUnlockContainerInstanceRequestEvent != null) { foreach (var each in OnServerUnlockContainerInstanceRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUnlockContainerInstanceRequestEvent
 -= (PlayFabRequestEvent<ServerModels.UnlockContainerInstanceRequest>)each; } } }
            if (OnServerUnlockContainerInstanceResultEvent != null) { foreach (var each in OnServerUnlockContainerInstanceResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUnlockContainerInstanceResultEvent
 -= (PlayFabResultEvent<ServerModels.UnlockContainerItemResult>)each; } } }

            if (OnServerUnlockContainerItemRequestEvent != null) { foreach (var each in OnServerUnlockContainerItemRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUnlockContainerItemRequestEvent
 -= (PlayFabRequestEvent<ServerModels.UnlockContainerItemRequest>)each; } } }
            if (OnServerUnlockContainerItemResultEvent != null) { foreach (var each in OnServerUnlockContainerItemResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUnlockContainerItemResultEvent
 -= (PlayFabResultEvent<ServerModels.UnlockContainerItemResult>)each; } } }

            if (OnServerUpdateAvatarUrlRequestEvent != null) { foreach (var each in OnServerUpdateAvatarUrlRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateAvatarUrlRequestEvent
 -= (PlayFabRequestEvent<ServerModels.UpdateAvatarUrlRequest>)each; } } }
            if (OnServerUpdateAvatarUrlResultEvent != null) { foreach (var each in OnServerUpdateAvatarUrlResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateAvatarUrlResultEvent
 -= (PlayFabResultEvent<ServerModels.EmptyResponse>)each; } } }

            if (OnServerUpdateBansRequestEvent != null) { foreach (var each in OnServerUpdateBansRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateBansRequestEvent
 -= (PlayFabRequestEvent<ServerModels.UpdateBansRequest>)each; } } }
            if (OnServerUpdateBansResultEvent != null) { foreach (var each in OnServerUpdateBansResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateBansResultEvent
 -= (PlayFabResultEvent<ServerModels.UpdateBansResult>)each; } } }

            if (OnServerUpdateCharacterDataRequestEvent != null) { foreach (var each in OnServerUpdateCharacterDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateCharacterDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.UpdateCharacterDataRequest>)each; } } }
            if (OnServerUpdateCharacterDataResultEvent != null) { foreach (var each in OnServerUpdateCharacterDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateCharacterDataResultEvent
 -= (PlayFabResultEvent<ServerModels.UpdateCharacterDataResult>)each; } } }

            if (OnServerUpdateCharacterInternalDataRequestEvent != null) { foreach (var each in OnServerUpdateCharacterInternalDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateCharacterInternalDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.UpdateCharacterDataRequest>)each; } } }
            if (OnServerUpdateCharacterInternalDataResultEvent != null) { foreach (var each in OnServerUpdateCharacterInternalDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateCharacterInternalDataResultEvent
 -= (PlayFabResultEvent<ServerModels.UpdateCharacterDataResult>)each; } } }

            if (OnServerUpdateCharacterReadOnlyDataRequestEvent != null) { foreach (var each in OnServerUpdateCharacterReadOnlyDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateCharacterReadOnlyDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.UpdateCharacterDataRequest>)each; } } }
            if (OnServerUpdateCharacterReadOnlyDataResultEvent != null) { foreach (var each in OnServerUpdateCharacterReadOnlyDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateCharacterReadOnlyDataResultEvent
 -= (PlayFabResultEvent<ServerModels.UpdateCharacterDataResult>)each; } } }

            if (OnServerUpdateCharacterStatisticsRequestEvent != null) { foreach (var each in OnServerUpdateCharacterStatisticsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateCharacterStatisticsRequestEvent
 -= (PlayFabRequestEvent<ServerModels.UpdateCharacterStatisticsRequest>)each; } } }
            if (OnServerUpdateCharacterStatisticsResultEvent != null) { foreach (var each in OnServerUpdateCharacterStatisticsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateCharacterStatisticsResultEvent
 -= (PlayFabResultEvent<ServerModels.UpdateCharacterStatisticsResult>)each; } } }

            if (OnServerUpdatePlayerStatisticsRequestEvent != null) { foreach (var each in OnServerUpdatePlayerStatisticsRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdatePlayerStatisticsRequestEvent
 -= (PlayFabRequestEvent<ServerModels.UpdatePlayerStatisticsRequest>)each; } } }
            if (OnServerUpdatePlayerStatisticsResultEvent != null) { foreach (var each in OnServerUpdatePlayerStatisticsResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdatePlayerStatisticsResultEvent
 -= (PlayFabResultEvent<ServerModels.UpdatePlayerStatisticsResult>)each; } } }

            if (OnServerUpdateSharedGroupDataRequestEvent != null) { foreach (var each in OnServerUpdateSharedGroupDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateSharedGroupDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.UpdateSharedGroupDataRequest>)each; } } }
            if (OnServerUpdateSharedGroupDataResultEvent != null) { foreach (var each in OnServerUpdateSharedGroupDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateSharedGroupDataResultEvent
 -= (PlayFabResultEvent<ServerModels.UpdateSharedGroupDataResult>)each; } } }

            if (OnServerUpdateUserDataRequestEvent != null) { foreach (var each in OnServerUpdateUserDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateUserDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.UpdateUserDataRequest>)each; } } }
            if (OnServerUpdateUserDataResultEvent != null) { foreach (var each in OnServerUpdateUserDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateUserDataResultEvent
 -= (PlayFabResultEvent<ServerModels.UpdateUserDataResult>)each; } } }

            if (OnServerUpdateUserInternalDataRequestEvent != null) { foreach (var each in OnServerUpdateUserInternalDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateUserInternalDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.UpdateUserInternalDataRequest>)each; } } }
            if (OnServerUpdateUserInternalDataResultEvent != null) { foreach (var each in OnServerUpdateUserInternalDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateUserInternalDataResultEvent
 -= (PlayFabResultEvent<ServerModels.UpdateUserDataResult>)each; } } }

            if (OnServerUpdateUserInventoryItemCustomDataRequestEvent != null) { foreach (var each in OnServerUpdateUserInventoryItemCustomDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateUserInventoryItemCustomDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.UpdateUserInventoryItemDataRequest>)each; } } }
            if (OnServerUpdateUserInventoryItemCustomDataResultEvent != null) { foreach (var each in OnServerUpdateUserInventoryItemCustomDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateUserInventoryItemCustomDataResultEvent
 -= (PlayFabResultEvent<ServerModels.EmptyResponse>)each; } } }

            if (OnServerUpdateUserPublisherDataRequestEvent != null) { foreach (var each in OnServerUpdateUserPublisherDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateUserPublisherDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.UpdateUserDataRequest>)each; } } }
            if (OnServerUpdateUserPublisherDataResultEvent != null) { foreach (var each in OnServerUpdateUserPublisherDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateUserPublisherDataResultEvent
 -= (PlayFabResultEvent<ServerModels.UpdateUserDataResult>)each; } } }

            if (OnServerUpdateUserPublisherInternalDataRequestEvent != null) { foreach (var each in OnServerUpdateUserPublisherInternalDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateUserPublisherInternalDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.UpdateUserInternalDataRequest>)each; } } }
            if (OnServerUpdateUserPublisherInternalDataResultEvent != null) { foreach (var each in OnServerUpdateUserPublisherInternalDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateUserPublisherInternalDataResultEvent
 -= (PlayFabResultEvent<ServerModels.UpdateUserDataResult>)each; } } }

            if (OnServerUpdateUserPublisherReadOnlyDataRequestEvent != null) { foreach (var each in OnServerUpdateUserPublisherReadOnlyDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateUserPublisherReadOnlyDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.UpdateUserDataRequest>)each; } } }
            if (OnServerUpdateUserPublisherReadOnlyDataResultEvent != null) { foreach (var each in OnServerUpdateUserPublisherReadOnlyDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateUserPublisherReadOnlyDataResultEvent
 -= (PlayFabResultEvent<ServerModels.UpdateUserDataResult>)each; } } }

            if (OnServerUpdateUserReadOnlyDataRequestEvent != null) { foreach (var each in OnServerUpdateUserReadOnlyDataRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateUserReadOnlyDataRequestEvent
 -= (PlayFabRequestEvent<ServerModels.UpdateUserDataRequest>)each; } } }
            if (OnServerUpdateUserReadOnlyDataResultEvent != null) { foreach (var each in OnServerUpdateUserReadOnlyDataResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerUpdateUserReadOnlyDataResultEvent
 -= (PlayFabResultEvent<ServerModels.UpdateUserDataResult>)each; } } }

            if (OnServerWriteCharacterEventRequestEvent != null) { foreach (var each in OnServerWriteCharacterEventRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerWriteCharacterEventRequestEvent
 -= (PlayFabRequestEvent<ServerModels.WriteServerCharacterEventRequest>)each; } } }
            if (OnServerWriteCharacterEventResultEvent != null) { foreach (var each in OnServerWriteCharacterEventResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerWriteCharacterEventResultEvent
 -= (PlayFabResultEvent<ServerModels.WriteEventResponse>)each; } } }

            if (OnServerWritePlayerEventRequestEvent != null) { foreach (var each in OnServerWritePlayerEventRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerWritePlayerEventRequestEvent
 -= (PlayFabRequestEvent<ServerModels.WriteServerPlayerEventRequest>)each; } } }
            if (OnServerWritePlayerEventResultEvent != null) { foreach (var each in OnServerWritePlayerEventResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerWritePlayerEventResultEvent
 -= (PlayFabResultEvent<ServerModels.WriteEventResponse>)each; } } }

            if (OnServerWriteTitleEventRequestEvent != null) { foreach (var each in OnServerWriteTitleEventRequestEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerWriteTitleEventRequestEvent
 -= (PlayFabRequestEvent<ServerModels.WriteTitleEventRequest>)each; } } }
            if (OnServerWriteTitleEventResultEvent != null) { foreach (var each in OnServerWriteTitleEventResultEvent.GetInvocationList()) { if (ReferenceEquals(each.Target, instance)) { OnServerWriteTitleEventResultEvent
 -= (PlayFabResultEvent<ServerModels.WriteEventResponse>)each; } } }

#endif
#if !DISABLE_PLAYFABENTITY_API
      if (OnAuthenticationGetEntityTokenRequestEvent != null)
        foreach (var each in OnAuthenticationGetEntityTokenRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnAuthenticationGetEntityTokenRequestEvent -=
              (PlayFabRequestEvent<AuthenticationModels.GetEntityTokenRequest>) each;
      if (OnAuthenticationGetEntityTokenResultEvent != null)
        foreach (var each in OnAuthenticationGetEntityTokenResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnAuthenticationGetEntityTokenResultEvent -=
              (PlayFabResultEvent<AuthenticationModels.GetEntityTokenResponse>) each;

      if (OnAuthenticationValidateEntityTokenRequestEvent != null)
        foreach (var each in OnAuthenticationValidateEntityTokenRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnAuthenticationValidateEntityTokenRequestEvent -=
              (PlayFabRequestEvent<AuthenticationModels.ValidateEntityTokenRequest>) each;
      if (OnAuthenticationValidateEntityTokenResultEvent != null)
        foreach (var each in OnAuthenticationValidateEntityTokenResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnAuthenticationValidateEntityTokenResultEvent -=
              (PlayFabResultEvent<AuthenticationModels.ValidateEntityTokenResponse>) each;

#endif
#if !DISABLE_PLAYFABENTITY_API
      if (OnCloudScriptExecuteEntityCloudScriptRequestEvent != null)
        foreach (var each in OnCloudScriptExecuteEntityCloudScriptRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptExecuteEntityCloudScriptRequestEvent -=
              (PlayFabRequestEvent<CloudScriptModels.ExecuteEntityCloudScriptRequest>) each;
      if (OnCloudScriptExecuteEntityCloudScriptResultEvent != null)
        foreach (var each in OnCloudScriptExecuteEntityCloudScriptResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptExecuteEntityCloudScriptResultEvent -=
              (PlayFabResultEvent<CloudScriptModels.ExecuteCloudScriptResult>) each;

      if (OnCloudScriptExecuteFunctionRequestEvent != null)
        foreach (var each in OnCloudScriptExecuteFunctionRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptExecuteFunctionRequestEvent -=
              (PlayFabRequestEvent<CloudScriptModels.ExecuteFunctionRequest>) each;
      if (OnCloudScriptExecuteFunctionResultEvent != null)
        foreach (var each in OnCloudScriptExecuteFunctionResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptExecuteFunctionResultEvent -=
              (PlayFabResultEvent<CloudScriptModels.ExecuteFunctionResult>) each;

      if (OnCloudScriptListFunctionsRequestEvent != null)
        foreach (var each in OnCloudScriptListFunctionsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptListFunctionsRequestEvent -=
              (PlayFabRequestEvent<CloudScriptModels.ListFunctionsRequest>) each;
      if (OnCloudScriptListFunctionsResultEvent != null)
        foreach (var each in OnCloudScriptListFunctionsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptListFunctionsResultEvent -= (PlayFabResultEvent<CloudScriptModels.ListFunctionsResult>) each;

      if (OnCloudScriptListHttpFunctionsRequestEvent != null)
        foreach (var each in OnCloudScriptListHttpFunctionsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptListHttpFunctionsRequestEvent -=
              (PlayFabRequestEvent<CloudScriptModels.ListFunctionsRequest>) each;
      if (OnCloudScriptListHttpFunctionsResultEvent != null)
        foreach (var each in OnCloudScriptListHttpFunctionsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptListHttpFunctionsResultEvent -=
              (PlayFabResultEvent<CloudScriptModels.ListHttpFunctionsResult>) each;

      if (OnCloudScriptListQueuedFunctionsRequestEvent != null)
        foreach (var each in OnCloudScriptListQueuedFunctionsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptListQueuedFunctionsRequestEvent -=
              (PlayFabRequestEvent<CloudScriptModels.ListFunctionsRequest>) each;
      if (OnCloudScriptListQueuedFunctionsResultEvent != null)
        foreach (var each in OnCloudScriptListQueuedFunctionsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptListQueuedFunctionsResultEvent -=
              (PlayFabResultEvent<CloudScriptModels.ListQueuedFunctionsResult>) each;

      if (OnCloudScriptPostFunctionResultForEntityTriggeredActionRequestEvent != null)
        foreach (var each in OnCloudScriptPostFunctionResultForEntityTriggeredActionRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptPostFunctionResultForEntityTriggeredActionRequestEvent -=
              (PlayFabRequestEvent<CloudScriptModels.PostFunctionResultForEntityTriggeredActionRequest>) each;
      if (OnCloudScriptPostFunctionResultForEntityTriggeredActionResultEvent != null)
        foreach (var each in OnCloudScriptPostFunctionResultForEntityTriggeredActionResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptPostFunctionResultForEntityTriggeredActionResultEvent -=
              (PlayFabResultEvent<CloudScriptModels.EmptyResult>) each;

      if (OnCloudScriptPostFunctionResultForFunctionExecutionRequestEvent != null)
        foreach (var each in OnCloudScriptPostFunctionResultForFunctionExecutionRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptPostFunctionResultForFunctionExecutionRequestEvent -=
              (PlayFabRequestEvent<CloudScriptModels.PostFunctionResultForFunctionExecutionRequest>) each;
      if (OnCloudScriptPostFunctionResultForFunctionExecutionResultEvent != null)
        foreach (var each in OnCloudScriptPostFunctionResultForFunctionExecutionResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptPostFunctionResultForFunctionExecutionResultEvent -=
              (PlayFabResultEvent<CloudScriptModels.EmptyResult>) each;

      if (OnCloudScriptPostFunctionResultForPlayerTriggeredActionRequestEvent != null)
        foreach (var each in OnCloudScriptPostFunctionResultForPlayerTriggeredActionRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptPostFunctionResultForPlayerTriggeredActionRequestEvent -=
              (PlayFabRequestEvent<CloudScriptModels.PostFunctionResultForPlayerTriggeredActionRequest>) each;
      if (OnCloudScriptPostFunctionResultForPlayerTriggeredActionResultEvent != null)
        foreach (var each in OnCloudScriptPostFunctionResultForPlayerTriggeredActionResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptPostFunctionResultForPlayerTriggeredActionResultEvent -=
              (PlayFabResultEvent<CloudScriptModels.EmptyResult>) each;

      if (OnCloudScriptPostFunctionResultForScheduledTaskRequestEvent != null)
        foreach (var each in OnCloudScriptPostFunctionResultForScheduledTaskRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptPostFunctionResultForScheduledTaskRequestEvent -=
              (PlayFabRequestEvent<CloudScriptModels.PostFunctionResultForScheduledTaskRequest>) each;
      if (OnCloudScriptPostFunctionResultForScheduledTaskResultEvent != null)
        foreach (var each in OnCloudScriptPostFunctionResultForScheduledTaskResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptPostFunctionResultForScheduledTaskResultEvent -=
              (PlayFabResultEvent<CloudScriptModels.EmptyResult>) each;

      if (OnCloudScriptRegisterHttpFunctionRequestEvent != null)
        foreach (var each in OnCloudScriptRegisterHttpFunctionRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptRegisterHttpFunctionRequestEvent -=
              (PlayFabRequestEvent<CloudScriptModels.RegisterHttpFunctionRequest>) each;
      if (OnCloudScriptRegisterHttpFunctionResultEvent != null)
        foreach (var each in OnCloudScriptRegisterHttpFunctionResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptRegisterHttpFunctionResultEvent -= (PlayFabResultEvent<CloudScriptModels.EmptyResult>) each;

      if (OnCloudScriptRegisterQueuedFunctionRequestEvent != null)
        foreach (var each in OnCloudScriptRegisterQueuedFunctionRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptRegisterQueuedFunctionRequestEvent -=
              (PlayFabRequestEvent<CloudScriptModels.RegisterQueuedFunctionRequest>) each;
      if (OnCloudScriptRegisterQueuedFunctionResultEvent != null)
        foreach (var each in OnCloudScriptRegisterQueuedFunctionResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptRegisterQueuedFunctionResultEvent -= (PlayFabResultEvent<CloudScriptModels.EmptyResult>) each;

      if (OnCloudScriptUnregisterFunctionRequestEvent != null)
        foreach (var each in OnCloudScriptUnregisterFunctionRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptUnregisterFunctionRequestEvent -=
              (PlayFabRequestEvent<CloudScriptModels.UnregisterFunctionRequest>) each;
      if (OnCloudScriptUnregisterFunctionResultEvent != null)
        foreach (var each in OnCloudScriptUnregisterFunctionResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnCloudScriptUnregisterFunctionResultEvent -= (PlayFabResultEvent<CloudScriptModels.EmptyResult>) each;

#endif
#if !DISABLE_PLAYFABENTITY_API
      if (OnDataAbortFileUploadsRequestEvent != null)
        foreach (var each in OnDataAbortFileUploadsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnDataAbortFileUploadsRequestEvent -= (PlayFabRequestEvent<DataModels.AbortFileUploadsRequest>) each;
      if (OnDataAbortFileUploadsResultEvent != null)
        foreach (var each in OnDataAbortFileUploadsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnDataAbortFileUploadsResultEvent -= (PlayFabResultEvent<DataModels.AbortFileUploadsResponse>) each;

      if (OnDataDeleteFilesRequestEvent != null)
        foreach (var each in OnDataDeleteFilesRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnDataDeleteFilesRequestEvent -= (PlayFabRequestEvent<DataModels.DeleteFilesRequest>) each;
      if (OnDataDeleteFilesResultEvent != null)
        foreach (var each in OnDataDeleteFilesResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnDataDeleteFilesResultEvent -= (PlayFabResultEvent<DataModels.DeleteFilesResponse>) each;

      if (OnDataFinalizeFileUploadsRequestEvent != null)
        foreach (var each in OnDataFinalizeFileUploadsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnDataFinalizeFileUploadsRequestEvent -= (PlayFabRequestEvent<DataModels.FinalizeFileUploadsRequest>) each;
      if (OnDataFinalizeFileUploadsResultEvent != null)
        foreach (var each in OnDataFinalizeFileUploadsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnDataFinalizeFileUploadsResultEvent -= (PlayFabResultEvent<DataModels.FinalizeFileUploadsResponse>) each;

      if (OnDataGetFilesRequestEvent != null)
        foreach (var each in OnDataGetFilesRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnDataGetFilesRequestEvent -= (PlayFabRequestEvent<DataModels.GetFilesRequest>) each;
      if (OnDataGetFilesResultEvent != null)
        foreach (var each in OnDataGetFilesResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnDataGetFilesResultEvent -= (PlayFabResultEvent<DataModels.GetFilesResponse>) each;

      if (OnDataGetObjectsRequestEvent != null)
        foreach (var each in OnDataGetObjectsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnDataGetObjectsRequestEvent -= (PlayFabRequestEvent<DataModels.GetObjectsRequest>) each;
      if (OnDataGetObjectsResultEvent != null)
        foreach (var each in OnDataGetObjectsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnDataGetObjectsResultEvent -= (PlayFabResultEvent<DataModels.GetObjectsResponse>) each;

      if (OnDataInitiateFileUploadsRequestEvent != null)
        foreach (var each in OnDataInitiateFileUploadsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnDataInitiateFileUploadsRequestEvent -= (PlayFabRequestEvent<DataModels.InitiateFileUploadsRequest>) each;
      if (OnDataInitiateFileUploadsResultEvent != null)
        foreach (var each in OnDataInitiateFileUploadsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnDataInitiateFileUploadsResultEvent -= (PlayFabResultEvent<DataModels.InitiateFileUploadsResponse>) each;

      if (OnDataSetObjectsRequestEvent != null)
        foreach (var each in OnDataSetObjectsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnDataSetObjectsRequestEvent -= (PlayFabRequestEvent<DataModels.SetObjectsRequest>) each;
      if (OnDataSetObjectsResultEvent != null)
        foreach (var each in OnDataSetObjectsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnDataSetObjectsResultEvent -= (PlayFabResultEvent<DataModels.SetObjectsResponse>) each;

#endif
#if !DISABLE_PLAYFABENTITY_API
      if (OnEventsWriteEventsRequestEvent != null)
        foreach (var each in OnEventsWriteEventsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnEventsWriteEventsRequestEvent -= (PlayFabRequestEvent<EventsModels.WriteEventsRequest>) each;
      if (OnEventsWriteEventsResultEvent != null)
        foreach (var each in OnEventsWriteEventsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnEventsWriteEventsResultEvent -= (PlayFabResultEvent<EventsModels.WriteEventsResponse>) each;

      if (OnEventsWriteTelemetryEventsRequestEvent != null)
        foreach (var each in OnEventsWriteTelemetryEventsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnEventsWriteTelemetryEventsRequestEvent -= (PlayFabRequestEvent<EventsModels.WriteEventsRequest>) each;
      if (OnEventsWriteTelemetryEventsResultEvent != null)
        foreach (var each in OnEventsWriteTelemetryEventsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnEventsWriteTelemetryEventsResultEvent -= (PlayFabResultEvent<EventsModels.WriteEventsResponse>) each;

#endif
#if !DISABLE_PLAYFABENTITY_API
      if (OnExperimentationCreateExperimentRequestEvent != null)
        foreach (var each in OnExperimentationCreateExperimentRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnExperimentationCreateExperimentRequestEvent -=
              (PlayFabRequestEvent<ExperimentationModels.CreateExperimentRequest>) each;
      if (OnExperimentationCreateExperimentResultEvent != null)
        foreach (var each in OnExperimentationCreateExperimentResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnExperimentationCreateExperimentResultEvent -=
              (PlayFabResultEvent<ExperimentationModels.CreateExperimentResult>) each;

      if (OnExperimentationDeleteExperimentRequestEvent != null)
        foreach (var each in OnExperimentationDeleteExperimentRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnExperimentationDeleteExperimentRequestEvent -=
              (PlayFabRequestEvent<ExperimentationModels.DeleteExperimentRequest>) each;
      if (OnExperimentationDeleteExperimentResultEvent != null)
        foreach (var each in OnExperimentationDeleteExperimentResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnExperimentationDeleteExperimentResultEvent -=
              (PlayFabResultEvent<ExperimentationModels.EmptyResponse>) each;

      if (OnExperimentationGetExperimentsRequestEvent != null)
        foreach (var each in OnExperimentationGetExperimentsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnExperimentationGetExperimentsRequestEvent -=
              (PlayFabRequestEvent<ExperimentationModels.GetExperimentsRequest>) each;
      if (OnExperimentationGetExperimentsResultEvent != null)
        foreach (var each in OnExperimentationGetExperimentsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnExperimentationGetExperimentsResultEvent -=
              (PlayFabResultEvent<ExperimentationModels.GetExperimentsResult>) each;

      if (OnExperimentationGetLatestScorecardRequestEvent != null)
        foreach (var each in OnExperimentationGetLatestScorecardRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnExperimentationGetLatestScorecardRequestEvent -=
              (PlayFabRequestEvent<ExperimentationModels.GetLatestScorecardRequest>) each;
      if (OnExperimentationGetLatestScorecardResultEvent != null)
        foreach (var each in OnExperimentationGetLatestScorecardResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnExperimentationGetLatestScorecardResultEvent -=
              (PlayFabResultEvent<ExperimentationModels.GetLatestScorecardResult>) each;

      if (OnExperimentationGetTreatmentAssignmentRequestEvent != null)
        foreach (var each in OnExperimentationGetTreatmentAssignmentRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnExperimentationGetTreatmentAssignmentRequestEvent -=
              (PlayFabRequestEvent<ExperimentationModels.GetTreatmentAssignmentRequest>) each;
      if (OnExperimentationGetTreatmentAssignmentResultEvent != null)
        foreach (var each in OnExperimentationGetTreatmentAssignmentResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnExperimentationGetTreatmentAssignmentResultEvent -=
              (PlayFabResultEvent<ExperimentationModels.GetTreatmentAssignmentResult>) each;

      if (OnExperimentationStartExperimentRequestEvent != null)
        foreach (var each in OnExperimentationStartExperimentRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnExperimentationStartExperimentRequestEvent -=
              (PlayFabRequestEvent<ExperimentationModels.StartExperimentRequest>) each;
      if (OnExperimentationStartExperimentResultEvent != null)
        foreach (var each in OnExperimentationStartExperimentResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnExperimentationStartExperimentResultEvent -=
              (PlayFabResultEvent<ExperimentationModels.EmptyResponse>) each;

      if (OnExperimentationStopExperimentRequestEvent != null)
        foreach (var each in OnExperimentationStopExperimentRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnExperimentationStopExperimentRequestEvent -=
              (PlayFabRequestEvent<ExperimentationModels.StopExperimentRequest>) each;
      if (OnExperimentationStopExperimentResultEvent != null)
        foreach (var each in OnExperimentationStopExperimentResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnExperimentationStopExperimentResultEvent -=
              (PlayFabResultEvent<ExperimentationModels.EmptyResponse>) each;

      if (OnExperimentationUpdateExperimentRequestEvent != null)
        foreach (var each in OnExperimentationUpdateExperimentRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnExperimentationUpdateExperimentRequestEvent -=
              (PlayFabRequestEvent<ExperimentationModels.UpdateExperimentRequest>) each;
      if (OnExperimentationUpdateExperimentResultEvent != null)
        foreach (var each in OnExperimentationUpdateExperimentResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnExperimentationUpdateExperimentResultEvent -=
              (PlayFabResultEvent<ExperimentationModels.EmptyResponse>) each;

#endif
#if !DISABLE_PLAYFABENTITY_API
      if (OnInsightsGetDetailsRequestEvent != null)
        foreach (var each in OnInsightsGetDetailsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnInsightsGetDetailsRequestEvent -= (PlayFabRequestEvent<InsightsModels.InsightsEmptyRequest>) each;
      if (OnInsightsGetDetailsResultEvent != null)
        foreach (var each in OnInsightsGetDetailsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnInsightsGetDetailsResultEvent -= (PlayFabResultEvent<InsightsModels.InsightsGetDetailsResponse>) each;

      if (OnInsightsGetLimitsRequestEvent != null)
        foreach (var each in OnInsightsGetLimitsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnInsightsGetLimitsRequestEvent -= (PlayFabRequestEvent<InsightsModels.InsightsEmptyRequest>) each;
      if (OnInsightsGetLimitsResultEvent != null)
        foreach (var each in OnInsightsGetLimitsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnInsightsGetLimitsResultEvent -= (PlayFabResultEvent<InsightsModels.InsightsGetLimitsResponse>) each;

      if (OnInsightsGetOperationStatusRequestEvent != null)
        foreach (var each in OnInsightsGetOperationStatusRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnInsightsGetOperationStatusRequestEvent -=
              (PlayFabRequestEvent<InsightsModels.InsightsGetOperationStatusRequest>) each;
      if (OnInsightsGetOperationStatusResultEvent != null)
        foreach (var each in OnInsightsGetOperationStatusResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnInsightsGetOperationStatusResultEvent -=
              (PlayFabResultEvent<InsightsModels.InsightsGetOperationStatusResponse>) each;

      if (OnInsightsGetPendingOperationsRequestEvent != null)
        foreach (var each in OnInsightsGetPendingOperationsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnInsightsGetPendingOperationsRequestEvent -=
              (PlayFabRequestEvent<InsightsModels.InsightsGetPendingOperationsRequest>) each;
      if (OnInsightsGetPendingOperationsResultEvent != null)
        foreach (var each in OnInsightsGetPendingOperationsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnInsightsGetPendingOperationsResultEvent -=
              (PlayFabResultEvent<InsightsModels.InsightsGetPendingOperationsResponse>) each;

      if (OnInsightsSetPerformanceRequestEvent != null)
        foreach (var each in OnInsightsSetPerformanceRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnInsightsSetPerformanceRequestEvent -=
              (PlayFabRequestEvent<InsightsModels.InsightsSetPerformanceRequest>) each;
      if (OnInsightsSetPerformanceResultEvent != null)
        foreach (var each in OnInsightsSetPerformanceResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnInsightsSetPerformanceResultEvent -= (PlayFabResultEvent<InsightsModels.InsightsOperationResponse>) each;

      if (OnInsightsSetStorageRetentionRequestEvent != null)
        foreach (var each in OnInsightsSetStorageRetentionRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnInsightsSetStorageRetentionRequestEvent -=
              (PlayFabRequestEvent<InsightsModels.InsightsSetStorageRetentionRequest>) each;
      if (OnInsightsSetStorageRetentionResultEvent != null)
        foreach (var each in OnInsightsSetStorageRetentionResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnInsightsSetStorageRetentionResultEvent -=
              (PlayFabResultEvent<InsightsModels.InsightsOperationResponse>) each;

#endif
#if !DISABLE_PLAYFABENTITY_API
      if (OnGroupsAcceptGroupApplicationRequestEvent != null)
        foreach (var each in OnGroupsAcceptGroupApplicationRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsAcceptGroupApplicationRequestEvent -=
              (PlayFabRequestEvent<GroupsModels.AcceptGroupApplicationRequest>) each;
      if (OnGroupsAcceptGroupApplicationResultEvent != null)
        foreach (var each in OnGroupsAcceptGroupApplicationResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsAcceptGroupApplicationResultEvent -= (PlayFabResultEvent<GroupsModels.EmptyResponse>) each;

      if (OnGroupsAcceptGroupInvitationRequestEvent != null)
        foreach (var each in OnGroupsAcceptGroupInvitationRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsAcceptGroupInvitationRequestEvent -=
              (PlayFabRequestEvent<GroupsModels.AcceptGroupInvitationRequest>) each;
      if (OnGroupsAcceptGroupInvitationResultEvent != null)
        foreach (var each in OnGroupsAcceptGroupInvitationResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsAcceptGroupInvitationResultEvent -= (PlayFabResultEvent<GroupsModels.EmptyResponse>) each;

      if (OnGroupsAddMembersRequestEvent != null)
        foreach (var each in OnGroupsAddMembersRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsAddMembersRequestEvent -= (PlayFabRequestEvent<GroupsModels.AddMembersRequest>) each;
      if (OnGroupsAddMembersResultEvent != null)
        foreach (var each in OnGroupsAddMembersResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsAddMembersResultEvent -= (PlayFabResultEvent<GroupsModels.EmptyResponse>) each;

      if (OnGroupsApplyToGroupRequestEvent != null)
        foreach (var each in OnGroupsApplyToGroupRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsApplyToGroupRequestEvent -= (PlayFabRequestEvent<GroupsModels.ApplyToGroupRequest>) each;
      if (OnGroupsApplyToGroupResultEvent != null)
        foreach (var each in OnGroupsApplyToGroupResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsApplyToGroupResultEvent -= (PlayFabResultEvent<GroupsModels.ApplyToGroupResponse>) each;

      if (OnGroupsBlockEntityRequestEvent != null)
        foreach (var each in OnGroupsBlockEntityRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsBlockEntityRequestEvent -= (PlayFabRequestEvent<GroupsModels.BlockEntityRequest>) each;
      if (OnGroupsBlockEntityResultEvent != null)
        foreach (var each in OnGroupsBlockEntityResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsBlockEntityResultEvent -= (PlayFabResultEvent<GroupsModels.EmptyResponse>) each;

      if (OnGroupsChangeMemberRoleRequestEvent != null)
        foreach (var each in OnGroupsChangeMemberRoleRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsChangeMemberRoleRequestEvent -= (PlayFabRequestEvent<GroupsModels.ChangeMemberRoleRequest>) each;
      if (OnGroupsChangeMemberRoleResultEvent != null)
        foreach (var each in OnGroupsChangeMemberRoleResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsChangeMemberRoleResultEvent -= (PlayFabResultEvent<GroupsModels.EmptyResponse>) each;

      if (OnGroupsCreateGroupRequestEvent != null)
        foreach (var each in OnGroupsCreateGroupRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsCreateGroupRequestEvent -= (PlayFabRequestEvent<GroupsModels.CreateGroupRequest>) each;
      if (OnGroupsCreateGroupResultEvent != null)
        foreach (var each in OnGroupsCreateGroupResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsCreateGroupResultEvent -= (PlayFabResultEvent<GroupsModels.CreateGroupResponse>) each;

      if (OnGroupsCreateRoleRequestEvent != null)
        foreach (var each in OnGroupsCreateRoleRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsCreateRoleRequestEvent -= (PlayFabRequestEvent<GroupsModels.CreateGroupRoleRequest>) each;
      if (OnGroupsCreateRoleResultEvent != null)
        foreach (var each in OnGroupsCreateRoleResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsCreateRoleResultEvent -= (PlayFabResultEvent<GroupsModels.CreateGroupRoleResponse>) each;

      if (OnGroupsDeleteGroupRequestEvent != null)
        foreach (var each in OnGroupsDeleteGroupRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsDeleteGroupRequestEvent -= (PlayFabRequestEvent<GroupsModels.DeleteGroupRequest>) each;
      if (OnGroupsDeleteGroupResultEvent != null)
        foreach (var each in OnGroupsDeleteGroupResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsDeleteGroupResultEvent -= (PlayFabResultEvent<GroupsModels.EmptyResponse>) each;

      if (OnGroupsDeleteRoleRequestEvent != null)
        foreach (var each in OnGroupsDeleteRoleRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsDeleteRoleRequestEvent -= (PlayFabRequestEvent<GroupsModels.DeleteRoleRequest>) each;
      if (OnGroupsDeleteRoleResultEvent != null)
        foreach (var each in OnGroupsDeleteRoleResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsDeleteRoleResultEvent -= (PlayFabResultEvent<GroupsModels.EmptyResponse>) each;

      if (OnGroupsGetGroupRequestEvent != null)
        foreach (var each in OnGroupsGetGroupRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsGetGroupRequestEvent -= (PlayFabRequestEvent<GroupsModels.GetGroupRequest>) each;
      if (OnGroupsGetGroupResultEvent != null)
        foreach (var each in OnGroupsGetGroupResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsGetGroupResultEvent -= (PlayFabResultEvent<GroupsModels.GetGroupResponse>) each;

      if (OnGroupsInviteToGroupRequestEvent != null)
        foreach (var each in OnGroupsInviteToGroupRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsInviteToGroupRequestEvent -= (PlayFabRequestEvent<GroupsModels.InviteToGroupRequest>) each;
      if (OnGroupsInviteToGroupResultEvent != null)
        foreach (var each in OnGroupsInviteToGroupResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsInviteToGroupResultEvent -= (PlayFabResultEvent<GroupsModels.InviteToGroupResponse>) each;

      if (OnGroupsIsMemberRequestEvent != null)
        foreach (var each in OnGroupsIsMemberRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsIsMemberRequestEvent -= (PlayFabRequestEvent<GroupsModels.IsMemberRequest>) each;
      if (OnGroupsIsMemberResultEvent != null)
        foreach (var each in OnGroupsIsMemberResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsIsMemberResultEvent -= (PlayFabResultEvent<GroupsModels.IsMemberResponse>) each;

      if (OnGroupsListGroupApplicationsRequestEvent != null)
        foreach (var each in OnGroupsListGroupApplicationsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsListGroupApplicationsRequestEvent -=
              (PlayFabRequestEvent<GroupsModels.ListGroupApplicationsRequest>) each;
      if (OnGroupsListGroupApplicationsResultEvent != null)
        foreach (var each in OnGroupsListGroupApplicationsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsListGroupApplicationsResultEvent -=
              (PlayFabResultEvent<GroupsModels.ListGroupApplicationsResponse>) each;

      if (OnGroupsListGroupBlocksRequestEvent != null)
        foreach (var each in OnGroupsListGroupBlocksRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsListGroupBlocksRequestEvent -= (PlayFabRequestEvent<GroupsModels.ListGroupBlocksRequest>) each;
      if (OnGroupsListGroupBlocksResultEvent != null)
        foreach (var each in OnGroupsListGroupBlocksResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsListGroupBlocksResultEvent -= (PlayFabResultEvent<GroupsModels.ListGroupBlocksResponse>) each;

      if (OnGroupsListGroupInvitationsRequestEvent != null)
        foreach (var each in OnGroupsListGroupInvitationsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsListGroupInvitationsRequestEvent -=
              (PlayFabRequestEvent<GroupsModels.ListGroupInvitationsRequest>) each;
      if (OnGroupsListGroupInvitationsResultEvent != null)
        foreach (var each in OnGroupsListGroupInvitationsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsListGroupInvitationsResultEvent -=
              (PlayFabResultEvent<GroupsModels.ListGroupInvitationsResponse>) each;

      if (OnGroupsListGroupMembersRequestEvent != null)
        foreach (var each in OnGroupsListGroupMembersRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsListGroupMembersRequestEvent -= (PlayFabRequestEvent<GroupsModels.ListGroupMembersRequest>) each;
      if (OnGroupsListGroupMembersResultEvent != null)
        foreach (var each in OnGroupsListGroupMembersResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsListGroupMembersResultEvent -= (PlayFabResultEvent<GroupsModels.ListGroupMembersResponse>) each;

      if (OnGroupsListMembershipRequestEvent != null)
        foreach (var each in OnGroupsListMembershipRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsListMembershipRequestEvent -= (PlayFabRequestEvent<GroupsModels.ListMembershipRequest>) each;
      if (OnGroupsListMembershipResultEvent != null)
        foreach (var each in OnGroupsListMembershipResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsListMembershipResultEvent -= (PlayFabResultEvent<GroupsModels.ListMembershipResponse>) each;

      if (OnGroupsListMembershipOpportunitiesRequestEvent != null)
        foreach (var each in OnGroupsListMembershipOpportunitiesRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsListMembershipOpportunitiesRequestEvent -=
              (PlayFabRequestEvent<GroupsModels.ListMembershipOpportunitiesRequest>) each;
      if (OnGroupsListMembershipOpportunitiesResultEvent != null)
        foreach (var each in OnGroupsListMembershipOpportunitiesResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsListMembershipOpportunitiesResultEvent -=
              (PlayFabResultEvent<GroupsModels.ListMembershipOpportunitiesResponse>) each;

      if (OnGroupsRemoveGroupApplicationRequestEvent != null)
        foreach (var each in OnGroupsRemoveGroupApplicationRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsRemoveGroupApplicationRequestEvent -=
              (PlayFabRequestEvent<GroupsModels.RemoveGroupApplicationRequest>) each;
      if (OnGroupsRemoveGroupApplicationResultEvent != null)
        foreach (var each in OnGroupsRemoveGroupApplicationResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsRemoveGroupApplicationResultEvent -= (PlayFabResultEvent<GroupsModels.EmptyResponse>) each;

      if (OnGroupsRemoveGroupInvitationRequestEvent != null)
        foreach (var each in OnGroupsRemoveGroupInvitationRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsRemoveGroupInvitationRequestEvent -=
              (PlayFabRequestEvent<GroupsModels.RemoveGroupInvitationRequest>) each;
      if (OnGroupsRemoveGroupInvitationResultEvent != null)
        foreach (var each in OnGroupsRemoveGroupInvitationResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsRemoveGroupInvitationResultEvent -= (PlayFabResultEvent<GroupsModels.EmptyResponse>) each;

      if (OnGroupsRemoveMembersRequestEvent != null)
        foreach (var each in OnGroupsRemoveMembersRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsRemoveMembersRequestEvent -= (PlayFabRequestEvent<GroupsModels.RemoveMembersRequest>) each;
      if (OnGroupsRemoveMembersResultEvent != null)
        foreach (var each in OnGroupsRemoveMembersResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsRemoveMembersResultEvent -= (PlayFabResultEvent<GroupsModels.EmptyResponse>) each;

      if (OnGroupsUnblockEntityRequestEvent != null)
        foreach (var each in OnGroupsUnblockEntityRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsUnblockEntityRequestEvent -= (PlayFabRequestEvent<GroupsModels.UnblockEntityRequest>) each;
      if (OnGroupsUnblockEntityResultEvent != null)
        foreach (var each in OnGroupsUnblockEntityResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsUnblockEntityResultEvent -= (PlayFabResultEvent<GroupsModels.EmptyResponse>) each;

      if (OnGroupsUpdateGroupRequestEvent != null)
        foreach (var each in OnGroupsUpdateGroupRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsUpdateGroupRequestEvent -= (PlayFabRequestEvent<GroupsModels.UpdateGroupRequest>) each;
      if (OnGroupsUpdateGroupResultEvent != null)
        foreach (var each in OnGroupsUpdateGroupResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsUpdateGroupResultEvent -= (PlayFabResultEvent<GroupsModels.UpdateGroupResponse>) each;

      if (OnGroupsUpdateRoleRequestEvent != null)
        foreach (var each in OnGroupsUpdateRoleRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsUpdateRoleRequestEvent -= (PlayFabRequestEvent<GroupsModels.UpdateGroupRoleRequest>) each;
      if (OnGroupsUpdateRoleResultEvent != null)
        foreach (var each in OnGroupsUpdateRoleResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnGroupsUpdateRoleResultEvent -= (PlayFabResultEvent<GroupsModels.UpdateGroupRoleResponse>) each;

#endif
#if !DISABLE_PLAYFABENTITY_API
      if (OnLocalizationGetLanguageListRequestEvent != null)
        foreach (var each in OnLocalizationGetLanguageListRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLocalizationGetLanguageListRequestEvent -=
              (PlayFabRequestEvent<LocalizationModels.GetLanguageListRequest>) each;
      if (OnLocalizationGetLanguageListResultEvent != null)
        foreach (var each in OnLocalizationGetLanguageListResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnLocalizationGetLanguageListResultEvent -=
              (PlayFabResultEvent<LocalizationModels.GetLanguageListResponse>) each;

#endif
#if !DISABLE_PLAYFABENTITY_API
      if (OnMultiplayerCancelAllMatchmakingTicketsForPlayerRequestEvent != null)
        foreach (var each in OnMultiplayerCancelAllMatchmakingTicketsForPlayerRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerCancelAllMatchmakingTicketsForPlayerRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.CancelAllMatchmakingTicketsForPlayerRequest>) each;
      if (OnMultiplayerCancelAllMatchmakingTicketsForPlayerResultEvent != null)
        foreach (var each in OnMultiplayerCancelAllMatchmakingTicketsForPlayerResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerCancelAllMatchmakingTicketsForPlayerResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.CancelAllMatchmakingTicketsForPlayerResult>) each;

      if (OnMultiplayerCancelAllServerBackfillTicketsForPlayerRequestEvent != null)
        foreach (var each in OnMultiplayerCancelAllServerBackfillTicketsForPlayerRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerCancelAllServerBackfillTicketsForPlayerRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.CancelAllServerBackfillTicketsForPlayerRequest>) each;
      if (OnMultiplayerCancelAllServerBackfillTicketsForPlayerResultEvent != null)
        foreach (var each in OnMultiplayerCancelAllServerBackfillTicketsForPlayerResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerCancelAllServerBackfillTicketsForPlayerResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.CancelAllServerBackfillTicketsForPlayerResult>) each;

      if (OnMultiplayerCancelMatchmakingTicketRequestEvent != null)
        foreach (var each in OnMultiplayerCancelMatchmakingTicketRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerCancelMatchmakingTicketRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.CancelMatchmakingTicketRequest>) each;
      if (OnMultiplayerCancelMatchmakingTicketResultEvent != null)
        foreach (var each in OnMultiplayerCancelMatchmakingTicketResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerCancelMatchmakingTicketResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.CancelMatchmakingTicketResult>) each;

      if (OnMultiplayerCancelServerBackfillTicketRequestEvent != null)
        foreach (var each in OnMultiplayerCancelServerBackfillTicketRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerCancelServerBackfillTicketRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.CancelServerBackfillTicketRequest>) each;
      if (OnMultiplayerCancelServerBackfillTicketResultEvent != null)
        foreach (var each in OnMultiplayerCancelServerBackfillTicketResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerCancelServerBackfillTicketResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.CancelServerBackfillTicketResult>) each;

      if (OnMultiplayerCreateBuildAliasRequestEvent != null)
        foreach (var each in OnMultiplayerCreateBuildAliasRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerCreateBuildAliasRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.CreateBuildAliasRequest>) each;
      if (OnMultiplayerCreateBuildAliasResultEvent != null)
        foreach (var each in OnMultiplayerCreateBuildAliasResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerCreateBuildAliasResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.BuildAliasDetailsResponse>) each;

      if (OnMultiplayerCreateBuildWithCustomContainerRequestEvent != null)
        foreach (var each in OnMultiplayerCreateBuildWithCustomContainerRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerCreateBuildWithCustomContainerRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.CreateBuildWithCustomContainerRequest>) each;
      if (OnMultiplayerCreateBuildWithCustomContainerResultEvent != null)
        foreach (var each in OnMultiplayerCreateBuildWithCustomContainerResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerCreateBuildWithCustomContainerResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.CreateBuildWithCustomContainerResponse>) each;

      if (OnMultiplayerCreateBuildWithManagedContainerRequestEvent != null)
        foreach (var each in OnMultiplayerCreateBuildWithManagedContainerRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerCreateBuildWithManagedContainerRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.CreateBuildWithManagedContainerRequest>) each;
      if (OnMultiplayerCreateBuildWithManagedContainerResultEvent != null)
        foreach (var each in OnMultiplayerCreateBuildWithManagedContainerResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerCreateBuildWithManagedContainerResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.CreateBuildWithManagedContainerResponse>) each;

      if (OnMultiplayerCreateMatchmakingTicketRequestEvent != null)
        foreach (var each in OnMultiplayerCreateMatchmakingTicketRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerCreateMatchmakingTicketRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.CreateMatchmakingTicketRequest>) each;
      if (OnMultiplayerCreateMatchmakingTicketResultEvent != null)
        foreach (var each in OnMultiplayerCreateMatchmakingTicketResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerCreateMatchmakingTicketResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.CreateMatchmakingTicketResult>) each;

      if (OnMultiplayerCreateRemoteUserRequestEvent != null)
        foreach (var each in OnMultiplayerCreateRemoteUserRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerCreateRemoteUserRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.CreateRemoteUserRequest>) each;
      if (OnMultiplayerCreateRemoteUserResultEvent != null)
        foreach (var each in OnMultiplayerCreateRemoteUserResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerCreateRemoteUserResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.CreateRemoteUserResponse>) each;

      if (OnMultiplayerCreateServerBackfillTicketRequestEvent != null)
        foreach (var each in OnMultiplayerCreateServerBackfillTicketRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerCreateServerBackfillTicketRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.CreateServerBackfillTicketRequest>) each;
      if (OnMultiplayerCreateServerBackfillTicketResultEvent != null)
        foreach (var each in OnMultiplayerCreateServerBackfillTicketResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerCreateServerBackfillTicketResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.CreateServerBackfillTicketResult>) each;

      if (OnMultiplayerCreateServerMatchmakingTicketRequestEvent != null)
        foreach (var each in OnMultiplayerCreateServerMatchmakingTicketRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerCreateServerMatchmakingTicketRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.CreateServerMatchmakingTicketRequest>) each;
      if (OnMultiplayerCreateServerMatchmakingTicketResultEvent != null)
        foreach (var each in OnMultiplayerCreateServerMatchmakingTicketResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerCreateServerMatchmakingTicketResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.CreateMatchmakingTicketResult>) each;

      if (OnMultiplayerDeleteAssetRequestEvent != null)
        foreach (var each in OnMultiplayerDeleteAssetRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerDeleteAssetRequestEvent -= (PlayFabRequestEvent<MultiplayerModels.DeleteAssetRequest>) each;
      if (OnMultiplayerDeleteAssetResultEvent != null)
        foreach (var each in OnMultiplayerDeleteAssetResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerDeleteAssetResultEvent -= (PlayFabResultEvent<MultiplayerModels.EmptyResponse>) each;

      if (OnMultiplayerDeleteBuildRequestEvent != null)
        foreach (var each in OnMultiplayerDeleteBuildRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerDeleteBuildRequestEvent -= (PlayFabRequestEvent<MultiplayerModels.DeleteBuildRequest>) each;
      if (OnMultiplayerDeleteBuildResultEvent != null)
        foreach (var each in OnMultiplayerDeleteBuildResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerDeleteBuildResultEvent -= (PlayFabResultEvent<MultiplayerModels.EmptyResponse>) each;

      if (OnMultiplayerDeleteBuildAliasRequestEvent != null)
        foreach (var each in OnMultiplayerDeleteBuildAliasRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerDeleteBuildAliasRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.DeleteBuildAliasRequest>) each;
      if (OnMultiplayerDeleteBuildAliasResultEvent != null)
        foreach (var each in OnMultiplayerDeleteBuildAliasResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerDeleteBuildAliasResultEvent -= (PlayFabResultEvent<MultiplayerModels.EmptyResponse>) each;

      if (OnMultiplayerDeleteBuildRegionRequestEvent != null)
        foreach (var each in OnMultiplayerDeleteBuildRegionRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerDeleteBuildRegionRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.DeleteBuildRegionRequest>) each;
      if (OnMultiplayerDeleteBuildRegionResultEvent != null)
        foreach (var each in OnMultiplayerDeleteBuildRegionResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerDeleteBuildRegionResultEvent -= (PlayFabResultEvent<MultiplayerModels.EmptyResponse>) each;

      if (OnMultiplayerDeleteCertificateRequestEvent != null)
        foreach (var each in OnMultiplayerDeleteCertificateRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerDeleteCertificateRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.DeleteCertificateRequest>) each;
      if (OnMultiplayerDeleteCertificateResultEvent != null)
        foreach (var each in OnMultiplayerDeleteCertificateResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerDeleteCertificateResultEvent -= (PlayFabResultEvent<MultiplayerModels.EmptyResponse>) each;

      if (OnMultiplayerDeleteContainerImageRepositoryRequestEvent != null)
        foreach (var each in OnMultiplayerDeleteContainerImageRepositoryRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerDeleteContainerImageRepositoryRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.DeleteContainerImageRequest>) each;
      if (OnMultiplayerDeleteContainerImageRepositoryResultEvent != null)
        foreach (var each in OnMultiplayerDeleteContainerImageRepositoryResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerDeleteContainerImageRepositoryResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.EmptyResponse>) each;

      if (OnMultiplayerDeleteRemoteUserRequestEvent != null)
        foreach (var each in OnMultiplayerDeleteRemoteUserRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerDeleteRemoteUserRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.DeleteRemoteUserRequest>) each;
      if (OnMultiplayerDeleteRemoteUserResultEvent != null)
        foreach (var each in OnMultiplayerDeleteRemoteUserResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerDeleteRemoteUserResultEvent -= (PlayFabResultEvent<MultiplayerModels.EmptyResponse>) each;

      if (OnMultiplayerEnableMultiplayerServersForTitleRequestEvent != null)
        foreach (var each in OnMultiplayerEnableMultiplayerServersForTitleRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerEnableMultiplayerServersForTitleRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.EnableMultiplayerServersForTitleRequest>) each;
      if (OnMultiplayerEnableMultiplayerServersForTitleResultEvent != null)
        foreach (var each in OnMultiplayerEnableMultiplayerServersForTitleResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerEnableMultiplayerServersForTitleResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.EnableMultiplayerServersForTitleResponse>) each;

      if (OnMultiplayerGetAssetUploadUrlRequestEvent != null)
        foreach (var each in OnMultiplayerGetAssetUploadUrlRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetAssetUploadUrlRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.GetAssetUploadUrlRequest>) each;
      if (OnMultiplayerGetAssetUploadUrlResultEvent != null)
        foreach (var each in OnMultiplayerGetAssetUploadUrlResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetAssetUploadUrlResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.GetAssetUploadUrlResponse>) each;

      if (OnMultiplayerGetBuildRequestEvent != null)
        foreach (var each in OnMultiplayerGetBuildRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetBuildRequestEvent -= (PlayFabRequestEvent<MultiplayerModels.GetBuildRequest>) each;
      if (OnMultiplayerGetBuildResultEvent != null)
        foreach (var each in OnMultiplayerGetBuildResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetBuildResultEvent -= (PlayFabResultEvent<MultiplayerModels.GetBuildResponse>) each;

      if (OnMultiplayerGetBuildAliasRequestEvent != null)
        foreach (var each in OnMultiplayerGetBuildAliasRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetBuildAliasRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.GetBuildAliasRequest>) each;
      if (OnMultiplayerGetBuildAliasResultEvent != null)
        foreach (var each in OnMultiplayerGetBuildAliasResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetBuildAliasResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.BuildAliasDetailsResponse>) each;

      if (OnMultiplayerGetContainerRegistryCredentialsRequestEvent != null)
        foreach (var each in OnMultiplayerGetContainerRegistryCredentialsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetContainerRegistryCredentialsRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.GetContainerRegistryCredentialsRequest>) each;
      if (OnMultiplayerGetContainerRegistryCredentialsResultEvent != null)
        foreach (var each in OnMultiplayerGetContainerRegistryCredentialsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetContainerRegistryCredentialsResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.GetContainerRegistryCredentialsResponse>) each;

      if (OnMultiplayerGetMatchRequestEvent != null)
        foreach (var each in OnMultiplayerGetMatchRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetMatchRequestEvent -= (PlayFabRequestEvent<MultiplayerModels.GetMatchRequest>) each;
      if (OnMultiplayerGetMatchResultEvent != null)
        foreach (var each in OnMultiplayerGetMatchResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetMatchResultEvent -= (PlayFabResultEvent<MultiplayerModels.GetMatchResult>) each;

      if (OnMultiplayerGetMatchmakingQueueRequestEvent != null)
        foreach (var each in OnMultiplayerGetMatchmakingQueueRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetMatchmakingQueueRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.GetMatchmakingQueueRequest>) each;
      if (OnMultiplayerGetMatchmakingQueueResultEvent != null)
        foreach (var each in OnMultiplayerGetMatchmakingQueueResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetMatchmakingQueueResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.GetMatchmakingQueueResult>) each;

      if (OnMultiplayerGetMatchmakingTicketRequestEvent != null)
        foreach (var each in OnMultiplayerGetMatchmakingTicketRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetMatchmakingTicketRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.GetMatchmakingTicketRequest>) each;
      if (OnMultiplayerGetMatchmakingTicketResultEvent != null)
        foreach (var each in OnMultiplayerGetMatchmakingTicketResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetMatchmakingTicketResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.GetMatchmakingTicketResult>) each;

      if (OnMultiplayerGetMultiplayerServerDetailsRequestEvent != null)
        foreach (var each in OnMultiplayerGetMultiplayerServerDetailsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetMultiplayerServerDetailsRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.GetMultiplayerServerDetailsRequest>) each;
      if (OnMultiplayerGetMultiplayerServerDetailsResultEvent != null)
        foreach (var each in OnMultiplayerGetMultiplayerServerDetailsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetMultiplayerServerDetailsResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.GetMultiplayerServerDetailsResponse>) each;

      if (OnMultiplayerGetMultiplayerServerLogsRequestEvent != null)
        foreach (var each in OnMultiplayerGetMultiplayerServerLogsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetMultiplayerServerLogsRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.GetMultiplayerServerLogsRequest>) each;
      if (OnMultiplayerGetMultiplayerServerLogsResultEvent != null)
        foreach (var each in OnMultiplayerGetMultiplayerServerLogsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetMultiplayerServerLogsResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.GetMultiplayerServerLogsResponse>) each;

      if (OnMultiplayerGetMultiplayerSessionLogsBySessionIdRequestEvent != null)
        foreach (var each in OnMultiplayerGetMultiplayerSessionLogsBySessionIdRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetMultiplayerSessionLogsBySessionIdRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.GetMultiplayerSessionLogsBySessionIdRequest>) each;
      if (OnMultiplayerGetMultiplayerSessionLogsBySessionIdResultEvent != null)
        foreach (var each in OnMultiplayerGetMultiplayerSessionLogsBySessionIdResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetMultiplayerSessionLogsBySessionIdResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.GetMultiplayerServerLogsResponse>) each;

      if (OnMultiplayerGetQueueStatisticsRequestEvent != null)
        foreach (var each in OnMultiplayerGetQueueStatisticsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetQueueStatisticsRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.GetQueueStatisticsRequest>) each;
      if (OnMultiplayerGetQueueStatisticsResultEvent != null)
        foreach (var each in OnMultiplayerGetQueueStatisticsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetQueueStatisticsResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.GetQueueStatisticsResult>) each;

      if (OnMultiplayerGetRemoteLoginEndpointRequestEvent != null)
        foreach (var each in OnMultiplayerGetRemoteLoginEndpointRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetRemoteLoginEndpointRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.GetRemoteLoginEndpointRequest>) each;
      if (OnMultiplayerGetRemoteLoginEndpointResultEvent != null)
        foreach (var each in OnMultiplayerGetRemoteLoginEndpointResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetRemoteLoginEndpointResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.GetRemoteLoginEndpointResponse>) each;

      if (OnMultiplayerGetServerBackfillTicketRequestEvent != null)
        foreach (var each in OnMultiplayerGetServerBackfillTicketRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetServerBackfillTicketRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.GetServerBackfillTicketRequest>) each;
      if (OnMultiplayerGetServerBackfillTicketResultEvent != null)
        foreach (var each in OnMultiplayerGetServerBackfillTicketResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetServerBackfillTicketResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.GetServerBackfillTicketResult>) each;

      if (OnMultiplayerGetTitleEnabledForMultiplayerServersStatusRequestEvent != null)
        foreach (var each in OnMultiplayerGetTitleEnabledForMultiplayerServersStatusRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetTitleEnabledForMultiplayerServersStatusRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.GetTitleEnabledForMultiplayerServersStatusRequest>) each;
      if (OnMultiplayerGetTitleEnabledForMultiplayerServersStatusResultEvent != null)
        foreach (var each in OnMultiplayerGetTitleEnabledForMultiplayerServersStatusResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetTitleEnabledForMultiplayerServersStatusResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.GetTitleEnabledForMultiplayerServersStatusResponse>) each;

      if (OnMultiplayerGetTitleMultiplayerServersQuotasRequestEvent != null)
        foreach (var each in OnMultiplayerGetTitleMultiplayerServersQuotasRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetTitleMultiplayerServersQuotasRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.GetTitleMultiplayerServersQuotasRequest>) each;
      if (OnMultiplayerGetTitleMultiplayerServersQuotasResultEvent != null)
        foreach (var each in OnMultiplayerGetTitleMultiplayerServersQuotasResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerGetTitleMultiplayerServersQuotasResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.GetTitleMultiplayerServersQuotasResponse>) each;

      if (OnMultiplayerJoinMatchmakingTicketRequestEvent != null)
        foreach (var each in OnMultiplayerJoinMatchmakingTicketRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerJoinMatchmakingTicketRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.JoinMatchmakingTicketRequest>) each;
      if (OnMultiplayerJoinMatchmakingTicketResultEvent != null)
        foreach (var each in OnMultiplayerJoinMatchmakingTicketResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerJoinMatchmakingTicketResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.JoinMatchmakingTicketResult>) each;

      if (OnMultiplayerListArchivedMultiplayerServersRequestEvent != null)
        foreach (var each in OnMultiplayerListArchivedMultiplayerServersRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListArchivedMultiplayerServersRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.ListMultiplayerServersRequest>) each;
      if (OnMultiplayerListArchivedMultiplayerServersResultEvent != null)
        foreach (var each in OnMultiplayerListArchivedMultiplayerServersResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListArchivedMultiplayerServersResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.ListMultiplayerServersResponse>) each;

      if (OnMultiplayerListAssetSummariesRequestEvent != null)
        foreach (var each in OnMultiplayerListAssetSummariesRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListAssetSummariesRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.ListAssetSummariesRequest>) each;
      if (OnMultiplayerListAssetSummariesResultEvent != null)
        foreach (var each in OnMultiplayerListAssetSummariesResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListAssetSummariesResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.ListAssetSummariesResponse>) each;

      if (OnMultiplayerListBuildAliasesRequestEvent != null)
        foreach (var each in OnMultiplayerListBuildAliasesRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListBuildAliasesRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.MultiplayerEmptyRequest>) each;
      if (OnMultiplayerListBuildAliasesResultEvent != null)
        foreach (var each in OnMultiplayerListBuildAliasesResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListBuildAliasesResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.ListBuildAliasesForTitleResponse>) each;

      if (OnMultiplayerListBuildSummariesRequestEvent != null)
        foreach (var each in OnMultiplayerListBuildSummariesRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListBuildSummariesRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.ListBuildSummariesRequest>) each;
      if (OnMultiplayerListBuildSummariesResultEvent != null)
        foreach (var each in OnMultiplayerListBuildSummariesResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListBuildSummariesResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.ListBuildSummariesResponse>) each;

      if (OnMultiplayerListCertificateSummariesRequestEvent != null)
        foreach (var each in OnMultiplayerListCertificateSummariesRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListCertificateSummariesRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.ListCertificateSummariesRequest>) each;
      if (OnMultiplayerListCertificateSummariesResultEvent != null)
        foreach (var each in OnMultiplayerListCertificateSummariesResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListCertificateSummariesResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.ListCertificateSummariesResponse>) each;

      if (OnMultiplayerListContainerImagesRequestEvent != null)
        foreach (var each in OnMultiplayerListContainerImagesRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListContainerImagesRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.ListContainerImagesRequest>) each;
      if (OnMultiplayerListContainerImagesResultEvent != null)
        foreach (var each in OnMultiplayerListContainerImagesResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListContainerImagesResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.ListContainerImagesResponse>) each;

      if (OnMultiplayerListContainerImageTagsRequestEvent != null)
        foreach (var each in OnMultiplayerListContainerImageTagsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListContainerImageTagsRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.ListContainerImageTagsRequest>) each;
      if (OnMultiplayerListContainerImageTagsResultEvent != null)
        foreach (var each in OnMultiplayerListContainerImageTagsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListContainerImageTagsResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.ListContainerImageTagsResponse>) each;

      if (OnMultiplayerListMatchmakingQueuesRequestEvent != null)
        foreach (var each in OnMultiplayerListMatchmakingQueuesRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListMatchmakingQueuesRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.ListMatchmakingQueuesRequest>) each;
      if (OnMultiplayerListMatchmakingQueuesResultEvent != null)
        foreach (var each in OnMultiplayerListMatchmakingQueuesResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListMatchmakingQueuesResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.ListMatchmakingQueuesResult>) each;

      if (OnMultiplayerListMatchmakingTicketsForPlayerRequestEvent != null)
        foreach (var each in OnMultiplayerListMatchmakingTicketsForPlayerRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListMatchmakingTicketsForPlayerRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.ListMatchmakingTicketsForPlayerRequest>) each;
      if (OnMultiplayerListMatchmakingTicketsForPlayerResultEvent != null)
        foreach (var each in OnMultiplayerListMatchmakingTicketsForPlayerResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListMatchmakingTicketsForPlayerResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.ListMatchmakingTicketsForPlayerResult>) each;

      if (OnMultiplayerListMultiplayerServersRequestEvent != null)
        foreach (var each in OnMultiplayerListMultiplayerServersRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListMultiplayerServersRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.ListMultiplayerServersRequest>) each;
      if (OnMultiplayerListMultiplayerServersResultEvent != null)
        foreach (var each in OnMultiplayerListMultiplayerServersResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListMultiplayerServersResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.ListMultiplayerServersResponse>) each;

      if (OnMultiplayerListPartyQosServersRequestEvent != null)
        foreach (var each in OnMultiplayerListPartyQosServersRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListPartyQosServersRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.ListPartyQosServersRequest>) each;
      if (OnMultiplayerListPartyQosServersResultEvent != null)
        foreach (var each in OnMultiplayerListPartyQosServersResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListPartyQosServersResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.ListPartyQosServersResponse>) each;

      if (OnMultiplayerListQosServersRequestEvent != null)
        foreach (var each in OnMultiplayerListQosServersRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListQosServersRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.ListQosServersRequest>) each;
      if (OnMultiplayerListQosServersResultEvent != null)
        foreach (var each in OnMultiplayerListQosServersResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListQosServersResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.ListQosServersResponse>) each;

      if (OnMultiplayerListQosServersForTitleRequestEvent != null)
        foreach (var each in OnMultiplayerListQosServersForTitleRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListQosServersForTitleRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.ListQosServersForTitleRequest>) each;
      if (OnMultiplayerListQosServersForTitleResultEvent != null)
        foreach (var each in OnMultiplayerListQosServersForTitleResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListQosServersForTitleResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.ListQosServersForTitleResponse>) each;

      if (OnMultiplayerListServerBackfillTicketsForPlayerRequestEvent != null)
        foreach (var each in OnMultiplayerListServerBackfillTicketsForPlayerRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListServerBackfillTicketsForPlayerRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.ListServerBackfillTicketsForPlayerRequest>) each;
      if (OnMultiplayerListServerBackfillTicketsForPlayerResultEvent != null)
        foreach (var each in OnMultiplayerListServerBackfillTicketsForPlayerResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListServerBackfillTicketsForPlayerResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.ListServerBackfillTicketsForPlayerResult>) each;

      if (OnMultiplayerListVirtualMachineSummariesRequestEvent != null)
        foreach (var each in OnMultiplayerListVirtualMachineSummariesRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListVirtualMachineSummariesRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.ListVirtualMachineSummariesRequest>) each;
      if (OnMultiplayerListVirtualMachineSummariesResultEvent != null)
        foreach (var each in OnMultiplayerListVirtualMachineSummariesResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerListVirtualMachineSummariesResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.ListVirtualMachineSummariesResponse>) each;

      if (OnMultiplayerRemoveMatchmakingQueueRequestEvent != null)
        foreach (var each in OnMultiplayerRemoveMatchmakingQueueRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerRemoveMatchmakingQueueRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.RemoveMatchmakingQueueRequest>) each;
      if (OnMultiplayerRemoveMatchmakingQueueResultEvent != null)
        foreach (var each in OnMultiplayerRemoveMatchmakingQueueResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerRemoveMatchmakingQueueResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.RemoveMatchmakingQueueResult>) each;

      if (OnMultiplayerRequestMultiplayerServerRequestEvent != null)
        foreach (var each in OnMultiplayerRequestMultiplayerServerRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerRequestMultiplayerServerRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.RequestMultiplayerServerRequest>) each;
      if (OnMultiplayerRequestMultiplayerServerResultEvent != null)
        foreach (var each in OnMultiplayerRequestMultiplayerServerResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerRequestMultiplayerServerResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.RequestMultiplayerServerResponse>) each;

      if (OnMultiplayerRolloverContainerRegistryCredentialsRequestEvent != null)
        foreach (var each in OnMultiplayerRolloverContainerRegistryCredentialsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerRolloverContainerRegistryCredentialsRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.RolloverContainerRegistryCredentialsRequest>) each;
      if (OnMultiplayerRolloverContainerRegistryCredentialsResultEvent != null)
        foreach (var each in OnMultiplayerRolloverContainerRegistryCredentialsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerRolloverContainerRegistryCredentialsResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.RolloverContainerRegistryCredentialsResponse>) each;

      if (OnMultiplayerSetMatchmakingQueueRequestEvent != null)
        foreach (var each in OnMultiplayerSetMatchmakingQueueRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerSetMatchmakingQueueRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.SetMatchmakingQueueRequest>) each;
      if (OnMultiplayerSetMatchmakingQueueResultEvent != null)
        foreach (var each in OnMultiplayerSetMatchmakingQueueResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerSetMatchmakingQueueResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.SetMatchmakingQueueResult>) each;

      if (OnMultiplayerShutdownMultiplayerServerRequestEvent != null)
        foreach (var each in OnMultiplayerShutdownMultiplayerServerRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerShutdownMultiplayerServerRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.ShutdownMultiplayerServerRequest>) each;
      if (OnMultiplayerShutdownMultiplayerServerResultEvent != null)
        foreach (var each in OnMultiplayerShutdownMultiplayerServerResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerShutdownMultiplayerServerResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.EmptyResponse>) each;

      if (OnMultiplayerUntagContainerImageRequestEvent != null)
        foreach (var each in OnMultiplayerUntagContainerImageRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerUntagContainerImageRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.UntagContainerImageRequest>) each;
      if (OnMultiplayerUntagContainerImageResultEvent != null)
        foreach (var each in OnMultiplayerUntagContainerImageResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerUntagContainerImageResultEvent -= (PlayFabResultEvent<MultiplayerModels.EmptyResponse>) each;

      if (OnMultiplayerUpdateBuildAliasRequestEvent != null)
        foreach (var each in OnMultiplayerUpdateBuildAliasRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerUpdateBuildAliasRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.UpdateBuildAliasRequest>) each;
      if (OnMultiplayerUpdateBuildAliasResultEvent != null)
        foreach (var each in OnMultiplayerUpdateBuildAliasResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerUpdateBuildAliasResultEvent -=
              (PlayFabResultEvent<MultiplayerModels.BuildAliasDetailsResponse>) each;

      if (OnMultiplayerUpdateBuildRegionRequestEvent != null)
        foreach (var each in OnMultiplayerUpdateBuildRegionRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerUpdateBuildRegionRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.UpdateBuildRegionRequest>) each;
      if (OnMultiplayerUpdateBuildRegionResultEvent != null)
        foreach (var each in OnMultiplayerUpdateBuildRegionResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerUpdateBuildRegionResultEvent -= (PlayFabResultEvent<MultiplayerModels.EmptyResponse>) each;

      if (OnMultiplayerUpdateBuildRegionsRequestEvent != null)
        foreach (var each in OnMultiplayerUpdateBuildRegionsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerUpdateBuildRegionsRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.UpdateBuildRegionsRequest>) each;
      if (OnMultiplayerUpdateBuildRegionsResultEvent != null)
        foreach (var each in OnMultiplayerUpdateBuildRegionsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerUpdateBuildRegionsResultEvent -= (PlayFabResultEvent<MultiplayerModels.EmptyResponse>) each;

      if (OnMultiplayerUploadCertificateRequestEvent != null)
        foreach (var each in OnMultiplayerUploadCertificateRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerUploadCertificateRequestEvent -=
              (PlayFabRequestEvent<MultiplayerModels.UploadCertificateRequest>) each;
      if (OnMultiplayerUploadCertificateResultEvent != null)
        foreach (var each in OnMultiplayerUploadCertificateResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnMultiplayerUploadCertificateResultEvent -= (PlayFabResultEvent<MultiplayerModels.EmptyResponse>) each;

#endif
#if !DISABLE_PLAYFABENTITY_API
      if (OnProfilesGetGlobalPolicyRequestEvent != null)
        foreach (var each in OnProfilesGetGlobalPolicyRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnProfilesGetGlobalPolicyRequestEvent -= (PlayFabRequestEvent<ProfilesModels.GetGlobalPolicyRequest>) each;
      if (OnProfilesGetGlobalPolicyResultEvent != null)
        foreach (var each in OnProfilesGetGlobalPolicyResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnProfilesGetGlobalPolicyResultEvent -= (PlayFabResultEvent<ProfilesModels.GetGlobalPolicyResponse>) each;

      if (OnProfilesGetProfileRequestEvent != null)
        foreach (var each in OnProfilesGetProfileRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnProfilesGetProfileRequestEvent -= (PlayFabRequestEvent<ProfilesModels.GetEntityProfileRequest>) each;
      if (OnProfilesGetProfileResultEvent != null)
        foreach (var each in OnProfilesGetProfileResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnProfilesGetProfileResultEvent -= (PlayFabResultEvent<ProfilesModels.GetEntityProfileResponse>) each;

      if (OnProfilesGetProfilesRequestEvent != null)
        foreach (var each in OnProfilesGetProfilesRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnProfilesGetProfilesRequestEvent -= (PlayFabRequestEvent<ProfilesModels.GetEntityProfilesRequest>) each;
      if (OnProfilesGetProfilesResultEvent != null)
        foreach (var each in OnProfilesGetProfilesResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnProfilesGetProfilesResultEvent -= (PlayFabResultEvent<ProfilesModels.GetEntityProfilesResponse>) each;

      if (OnProfilesGetTitlePlayersFromMasterPlayerAccountIdsRequestEvent != null)
        foreach (var each in OnProfilesGetTitlePlayersFromMasterPlayerAccountIdsRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnProfilesGetTitlePlayersFromMasterPlayerAccountIdsRequestEvent -=
              (PlayFabRequestEvent<ProfilesModels.GetTitlePlayersFromMasterPlayerAccountIdsRequest>) each;
      if (OnProfilesGetTitlePlayersFromMasterPlayerAccountIdsResultEvent != null)
        foreach (var each in OnProfilesGetTitlePlayersFromMasterPlayerAccountIdsResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnProfilesGetTitlePlayersFromMasterPlayerAccountIdsResultEvent -=
              (PlayFabResultEvent<ProfilesModels.GetTitlePlayersFromMasterPlayerAccountIdsResponse>) each;

      if (OnProfilesSetGlobalPolicyRequestEvent != null)
        foreach (var each in OnProfilesSetGlobalPolicyRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnProfilesSetGlobalPolicyRequestEvent -= (PlayFabRequestEvent<ProfilesModels.SetGlobalPolicyRequest>) each;
      if (OnProfilesSetGlobalPolicyResultEvent != null)
        foreach (var each in OnProfilesSetGlobalPolicyResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnProfilesSetGlobalPolicyResultEvent -= (PlayFabResultEvent<ProfilesModels.SetGlobalPolicyResponse>) each;

      if (OnProfilesSetProfileLanguageRequestEvent != null)
        foreach (var each in OnProfilesSetProfileLanguageRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnProfilesSetProfileLanguageRequestEvent -=
              (PlayFabRequestEvent<ProfilesModels.SetProfileLanguageRequest>) each;
      if (OnProfilesSetProfileLanguageResultEvent != null)
        foreach (var each in OnProfilesSetProfileLanguageResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnProfilesSetProfileLanguageResultEvent -=
              (PlayFabResultEvent<ProfilesModels.SetProfileLanguageResponse>) each;

      if (OnProfilesSetProfilePolicyRequestEvent != null)
        foreach (var each in OnProfilesSetProfilePolicyRequestEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnProfilesSetProfilePolicyRequestEvent -=
              (PlayFabRequestEvent<ProfilesModels.SetEntityProfilePolicyRequest>) each;
      if (OnProfilesSetProfilePolicyResultEvent != null)
        foreach (var each in OnProfilesSetProfilePolicyResultEvent.GetInvocationList())
          if (ReferenceEquals(each.Target, instance))
            OnProfilesSetProfilePolicyResultEvent -=
              (PlayFabResultEvent<ProfilesModels.SetEntityProfilePolicyResponse>) each;

#endif
    }

    private void OnProcessingErrorEvent(PlayFabRequestCommon request, PlayFabError error) {
      //This just forwards the event.
      if (_instance.OnGlobalErrorEvent != null) _instance.OnGlobalErrorEvent(request, error);
    }

    private void OnProcessingEvent(ApiProcessingEventArgs e) {
      if (e.EventType == ApiProcessingEventType.Pre) {
        var type = e.Request.GetType();
#if ENABLE_PLAYFABADMIN_API
                if (type == typeof(AdminModels.AbortTaskInstanceRequest)) { if (_instance.OnAdminAbortTaskInstanceRequestEvent != null) { _instance.OnAdminAbortTaskInstanceRequestEvent((AdminModels.AbortTaskInstanceRequest)e.Request); return; } }
                if (type == typeof(AdminModels.AddLocalizedNewsRequest)) { if (_instance.OnAdminAddLocalizedNewsRequestEvent != null) { _instance.OnAdminAddLocalizedNewsRequestEvent((AdminModels.AddLocalizedNewsRequest)e.Request); return; } }
                if (type == typeof(AdminModels.AddNewsRequest)) { if (_instance.OnAdminAddNewsRequestEvent != null) { _instance.OnAdminAddNewsRequestEvent((AdminModels.AddNewsRequest)e.Request); return; } }
                if (type == typeof(AdminModels.AddPlayerTagRequest)) { if (_instance.OnAdminAddPlayerTagRequestEvent != null) { _instance.OnAdminAddPlayerTagRequestEvent((AdminModels.AddPlayerTagRequest)e.Request); return; } }
                if (type == typeof(AdminModels.AddServerBuildRequest)) { if (_instance.OnAdminAddServerBuildRequestEvent != null) { _instance.OnAdminAddServerBuildRequestEvent((AdminModels.AddServerBuildRequest)e.Request); return; } }
                if (type == typeof(AdminModels.AddUserVirtualCurrencyRequest)) { if (_instance.OnAdminAddUserVirtualCurrencyRequestEvent != null) { _instance.OnAdminAddUserVirtualCurrencyRequestEvent((AdminModels.AddUserVirtualCurrencyRequest)e.Request); return; } }
                if (type == typeof(AdminModels.AddVirtualCurrencyTypesRequest)) { if (_instance.OnAdminAddVirtualCurrencyTypesRequestEvent != null) { _instance.OnAdminAddVirtualCurrencyTypesRequestEvent((AdminModels.AddVirtualCurrencyTypesRequest)e.Request); return; } }
                if (type == typeof(AdminModels.BanUsersRequest)) { if (_instance.OnAdminBanUsersRequestEvent != null) { _instance.OnAdminBanUsersRequestEvent((AdminModels.BanUsersRequest)e.Request); return; } }
                if (type == typeof(AdminModels.CheckLimitedEditionItemAvailabilityRequest)) { if (_instance.OnAdminCheckLimitedEditionItemAvailabilityRequestEvent != null) { _instance.OnAdminCheckLimitedEditionItemAvailabilityRequestEvent((AdminModels.CheckLimitedEditionItemAvailabilityRequest)e.Request); return; } }
                if (type == typeof(AdminModels.CreateActionsOnPlayerSegmentTaskRequest)) { if (_instance.OnAdminCreateActionsOnPlayersInSegmentTaskRequestEvent != null) { _instance.OnAdminCreateActionsOnPlayersInSegmentTaskRequestEvent((AdminModels.CreateActionsOnPlayerSegmentTaskRequest)e.Request); return; } }
                if (type == typeof(AdminModels.CreateCloudScriptTaskRequest)) { if (_instance.OnAdminCreateCloudScriptTaskRequestEvent != null) { _instance.OnAdminCreateCloudScriptTaskRequestEvent((AdminModels.CreateCloudScriptTaskRequest)e.Request); return; } }
                if (type == typeof(AdminModels.CreateInsightsScheduledScalingTaskRequest)) { if (_instance.OnAdminCreateInsightsScheduledScalingTaskRequestEvent != null) { _instance.OnAdminCreateInsightsScheduledScalingTaskRequestEvent((AdminModels.CreateInsightsScheduledScalingTaskRequest)e.Request); return; } }
                if (type == typeof(AdminModels.CreateOpenIdConnectionRequest)) { if (_instance.OnAdminCreateOpenIdConnectionRequestEvent != null) { _instance.OnAdminCreateOpenIdConnectionRequestEvent((AdminModels.CreateOpenIdConnectionRequest)e.Request); return; } }
                if (type == typeof(AdminModels.CreatePlayerSharedSecretRequest)) { if (_instance.OnAdminCreatePlayerSharedSecretRequestEvent != null) { _instance.OnAdminCreatePlayerSharedSecretRequestEvent((AdminModels.CreatePlayerSharedSecretRequest)e.Request); return; } }
                if (type == typeof(AdminModels.CreatePlayerStatisticDefinitionRequest)) { if (_instance.OnAdminCreatePlayerStatisticDefinitionRequestEvent != null) { _instance.OnAdminCreatePlayerStatisticDefinitionRequestEvent((AdminModels.CreatePlayerStatisticDefinitionRequest)e.Request); return; } }
                if (type == typeof(AdminModels.DeleteContentRequest)) { if (_instance.OnAdminDeleteContentRequestEvent != null) { _instance.OnAdminDeleteContentRequestEvent((AdminModels.DeleteContentRequest)e.Request); return; } }
                if (type == typeof(AdminModels.DeleteMasterPlayerAccountRequest)) { if (_instance.OnAdminDeleteMasterPlayerAccountRequestEvent != null) { _instance.OnAdminDeleteMasterPlayerAccountRequestEvent((AdminModels.DeleteMasterPlayerAccountRequest)e.Request); return; } }
                if (type == typeof(AdminModels.DeleteOpenIdConnectionRequest)) { if (_instance.OnAdminDeleteOpenIdConnectionRequestEvent != null) { _instance.OnAdminDeleteOpenIdConnectionRequestEvent((AdminModels.DeleteOpenIdConnectionRequest)e.Request); return; } }
                if (type == typeof(AdminModels.DeletePlayerRequest)) { if (_instance.OnAdminDeletePlayerRequestEvent != null) { _instance.OnAdminDeletePlayerRequestEvent((AdminModels.DeletePlayerRequest)e.Request); return; } }
                if (type == typeof(AdminModels.DeletePlayerSharedSecretRequest)) { if (_instance.OnAdminDeletePlayerSharedSecretRequestEvent != null) { _instance.OnAdminDeletePlayerSharedSecretRequestEvent((AdminModels.DeletePlayerSharedSecretRequest)e.Request); return; } }
                if (type == typeof(AdminModels.DeleteStoreRequest)) { if (_instance.OnAdminDeleteStoreRequestEvent != null) { _instance.OnAdminDeleteStoreRequestEvent((AdminModels.DeleteStoreRequest)e.Request); return; } }
                if (type == typeof(AdminModels.DeleteTaskRequest)) { if (_instance.OnAdminDeleteTaskRequestEvent != null) { _instance.OnAdminDeleteTaskRequestEvent((AdminModels.DeleteTaskRequest)e.Request); return; } }
                if (type == typeof(AdminModels.DeleteTitleRequest)) { if (_instance.OnAdminDeleteTitleRequestEvent != null) { _instance.OnAdminDeleteTitleRequestEvent((AdminModels.DeleteTitleRequest)e.Request); return; } }
                if (type == typeof(AdminModels.ExportMasterPlayerDataRequest)) { if (_instance.OnAdminExportMasterPlayerDataRequestEvent != null) { _instance.OnAdminExportMasterPlayerDataRequestEvent((AdminModels.ExportMasterPlayerDataRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetTaskInstanceRequest)) { if (_instance.OnAdminGetActionsOnPlayersInSegmentTaskInstanceRequestEvent != null) { _instance.OnAdminGetActionsOnPlayersInSegmentTaskInstanceRequestEvent((AdminModels.GetTaskInstanceRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetAllSegmentsRequest)) { if (_instance.OnAdminGetAllSegmentsRequestEvent != null) { _instance.OnAdminGetAllSegmentsRequestEvent((AdminModels.GetAllSegmentsRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetCatalogItemsRequest)) { if (_instance.OnAdminGetCatalogItemsRequestEvent != null) { _instance.OnAdminGetCatalogItemsRequestEvent((AdminModels.GetCatalogItemsRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetCloudScriptRevisionRequest)) { if (_instance.OnAdminGetCloudScriptRevisionRequestEvent != null) { _instance.OnAdminGetCloudScriptRevisionRequestEvent((AdminModels.GetCloudScriptRevisionRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetTaskInstanceRequest)) { if (_instance.OnAdminGetCloudScriptTaskInstanceRequestEvent != null) { _instance.OnAdminGetCloudScriptTaskInstanceRequestEvent((AdminModels.GetTaskInstanceRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetCloudScriptVersionsRequest)) { if (_instance.OnAdminGetCloudScriptVersionsRequestEvent != null) { _instance.OnAdminGetCloudScriptVersionsRequestEvent((AdminModels.GetCloudScriptVersionsRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetContentListRequest)) { if (_instance.OnAdminGetContentListRequestEvent != null) { _instance.OnAdminGetContentListRequestEvent((AdminModels.GetContentListRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetContentUploadUrlRequest)) { if (_instance.OnAdminGetContentUploadUrlRequestEvent != null) { _instance.OnAdminGetContentUploadUrlRequestEvent((AdminModels.GetContentUploadUrlRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetDataReportRequest)) { if (_instance.OnAdminGetDataReportRequestEvent != null) { _instance.OnAdminGetDataReportRequestEvent((AdminModels.GetDataReportRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetMatchmakerGameInfoRequest)) { if (_instance.OnAdminGetMatchmakerGameInfoRequestEvent != null) { _instance.OnAdminGetMatchmakerGameInfoRequestEvent((AdminModels.GetMatchmakerGameInfoRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetMatchmakerGameModesRequest)) { if (_instance.OnAdminGetMatchmakerGameModesRequestEvent != null) { _instance.OnAdminGetMatchmakerGameModesRequestEvent((AdminModels.GetMatchmakerGameModesRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetPlayedTitleListRequest)) { if (_instance.OnAdminGetPlayedTitleListRequestEvent != null) { _instance.OnAdminGetPlayedTitleListRequestEvent((AdminModels.GetPlayedTitleListRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetPlayerIdFromAuthTokenRequest)) { if (_instance.OnAdminGetPlayerIdFromAuthTokenRequestEvent != null) { _instance.OnAdminGetPlayerIdFromAuthTokenRequestEvent((AdminModels.GetPlayerIdFromAuthTokenRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetPlayerProfileRequest)) { if (_instance.OnAdminGetPlayerProfileRequestEvent != null) { _instance.OnAdminGetPlayerProfileRequestEvent((AdminModels.GetPlayerProfileRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetPlayersSegmentsRequest)) { if (_instance.OnAdminGetPlayerSegmentsRequestEvent != null) { _instance.OnAdminGetPlayerSegmentsRequestEvent((AdminModels.GetPlayersSegmentsRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetPlayerSharedSecretsRequest)) { if (_instance.OnAdminGetPlayerSharedSecretsRequestEvent != null) { _instance.OnAdminGetPlayerSharedSecretsRequestEvent((AdminModels.GetPlayerSharedSecretsRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetPlayersInSegmentRequest)) { if (_instance.OnAdminGetPlayersInSegmentRequestEvent != null) { _instance.OnAdminGetPlayersInSegmentRequestEvent((AdminModels.GetPlayersInSegmentRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetPlayerStatisticDefinitionsRequest)) { if (_instance.OnAdminGetPlayerStatisticDefinitionsRequestEvent != null) { _instance.OnAdminGetPlayerStatisticDefinitionsRequestEvent((AdminModels.GetPlayerStatisticDefinitionsRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetPlayerStatisticVersionsRequest)) { if (_instance.OnAdminGetPlayerStatisticVersionsRequestEvent != null) { _instance.OnAdminGetPlayerStatisticVersionsRequestEvent((AdminModels.GetPlayerStatisticVersionsRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetPlayerTagsRequest)) { if (_instance.OnAdminGetPlayerTagsRequestEvent != null) { _instance.OnAdminGetPlayerTagsRequestEvent((AdminModels.GetPlayerTagsRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetPolicyRequest)) { if (_instance.OnAdminGetPolicyRequestEvent != null) { _instance.OnAdminGetPolicyRequestEvent((AdminModels.GetPolicyRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetPublisherDataRequest)) { if (_instance.OnAdminGetPublisherDataRequestEvent != null) { _instance.OnAdminGetPublisherDataRequestEvent((AdminModels.GetPublisherDataRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetRandomResultTablesRequest)) { if (_instance.OnAdminGetRandomResultTablesRequestEvent != null) { _instance.OnAdminGetRandomResultTablesRequestEvent((AdminModels.GetRandomResultTablesRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetServerBuildInfoRequest)) { if (_instance.OnAdminGetServerBuildInfoRequestEvent != null) { _instance.OnAdminGetServerBuildInfoRequestEvent((AdminModels.GetServerBuildInfoRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetServerBuildUploadURLRequest)) { if (_instance.OnAdminGetServerBuildUploadUrlRequestEvent != null) { _instance.OnAdminGetServerBuildUploadUrlRequestEvent((AdminModels.GetServerBuildUploadURLRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetStoreItemsRequest)) { if (_instance.OnAdminGetStoreItemsRequestEvent != null) { _instance.OnAdminGetStoreItemsRequestEvent((AdminModels.GetStoreItemsRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetTaskInstancesRequest)) { if (_instance.OnAdminGetTaskInstancesRequestEvent != null) { _instance.OnAdminGetTaskInstancesRequestEvent((AdminModels.GetTaskInstancesRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetTasksRequest)) { if (_instance.OnAdminGetTasksRequestEvent != null) { _instance.OnAdminGetTasksRequestEvent((AdminModels.GetTasksRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetTitleDataRequest)) { if (_instance.OnAdminGetTitleDataRequestEvent != null) { _instance.OnAdminGetTitleDataRequestEvent((AdminModels.GetTitleDataRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetTitleDataRequest)) { if (_instance.OnAdminGetTitleInternalDataRequestEvent != null) { _instance.OnAdminGetTitleInternalDataRequestEvent((AdminModels.GetTitleDataRequest)e.Request); return; } }
                if (type == typeof(AdminModels.LookupUserAccountInfoRequest)) { if (_instance.OnAdminGetUserAccountInfoRequestEvent != null) { _instance.OnAdminGetUserAccountInfoRequestEvent((AdminModels.LookupUserAccountInfoRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetUserBansRequest)) { if (_instance.OnAdminGetUserBansRequestEvent != null) { _instance.OnAdminGetUserBansRequestEvent((AdminModels.GetUserBansRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetUserDataRequest)) { if (_instance.OnAdminGetUserDataRequestEvent != null) { _instance.OnAdminGetUserDataRequestEvent((AdminModels.GetUserDataRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetUserDataRequest)) { if (_instance.OnAdminGetUserInternalDataRequestEvent != null) { _instance.OnAdminGetUserInternalDataRequestEvent((AdminModels.GetUserDataRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetUserInventoryRequest)) { if (_instance.OnAdminGetUserInventoryRequestEvent != null) { _instance.OnAdminGetUserInventoryRequestEvent((AdminModels.GetUserInventoryRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetUserDataRequest)) { if (_instance.OnAdminGetUserPublisherDataRequestEvent != null) { _instance.OnAdminGetUserPublisherDataRequestEvent((AdminModels.GetUserDataRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetUserDataRequest)) { if (_instance.OnAdminGetUserPublisherInternalDataRequestEvent != null) { _instance.OnAdminGetUserPublisherInternalDataRequestEvent((AdminModels.GetUserDataRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetUserDataRequest)) { if (_instance.OnAdminGetUserPublisherReadOnlyDataRequestEvent != null) { _instance.OnAdminGetUserPublisherReadOnlyDataRequestEvent((AdminModels.GetUserDataRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GetUserDataRequest)) { if (_instance.OnAdminGetUserReadOnlyDataRequestEvent != null) { _instance.OnAdminGetUserReadOnlyDataRequestEvent((AdminModels.GetUserDataRequest)e.Request); return; } }
                if (type == typeof(AdminModels.GrantItemsToUsersRequest)) { if (_instance.OnAdminGrantItemsToUsersRequestEvent != null) { _instance.OnAdminGrantItemsToUsersRequestEvent((AdminModels.GrantItemsToUsersRequest)e.Request); return; } }
                if (type == typeof(AdminModels.IncrementLimitedEditionItemAvailabilityRequest)) { if (_instance.OnAdminIncrementLimitedEditionItemAvailabilityRequestEvent != null) { _instance.OnAdminIncrementLimitedEditionItemAvailabilityRequestEvent((AdminModels.IncrementLimitedEditionItemAvailabilityRequest)e.Request); return; } }
                if (type == typeof(AdminModels.IncrementPlayerStatisticVersionRequest)) { if (_instance.OnAdminIncrementPlayerStatisticVersionRequestEvent != null) { _instance.OnAdminIncrementPlayerStatisticVersionRequestEvent((AdminModels.IncrementPlayerStatisticVersionRequest)e.Request); return; } }
                if (type == typeof(AdminModels.ListOpenIdConnectionRequest)) { if (_instance.OnAdminListOpenIdConnectionRequestEvent != null) { _instance.OnAdminListOpenIdConnectionRequestEvent((AdminModels.ListOpenIdConnectionRequest)e.Request); return; } }
                if (type == typeof(AdminModels.ListBuildsRequest)) { if (_instance.OnAdminListServerBuildsRequestEvent != null) { _instance.OnAdminListServerBuildsRequestEvent((AdminModels.ListBuildsRequest)e.Request); return; } }
                if (type == typeof(AdminModels.ListVirtualCurrencyTypesRequest)) { if (_instance.OnAdminListVirtualCurrencyTypesRequestEvent != null) { _instance.OnAdminListVirtualCurrencyTypesRequestEvent((AdminModels.ListVirtualCurrencyTypesRequest)e.Request); return; } }
                if (type == typeof(AdminModels.ModifyMatchmakerGameModesRequest)) { if (_instance.OnAdminModifyMatchmakerGameModesRequestEvent != null) { _instance.OnAdminModifyMatchmakerGameModesRequestEvent((AdminModels.ModifyMatchmakerGameModesRequest)e.Request); return; } }
                if (type == typeof(AdminModels.ModifyServerBuildRequest)) { if (_instance.OnAdminModifyServerBuildRequestEvent != null) { _instance.OnAdminModifyServerBuildRequestEvent((AdminModels.ModifyServerBuildRequest)e.Request); return; } }
                if (type == typeof(AdminModels.RefundPurchaseRequest)) { if (_instance.OnAdminRefundPurchaseRequestEvent != null) { _instance.OnAdminRefundPurchaseRequestEvent((AdminModels.RefundPurchaseRequest)e.Request); return; } }
                if (type == typeof(AdminModels.RemovePlayerTagRequest)) { if (_instance.OnAdminRemovePlayerTagRequestEvent != null) { _instance.OnAdminRemovePlayerTagRequestEvent((AdminModels.RemovePlayerTagRequest)e.Request); return; } }
                if (type == typeof(AdminModels.RemoveServerBuildRequest)) { if (_instance.OnAdminRemoveServerBuildRequestEvent != null) { _instance.OnAdminRemoveServerBuildRequestEvent((AdminModels.RemoveServerBuildRequest)e.Request); return; } }
                if (type == typeof(AdminModels.RemoveVirtualCurrencyTypesRequest)) { if (_instance.OnAdminRemoveVirtualCurrencyTypesRequestEvent != null) { _instance.OnAdminRemoveVirtualCurrencyTypesRequestEvent((AdminModels.RemoveVirtualCurrencyTypesRequest)e.Request); return; } }
                if (type == typeof(AdminModels.ResetCharacterStatisticsRequest)) { if (_instance.OnAdminResetCharacterStatisticsRequestEvent != null) { _instance.OnAdminResetCharacterStatisticsRequestEvent((AdminModels.ResetCharacterStatisticsRequest)e.Request); return; } }
                if (type == typeof(AdminModels.ResetPasswordRequest)) { if (_instance.OnAdminResetPasswordRequestEvent != null) { _instance.OnAdminResetPasswordRequestEvent((AdminModels.ResetPasswordRequest)e.Request); return; } }
                if (type == typeof(AdminModels.ResetUserStatisticsRequest)) { if (_instance.OnAdminResetUserStatisticsRequestEvent != null) { _instance.OnAdminResetUserStatisticsRequestEvent((AdminModels.ResetUserStatisticsRequest)e.Request); return; } }
                if (type == typeof(AdminModels.ResolvePurchaseDisputeRequest)) { if (_instance.OnAdminResolvePurchaseDisputeRequestEvent != null) { _instance.OnAdminResolvePurchaseDisputeRequestEvent((AdminModels.ResolvePurchaseDisputeRequest)e.Request); return; } }
                if (type == typeof(AdminModels.RevokeAllBansForUserRequest)) { if (_instance.OnAdminRevokeAllBansForUserRequestEvent != null) { _instance.OnAdminRevokeAllBansForUserRequestEvent((AdminModels.RevokeAllBansForUserRequest)e.Request); return; } }
                if (type == typeof(AdminModels.RevokeBansRequest)) { if (_instance.OnAdminRevokeBansRequestEvent != null) { _instance.OnAdminRevokeBansRequestEvent((AdminModels.RevokeBansRequest)e.Request); return; } }
                if (type == typeof(AdminModels.RevokeInventoryItemRequest)) { if (_instance.OnAdminRevokeInventoryItemRequestEvent != null) { _instance.OnAdminRevokeInventoryItemRequestEvent((AdminModels.RevokeInventoryItemRequest)e.Request); return; } }
                if (type == typeof(AdminModels.RevokeInventoryItemsRequest)) { if (_instance.OnAdminRevokeInventoryItemsRequestEvent != null) { _instance.OnAdminRevokeInventoryItemsRequestEvent((AdminModels.RevokeInventoryItemsRequest)e.Request); return; } }
                if (type == typeof(AdminModels.RunTaskRequest)) { if (_instance.OnAdminRunTaskRequestEvent != null) { _instance.OnAdminRunTaskRequestEvent((AdminModels.RunTaskRequest)e.Request); return; } }
                if (type == typeof(AdminModels.SendAccountRecoveryEmailRequest)) { if (_instance.OnAdminSendAccountRecoveryEmailRequestEvent != null) { _instance.OnAdminSendAccountRecoveryEmailRequestEvent((AdminModels.SendAccountRecoveryEmailRequest)e.Request); return; } }
                if (type == typeof(AdminModels.UpdateCatalogItemsRequest)) { if (_instance.OnAdminSetCatalogItemsRequestEvent != null) { _instance.OnAdminSetCatalogItemsRequestEvent((AdminModels.UpdateCatalogItemsRequest)e.Request); return; } }
                if (type == typeof(AdminModels.SetPlayerSecretRequest)) { if (_instance.OnAdminSetPlayerSecretRequestEvent != null) { _instance.OnAdminSetPlayerSecretRequestEvent((AdminModels.SetPlayerSecretRequest)e.Request); return; } }
                if (type == typeof(AdminModels.SetPublishedRevisionRequest)) { if (_instance.OnAdminSetPublishedRevisionRequestEvent != null) { _instance.OnAdminSetPublishedRevisionRequestEvent((AdminModels.SetPublishedRevisionRequest)e.Request); return; } }
                if (type == typeof(AdminModels.SetPublisherDataRequest)) { if (_instance.OnAdminSetPublisherDataRequestEvent != null) { _instance.OnAdminSetPublisherDataRequestEvent((AdminModels.SetPublisherDataRequest)e.Request); return; } }
                if (type == typeof(AdminModels.UpdateStoreItemsRequest)) { if (_instance.OnAdminSetStoreItemsRequestEvent != null) { _instance.OnAdminSetStoreItemsRequestEvent((AdminModels.UpdateStoreItemsRequest)e.Request); return; } }
                if (type == typeof(AdminModels.SetTitleDataRequest)) { if (_instance.OnAdminSetTitleDataRequestEvent != null) { _instance.OnAdminSetTitleDataRequestEvent((AdminModels.SetTitleDataRequest)e.Request); return; } }
                if (type == typeof(AdminModels.SetTitleDataRequest)) { if (_instance.OnAdminSetTitleInternalDataRequestEvent != null) { _instance.OnAdminSetTitleInternalDataRequestEvent((AdminModels.SetTitleDataRequest)e.Request); return; } }
                if (type == typeof(AdminModels.SetupPushNotificationRequest)) { if (_instance.OnAdminSetupPushNotificationRequestEvent != null) { _instance.OnAdminSetupPushNotificationRequestEvent((AdminModels.SetupPushNotificationRequest)e.Request); return; } }
                if (type == typeof(AdminModels.SubtractUserVirtualCurrencyRequest)) { if (_instance.OnAdminSubtractUserVirtualCurrencyRequestEvent != null) { _instance.OnAdminSubtractUserVirtualCurrencyRequestEvent((AdminModels.SubtractUserVirtualCurrencyRequest)e.Request); return; } }
                if (type == typeof(AdminModels.UpdateBansRequest)) { if (_instance.OnAdminUpdateBansRequestEvent != null) { _instance.OnAdminUpdateBansRequestEvent((AdminModels.UpdateBansRequest)e.Request); return; } }
                if (type == typeof(AdminModels.UpdateCatalogItemsRequest)) { if (_instance.OnAdminUpdateCatalogItemsRequestEvent != null) { _instance.OnAdminUpdateCatalogItemsRequestEvent((AdminModels.UpdateCatalogItemsRequest)e.Request); return; } }
                if (type == typeof(AdminModels.UpdateCloudScriptRequest)) { if (_instance.OnAdminUpdateCloudScriptRequestEvent != null) { _instance.OnAdminUpdateCloudScriptRequestEvent((AdminModels.UpdateCloudScriptRequest)e.Request); return; } }
                if (type == typeof(AdminModels.UpdateOpenIdConnectionRequest)) { if (_instance.OnAdminUpdateOpenIdConnectionRequestEvent != null) { _instance.OnAdminUpdateOpenIdConnectionRequestEvent((AdminModels.UpdateOpenIdConnectionRequest)e.Request); return; } }
                if (type == typeof(AdminModels.UpdatePlayerSharedSecretRequest)) { if (_instance.OnAdminUpdatePlayerSharedSecretRequestEvent != null) { _instance.OnAdminUpdatePlayerSharedSecretRequestEvent((AdminModels.UpdatePlayerSharedSecretRequest)e.Request); return; } }
                if (type == typeof(AdminModels.UpdatePlayerStatisticDefinitionRequest)) { if (_instance.OnAdminUpdatePlayerStatisticDefinitionRequestEvent != null) { _instance.OnAdminUpdatePlayerStatisticDefinitionRequestEvent((AdminModels.UpdatePlayerStatisticDefinitionRequest)e.Request); return; } }
                if (type == typeof(AdminModels.UpdatePolicyRequest)) { if (_instance.OnAdminUpdatePolicyRequestEvent != null) { _instance.OnAdminUpdatePolicyRequestEvent((AdminModels.UpdatePolicyRequest)e.Request); return; } }
                if (type == typeof(AdminModels.UpdateRandomResultTablesRequest)) { if (_instance.OnAdminUpdateRandomResultTablesRequestEvent != null) { _instance.OnAdminUpdateRandomResultTablesRequestEvent((AdminModels.UpdateRandomResultTablesRequest)e.Request); return; } }
                if (type == typeof(AdminModels.UpdateStoreItemsRequest)) { if (_instance.OnAdminUpdateStoreItemsRequestEvent != null) { _instance.OnAdminUpdateStoreItemsRequestEvent((AdminModels.UpdateStoreItemsRequest)e.Request); return; } }
                if (type == typeof(AdminModels.UpdateTaskRequest)) { if (_instance.OnAdminUpdateTaskRequestEvent != null) { _instance.OnAdminUpdateTaskRequestEvent((AdminModels.UpdateTaskRequest)e.Request); return; } }
                if (type == typeof(AdminModels.UpdateUserDataRequest)) { if (_instance.OnAdminUpdateUserDataRequestEvent != null) { _instance.OnAdminUpdateUserDataRequestEvent((AdminModels.UpdateUserDataRequest)e.Request); return; } }
                if (type == typeof(AdminModels.UpdateUserInternalDataRequest)) { if (_instance.OnAdminUpdateUserInternalDataRequestEvent != null) { _instance.OnAdminUpdateUserInternalDataRequestEvent((AdminModels.UpdateUserInternalDataRequest)e.Request); return; } }
                if (type == typeof(AdminModels.UpdateUserDataRequest)) { if (_instance.OnAdminUpdateUserPublisherDataRequestEvent != null) { _instance.OnAdminUpdateUserPublisherDataRequestEvent((AdminModels.UpdateUserDataRequest)e.Request); return; } }
                if (type == typeof(AdminModels.UpdateUserInternalDataRequest)) { if (_instance.OnAdminUpdateUserPublisherInternalDataRequestEvent != null) { _instance.OnAdminUpdateUserPublisherInternalDataRequestEvent((AdminModels.UpdateUserInternalDataRequest)e.Request); return; } }
                if (type == typeof(AdminModels.UpdateUserDataRequest)) { if (_instance.OnAdminUpdateUserPublisherReadOnlyDataRequestEvent != null) { _instance.OnAdminUpdateUserPublisherReadOnlyDataRequestEvent((AdminModels.UpdateUserDataRequest)e.Request); return; } }
                if (type == typeof(AdminModels.UpdateUserDataRequest)) { if (_instance.OnAdminUpdateUserReadOnlyDataRequestEvent != null) { _instance.OnAdminUpdateUserReadOnlyDataRequestEvent((AdminModels.UpdateUserDataRequest)e.Request); return; } }
                if (type == typeof(AdminModels.UpdateUserTitleDisplayNameRequest)) { if (_instance.OnAdminUpdateUserTitleDisplayNameRequestEvent != null) { _instance.OnAdminUpdateUserTitleDisplayNameRequestEvent((AdminModels.UpdateUserTitleDisplayNameRequest)e.Request); return; } }
#endif
#if !DISABLE_PLAYFABCLIENT_API
        if (type == typeof(ClientModels.AcceptTradeRequest))
          if (_instance.OnAcceptTradeRequestEvent != null) {
            _instance.OnAcceptTradeRequestEvent((ClientModels.AcceptTradeRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.AddFriendRequest))
          if (_instance.OnAddFriendRequestEvent != null) {
            _instance.OnAddFriendRequestEvent((ClientModels.AddFriendRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.AddGenericIDRequest))
          if (_instance.OnAddGenericIDRequestEvent != null) {
            _instance.OnAddGenericIDRequestEvent((ClientModels.AddGenericIDRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.AddOrUpdateContactEmailRequest))
          if (_instance.OnAddOrUpdateContactEmailRequestEvent != null) {
            _instance.OnAddOrUpdateContactEmailRequestEvent((ClientModels.AddOrUpdateContactEmailRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.AddSharedGroupMembersRequest))
          if (_instance.OnAddSharedGroupMembersRequestEvent != null) {
            _instance.OnAddSharedGroupMembersRequestEvent((ClientModels.AddSharedGroupMembersRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.AddUsernamePasswordRequest))
          if (_instance.OnAddUsernamePasswordRequestEvent != null) {
            _instance.OnAddUsernamePasswordRequestEvent((ClientModels.AddUsernamePasswordRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.AddUserVirtualCurrencyRequest))
          if (_instance.OnAddUserVirtualCurrencyRequestEvent != null) {
            _instance.OnAddUserVirtualCurrencyRequestEvent((ClientModels.AddUserVirtualCurrencyRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.AndroidDevicePushNotificationRegistrationRequest))
          if (_instance.OnAndroidDevicePushNotificationRegistrationRequestEvent != null) {
            _instance.OnAndroidDevicePushNotificationRegistrationRequestEvent(
              (ClientModels.AndroidDevicePushNotificationRegistrationRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.AttributeInstallRequest))
          if (_instance.OnAttributeInstallRequestEvent != null) {
            _instance.OnAttributeInstallRequestEvent((ClientModels.AttributeInstallRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.CancelTradeRequest))
          if (_instance.OnCancelTradeRequestEvent != null) {
            _instance.OnCancelTradeRequestEvent((ClientModels.CancelTradeRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.ConfirmPurchaseRequest))
          if (_instance.OnConfirmPurchaseRequestEvent != null) {
            _instance.OnConfirmPurchaseRequestEvent((ClientModels.ConfirmPurchaseRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.ConsumeItemRequest))
          if (_instance.OnConsumeItemRequestEvent != null) {
            _instance.OnConsumeItemRequestEvent((ClientModels.ConsumeItemRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.ConsumePSNEntitlementsRequest))
          if (_instance.OnConsumePSNEntitlementsRequestEvent != null) {
            _instance.OnConsumePSNEntitlementsRequestEvent((ClientModels.ConsumePSNEntitlementsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.ConsumeXboxEntitlementsRequest))
          if (_instance.OnConsumeXboxEntitlementsRequestEvent != null) {
            _instance.OnConsumeXboxEntitlementsRequestEvent((ClientModels.ConsumeXboxEntitlementsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.CreateSharedGroupRequest))
          if (_instance.OnCreateSharedGroupRequestEvent != null) {
            _instance.OnCreateSharedGroupRequestEvent((ClientModels.CreateSharedGroupRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.ExecuteCloudScriptRequest))
          if (_instance.OnExecuteCloudScriptRequestEvent != null) {
            _instance.OnExecuteCloudScriptRequestEvent((ClientModels.ExecuteCloudScriptRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetAccountInfoRequest))
          if (_instance.OnGetAccountInfoRequestEvent != null) {
            _instance.OnGetAccountInfoRequestEvent((ClientModels.GetAccountInfoRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetAdPlacementsRequest))
          if (_instance.OnGetAdPlacementsRequestEvent != null) {
            _instance.OnGetAdPlacementsRequestEvent((ClientModels.GetAdPlacementsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.ListUsersCharactersRequest))
          if (_instance.OnGetAllUsersCharactersRequestEvent != null) {
            _instance.OnGetAllUsersCharactersRequestEvent((ClientModels.ListUsersCharactersRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetCatalogItemsRequest))
          if (_instance.OnGetCatalogItemsRequestEvent != null) {
            _instance.OnGetCatalogItemsRequestEvent((ClientModels.GetCatalogItemsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetCharacterDataRequest))
          if (_instance.OnGetCharacterDataRequestEvent != null) {
            _instance.OnGetCharacterDataRequestEvent((ClientModels.GetCharacterDataRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetCharacterInventoryRequest))
          if (_instance.OnGetCharacterInventoryRequestEvent != null) {
            _instance.OnGetCharacterInventoryRequestEvent((ClientModels.GetCharacterInventoryRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetCharacterLeaderboardRequest))
          if (_instance.OnGetCharacterLeaderboardRequestEvent != null) {
            _instance.OnGetCharacterLeaderboardRequestEvent((ClientModels.GetCharacterLeaderboardRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetCharacterDataRequest))
          if (_instance.OnGetCharacterReadOnlyDataRequestEvent != null) {
            _instance.OnGetCharacterReadOnlyDataRequestEvent((ClientModels.GetCharacterDataRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetCharacterStatisticsRequest))
          if (_instance.OnGetCharacterStatisticsRequestEvent != null) {
            _instance.OnGetCharacterStatisticsRequestEvent((ClientModels.GetCharacterStatisticsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetContentDownloadUrlRequest))
          if (_instance.OnGetContentDownloadUrlRequestEvent != null) {
            _instance.OnGetContentDownloadUrlRequestEvent((ClientModels.GetContentDownloadUrlRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.CurrentGamesRequest))
          if (_instance.OnGetCurrentGamesRequestEvent != null) {
            _instance.OnGetCurrentGamesRequestEvent((ClientModels.CurrentGamesRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetFriendLeaderboardRequest))
          if (_instance.OnGetFriendLeaderboardRequestEvent != null) {
            _instance.OnGetFriendLeaderboardRequestEvent((ClientModels.GetFriendLeaderboardRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetFriendLeaderboardAroundPlayerRequest))
          if (_instance.OnGetFriendLeaderboardAroundPlayerRequestEvent != null) {
            _instance.OnGetFriendLeaderboardAroundPlayerRequestEvent(
              (ClientModels.GetFriendLeaderboardAroundPlayerRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetFriendsListRequest))
          if (_instance.OnGetFriendsListRequestEvent != null) {
            _instance.OnGetFriendsListRequestEvent((ClientModels.GetFriendsListRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GameServerRegionsRequest))
          if (_instance.OnGetGameServerRegionsRequestEvent != null) {
            _instance.OnGetGameServerRegionsRequestEvent((ClientModels.GameServerRegionsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetLeaderboardRequest))
          if (_instance.OnGetLeaderboardRequestEvent != null) {
            _instance.OnGetLeaderboardRequestEvent((ClientModels.GetLeaderboardRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetLeaderboardAroundCharacterRequest))
          if (_instance.OnGetLeaderboardAroundCharacterRequestEvent != null) {
            _instance.OnGetLeaderboardAroundCharacterRequestEvent(
              (ClientModels.GetLeaderboardAroundCharacterRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetLeaderboardAroundPlayerRequest))
          if (_instance.OnGetLeaderboardAroundPlayerRequestEvent != null) {
            _instance.OnGetLeaderboardAroundPlayerRequestEvent(
              (ClientModels.GetLeaderboardAroundPlayerRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetLeaderboardForUsersCharactersRequest))
          if (_instance.OnGetLeaderboardForUserCharactersRequestEvent != null) {
            _instance.OnGetLeaderboardForUserCharactersRequestEvent(
              (ClientModels.GetLeaderboardForUsersCharactersRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetPaymentTokenRequest))
          if (_instance.OnGetPaymentTokenRequestEvent != null) {
            _instance.OnGetPaymentTokenRequestEvent((ClientModels.GetPaymentTokenRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetPhotonAuthenticationTokenRequest))
          if (_instance.OnGetPhotonAuthenticationTokenRequestEvent != null) {
            _instance.OnGetPhotonAuthenticationTokenRequestEvent(
              (ClientModels.GetPhotonAuthenticationTokenRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetPlayerCombinedInfoRequest))
          if (_instance.OnGetPlayerCombinedInfoRequestEvent != null) {
            _instance.OnGetPlayerCombinedInfoRequestEvent((ClientModels.GetPlayerCombinedInfoRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetPlayerProfileRequest))
          if (_instance.OnGetPlayerProfileRequestEvent != null) {
            _instance.OnGetPlayerProfileRequestEvent((ClientModels.GetPlayerProfileRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetPlayerSegmentsRequest))
          if (_instance.OnGetPlayerSegmentsRequestEvent != null) {
            _instance.OnGetPlayerSegmentsRequestEvent((ClientModels.GetPlayerSegmentsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetPlayerStatisticsRequest))
          if (_instance.OnGetPlayerStatisticsRequestEvent != null) {
            _instance.OnGetPlayerStatisticsRequestEvent((ClientModels.GetPlayerStatisticsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetPlayerStatisticVersionsRequest))
          if (_instance.OnGetPlayerStatisticVersionsRequestEvent != null) {
            _instance.OnGetPlayerStatisticVersionsRequestEvent(
              (ClientModels.GetPlayerStatisticVersionsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetPlayerTagsRequest))
          if (_instance.OnGetPlayerTagsRequestEvent != null) {
            _instance.OnGetPlayerTagsRequestEvent((ClientModels.GetPlayerTagsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetPlayerTradesRequest))
          if (_instance.OnGetPlayerTradesRequestEvent != null) {
            _instance.OnGetPlayerTradesRequestEvent((ClientModels.GetPlayerTradesRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetPlayFabIDsFromFacebookIDsRequest))
          if (_instance.OnGetPlayFabIDsFromFacebookIDsRequestEvent != null) {
            _instance.OnGetPlayFabIDsFromFacebookIDsRequestEvent(
              (ClientModels.GetPlayFabIDsFromFacebookIDsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetPlayFabIDsFromFacebookInstantGamesIdsRequest))
          if (_instance.OnGetPlayFabIDsFromFacebookInstantGamesIdsRequestEvent != null) {
            _instance.OnGetPlayFabIDsFromFacebookInstantGamesIdsRequestEvent(
              (ClientModels.GetPlayFabIDsFromFacebookInstantGamesIdsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetPlayFabIDsFromGameCenterIDsRequest))
          if (_instance.OnGetPlayFabIDsFromGameCenterIDsRequestEvent != null) {
            _instance.OnGetPlayFabIDsFromGameCenterIDsRequestEvent(
              (ClientModels.GetPlayFabIDsFromGameCenterIDsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetPlayFabIDsFromGenericIDsRequest))
          if (_instance.OnGetPlayFabIDsFromGenericIDsRequestEvent != null) {
            _instance.OnGetPlayFabIDsFromGenericIDsRequestEvent(
              (ClientModels.GetPlayFabIDsFromGenericIDsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetPlayFabIDsFromGoogleIDsRequest))
          if (_instance.OnGetPlayFabIDsFromGoogleIDsRequestEvent != null) {
            _instance.OnGetPlayFabIDsFromGoogleIDsRequestEvent(
              (ClientModels.GetPlayFabIDsFromGoogleIDsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetPlayFabIDsFromKongregateIDsRequest))
          if (_instance.OnGetPlayFabIDsFromKongregateIDsRequestEvent != null) {
            _instance.OnGetPlayFabIDsFromKongregateIDsRequestEvent(
              (ClientModels.GetPlayFabIDsFromKongregateIDsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetPlayFabIDsFromNintendoSwitchDeviceIdsRequest))
          if (_instance.OnGetPlayFabIDsFromNintendoSwitchDeviceIdsRequestEvent != null) {
            _instance.OnGetPlayFabIDsFromNintendoSwitchDeviceIdsRequestEvent(
              (ClientModels.GetPlayFabIDsFromNintendoSwitchDeviceIdsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetPlayFabIDsFromPSNAccountIDsRequest))
          if (_instance.OnGetPlayFabIDsFromPSNAccountIDsRequestEvent != null) {
            _instance.OnGetPlayFabIDsFromPSNAccountIDsRequestEvent(
              (ClientModels.GetPlayFabIDsFromPSNAccountIDsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetPlayFabIDsFromSteamIDsRequest))
          if (_instance.OnGetPlayFabIDsFromSteamIDsRequestEvent != null) {
            _instance.OnGetPlayFabIDsFromSteamIDsRequestEvent(
              (ClientModels.GetPlayFabIDsFromSteamIDsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetPlayFabIDsFromTwitchIDsRequest))
          if (_instance.OnGetPlayFabIDsFromTwitchIDsRequestEvent != null) {
            _instance.OnGetPlayFabIDsFromTwitchIDsRequestEvent(
              (ClientModels.GetPlayFabIDsFromTwitchIDsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetPlayFabIDsFromXboxLiveIDsRequest))
          if (_instance.OnGetPlayFabIDsFromXboxLiveIDsRequestEvent != null) {
            _instance.OnGetPlayFabIDsFromXboxLiveIDsRequestEvent(
              (ClientModels.GetPlayFabIDsFromXboxLiveIDsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetPublisherDataRequest))
          if (_instance.OnGetPublisherDataRequestEvent != null) {
            _instance.OnGetPublisherDataRequestEvent((ClientModels.GetPublisherDataRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetPurchaseRequest))
          if (_instance.OnGetPurchaseRequestEvent != null) {
            _instance.OnGetPurchaseRequestEvent((ClientModels.GetPurchaseRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetSharedGroupDataRequest))
          if (_instance.OnGetSharedGroupDataRequestEvent != null) {
            _instance.OnGetSharedGroupDataRequestEvent((ClientModels.GetSharedGroupDataRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetStoreItemsRequest))
          if (_instance.OnGetStoreItemsRequestEvent != null) {
            _instance.OnGetStoreItemsRequestEvent((ClientModels.GetStoreItemsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetTimeRequest))
          if (_instance.OnGetTimeRequestEvent != null) {
            _instance.OnGetTimeRequestEvent((ClientModels.GetTimeRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetTitleDataRequest))
          if (_instance.OnGetTitleDataRequestEvent != null) {
            _instance.OnGetTitleDataRequestEvent((ClientModels.GetTitleDataRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetTitleNewsRequest))
          if (_instance.OnGetTitleNewsRequestEvent != null) {
            _instance.OnGetTitleNewsRequestEvent((ClientModels.GetTitleNewsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetTitlePublicKeyRequest))
          if (_instance.OnGetTitlePublicKeyRequestEvent != null) {
            _instance.OnGetTitlePublicKeyRequestEvent((ClientModels.GetTitlePublicKeyRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetTradeStatusRequest))
          if (_instance.OnGetTradeStatusRequestEvent != null) {
            _instance.OnGetTradeStatusRequestEvent((ClientModels.GetTradeStatusRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetUserDataRequest))
          if (_instance.OnGetUserDataRequestEvent != null) {
            _instance.OnGetUserDataRequestEvent((ClientModels.GetUserDataRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetUserInventoryRequest))
          if (_instance.OnGetUserInventoryRequestEvent != null) {
            _instance.OnGetUserInventoryRequestEvent((ClientModels.GetUserInventoryRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetUserDataRequest))
          if (_instance.OnGetUserPublisherDataRequestEvent != null) {
            _instance.OnGetUserPublisherDataRequestEvent((ClientModels.GetUserDataRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetUserDataRequest))
          if (_instance.OnGetUserPublisherReadOnlyDataRequestEvent != null) {
            _instance.OnGetUserPublisherReadOnlyDataRequestEvent((ClientModels.GetUserDataRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetUserDataRequest))
          if (_instance.OnGetUserReadOnlyDataRequestEvent != null) {
            _instance.OnGetUserReadOnlyDataRequestEvent((ClientModels.GetUserDataRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GetWindowsHelloChallengeRequest))
          if (_instance.OnGetWindowsHelloChallengeRequestEvent != null) {
            _instance.OnGetWindowsHelloChallengeRequestEvent((ClientModels.GetWindowsHelloChallengeRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.GrantCharacterToUserRequest))
          if (_instance.OnGrantCharacterToUserRequestEvent != null) {
            _instance.OnGrantCharacterToUserRequestEvent((ClientModels.GrantCharacterToUserRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LinkAndroidDeviceIDRequest))
          if (_instance.OnLinkAndroidDeviceIDRequestEvent != null) {
            _instance.OnLinkAndroidDeviceIDRequestEvent((ClientModels.LinkAndroidDeviceIDRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LinkAppleRequest))
          if (_instance.OnLinkAppleRequestEvent != null) {
            _instance.OnLinkAppleRequestEvent((ClientModels.LinkAppleRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LinkCustomIDRequest))
          if (_instance.OnLinkCustomIDRequestEvent != null) {
            _instance.OnLinkCustomIDRequestEvent((ClientModels.LinkCustomIDRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LinkFacebookAccountRequest))
          if (_instance.OnLinkFacebookAccountRequestEvent != null) {
            _instance.OnLinkFacebookAccountRequestEvent((ClientModels.LinkFacebookAccountRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LinkFacebookInstantGamesIdRequest))
          if (_instance.OnLinkFacebookInstantGamesIdRequestEvent != null) {
            _instance.OnLinkFacebookInstantGamesIdRequestEvent(
              (ClientModels.LinkFacebookInstantGamesIdRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LinkGameCenterAccountRequest))
          if (_instance.OnLinkGameCenterAccountRequestEvent != null) {
            _instance.OnLinkGameCenterAccountRequestEvent((ClientModels.LinkGameCenterAccountRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LinkGoogleAccountRequest))
          if (_instance.OnLinkGoogleAccountRequestEvent != null) {
            _instance.OnLinkGoogleAccountRequestEvent((ClientModels.LinkGoogleAccountRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LinkIOSDeviceIDRequest))
          if (_instance.OnLinkIOSDeviceIDRequestEvent != null) {
            _instance.OnLinkIOSDeviceIDRequestEvent((ClientModels.LinkIOSDeviceIDRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LinkKongregateAccountRequest))
          if (_instance.OnLinkKongregateRequestEvent != null) {
            _instance.OnLinkKongregateRequestEvent((ClientModels.LinkKongregateAccountRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LinkNintendoAccountRequest))
          if (_instance.OnLinkNintendoAccountRequestEvent != null) {
            _instance.OnLinkNintendoAccountRequestEvent((ClientModels.LinkNintendoAccountRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LinkNintendoSwitchDeviceIdRequest))
          if (_instance.OnLinkNintendoSwitchDeviceIdRequestEvent != null) {
            _instance.OnLinkNintendoSwitchDeviceIdRequestEvent(
              (ClientModels.LinkNintendoSwitchDeviceIdRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LinkOpenIdConnectRequest))
          if (_instance.OnLinkOpenIdConnectRequestEvent != null) {
            _instance.OnLinkOpenIdConnectRequestEvent((ClientModels.LinkOpenIdConnectRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LinkPSNAccountRequest))
          if (_instance.OnLinkPSNAccountRequestEvent != null) {
            _instance.OnLinkPSNAccountRequestEvent((ClientModels.LinkPSNAccountRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LinkSteamAccountRequest))
          if (_instance.OnLinkSteamAccountRequestEvent != null) {
            _instance.OnLinkSteamAccountRequestEvent((ClientModels.LinkSteamAccountRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LinkTwitchAccountRequest))
          if (_instance.OnLinkTwitchRequestEvent != null) {
            _instance.OnLinkTwitchRequestEvent((ClientModels.LinkTwitchAccountRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LinkWindowsHelloAccountRequest))
          if (_instance.OnLinkWindowsHelloRequestEvent != null) {
            _instance.OnLinkWindowsHelloRequestEvent((ClientModels.LinkWindowsHelloAccountRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LinkXboxAccountRequest))
          if (_instance.OnLinkXboxAccountRequestEvent != null) {
            _instance.OnLinkXboxAccountRequestEvent((ClientModels.LinkXboxAccountRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LoginWithAndroidDeviceIDRequest))
          if (_instance.OnLoginWithAndroidDeviceIDRequestEvent != null) {
            _instance.OnLoginWithAndroidDeviceIDRequestEvent((ClientModels.LoginWithAndroidDeviceIDRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LoginWithAppleRequest))
          if (_instance.OnLoginWithAppleRequestEvent != null) {
            _instance.OnLoginWithAppleRequestEvent((ClientModels.LoginWithAppleRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LoginWithCustomIDRequest))
          if (_instance.OnLoginWithCustomIDRequestEvent != null) {
            _instance.OnLoginWithCustomIDRequestEvent((ClientModels.LoginWithCustomIDRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LoginWithEmailAddressRequest))
          if (_instance.OnLoginWithEmailAddressRequestEvent != null) {
            _instance.OnLoginWithEmailAddressRequestEvent((ClientModels.LoginWithEmailAddressRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LoginWithFacebookRequest))
          if (_instance.OnLoginWithFacebookRequestEvent != null) {
            _instance.OnLoginWithFacebookRequestEvent((ClientModels.LoginWithFacebookRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LoginWithFacebookInstantGamesIdRequest))
          if (_instance.OnLoginWithFacebookInstantGamesIdRequestEvent != null) {
            _instance.OnLoginWithFacebookInstantGamesIdRequestEvent(
              (ClientModels.LoginWithFacebookInstantGamesIdRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LoginWithGameCenterRequest))
          if (_instance.OnLoginWithGameCenterRequestEvent != null) {
            _instance.OnLoginWithGameCenterRequestEvent((ClientModels.LoginWithGameCenterRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LoginWithGoogleAccountRequest))
          if (_instance.OnLoginWithGoogleAccountRequestEvent != null) {
            _instance.OnLoginWithGoogleAccountRequestEvent((ClientModels.LoginWithGoogleAccountRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LoginWithIOSDeviceIDRequest))
          if (_instance.OnLoginWithIOSDeviceIDRequestEvent != null) {
            _instance.OnLoginWithIOSDeviceIDRequestEvent((ClientModels.LoginWithIOSDeviceIDRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LoginWithKongregateRequest))
          if (_instance.OnLoginWithKongregateRequestEvent != null) {
            _instance.OnLoginWithKongregateRequestEvent((ClientModels.LoginWithKongregateRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LoginWithNintendoAccountRequest))
          if (_instance.OnLoginWithNintendoAccountRequestEvent != null) {
            _instance.OnLoginWithNintendoAccountRequestEvent((ClientModels.LoginWithNintendoAccountRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LoginWithNintendoSwitchDeviceIdRequest))
          if (_instance.OnLoginWithNintendoSwitchDeviceIdRequestEvent != null) {
            _instance.OnLoginWithNintendoSwitchDeviceIdRequestEvent(
              (ClientModels.LoginWithNintendoSwitchDeviceIdRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LoginWithOpenIdConnectRequest))
          if (_instance.OnLoginWithOpenIdConnectRequestEvent != null) {
            _instance.OnLoginWithOpenIdConnectRequestEvent((ClientModels.LoginWithOpenIdConnectRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LoginWithPlayFabRequest))
          if (_instance.OnLoginWithPlayFabRequestEvent != null) {
            _instance.OnLoginWithPlayFabRequestEvent((ClientModels.LoginWithPlayFabRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LoginWithPSNRequest))
          if (_instance.OnLoginWithPSNRequestEvent != null) {
            _instance.OnLoginWithPSNRequestEvent((ClientModels.LoginWithPSNRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LoginWithSteamRequest))
          if (_instance.OnLoginWithSteamRequestEvent != null) {
            _instance.OnLoginWithSteamRequestEvent((ClientModels.LoginWithSteamRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LoginWithTwitchRequest))
          if (_instance.OnLoginWithTwitchRequestEvent != null) {
            _instance.OnLoginWithTwitchRequestEvent((ClientModels.LoginWithTwitchRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LoginWithWindowsHelloRequest))
          if (_instance.OnLoginWithWindowsHelloRequestEvent != null) {
            _instance.OnLoginWithWindowsHelloRequestEvent((ClientModels.LoginWithWindowsHelloRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.LoginWithXboxRequest))
          if (_instance.OnLoginWithXboxRequestEvent != null) {
            _instance.OnLoginWithXboxRequestEvent((ClientModels.LoginWithXboxRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.MatchmakeRequest))
          if (_instance.OnMatchmakeRequestEvent != null) {
            _instance.OnMatchmakeRequestEvent((ClientModels.MatchmakeRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.OpenTradeRequest))
          if (_instance.OnOpenTradeRequestEvent != null) {
            _instance.OnOpenTradeRequestEvent((ClientModels.OpenTradeRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.PayForPurchaseRequest))
          if (_instance.OnPayForPurchaseRequestEvent != null) {
            _instance.OnPayForPurchaseRequestEvent((ClientModels.PayForPurchaseRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.PurchaseItemRequest))
          if (_instance.OnPurchaseItemRequestEvent != null) {
            _instance.OnPurchaseItemRequestEvent((ClientModels.PurchaseItemRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.RedeemCouponRequest))
          if (_instance.OnRedeemCouponRequestEvent != null) {
            _instance.OnRedeemCouponRequestEvent((ClientModels.RedeemCouponRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.RefreshPSNAuthTokenRequest))
          if (_instance.OnRefreshPSNAuthTokenRequestEvent != null) {
            _instance.OnRefreshPSNAuthTokenRequestEvent((ClientModels.RefreshPSNAuthTokenRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.RegisterForIOSPushNotificationRequest))
          if (_instance.OnRegisterForIOSPushNotificationRequestEvent != null) {
            _instance.OnRegisterForIOSPushNotificationRequestEvent(
              (ClientModels.RegisterForIOSPushNotificationRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.RegisterPlayFabUserRequest))
          if (_instance.OnRegisterPlayFabUserRequestEvent != null) {
            _instance.OnRegisterPlayFabUserRequestEvent((ClientModels.RegisterPlayFabUserRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.RegisterWithWindowsHelloRequest))
          if (_instance.OnRegisterWithWindowsHelloRequestEvent != null) {
            _instance.OnRegisterWithWindowsHelloRequestEvent((ClientModels.RegisterWithWindowsHelloRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.RemoveContactEmailRequest))
          if (_instance.OnRemoveContactEmailRequestEvent != null) {
            _instance.OnRemoveContactEmailRequestEvent((ClientModels.RemoveContactEmailRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.RemoveFriendRequest))
          if (_instance.OnRemoveFriendRequestEvent != null) {
            _instance.OnRemoveFriendRequestEvent((ClientModels.RemoveFriendRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.RemoveGenericIDRequest))
          if (_instance.OnRemoveGenericIDRequestEvent != null) {
            _instance.OnRemoveGenericIDRequestEvent((ClientModels.RemoveGenericIDRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.RemoveSharedGroupMembersRequest))
          if (_instance.OnRemoveSharedGroupMembersRequestEvent != null) {
            _instance.OnRemoveSharedGroupMembersRequestEvent((ClientModels.RemoveSharedGroupMembersRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.ReportAdActivityRequest))
          if (_instance.OnReportAdActivityRequestEvent != null) {
            _instance.OnReportAdActivityRequestEvent((ClientModels.ReportAdActivityRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.DeviceInfoRequest))
          if (_instance.OnReportDeviceInfoRequestEvent != null) {
            _instance.OnReportDeviceInfoRequestEvent((ClientModels.DeviceInfoRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.ReportPlayerClientRequest))
          if (_instance.OnReportPlayerRequestEvent != null) {
            _instance.OnReportPlayerRequestEvent((ClientModels.ReportPlayerClientRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.RestoreIOSPurchasesRequest))
          if (_instance.OnRestoreIOSPurchasesRequestEvent != null) {
            _instance.OnRestoreIOSPurchasesRequestEvent((ClientModels.RestoreIOSPurchasesRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.RewardAdActivityRequest))
          if (_instance.OnRewardAdActivityRequestEvent != null) {
            _instance.OnRewardAdActivityRequestEvent((ClientModels.RewardAdActivityRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.SendAccountRecoveryEmailRequest))
          if (_instance.OnSendAccountRecoveryEmailRequestEvent != null) {
            _instance.OnSendAccountRecoveryEmailRequestEvent((ClientModels.SendAccountRecoveryEmailRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.SetFriendTagsRequest))
          if (_instance.OnSetFriendTagsRequestEvent != null) {
            _instance.OnSetFriendTagsRequestEvent((ClientModels.SetFriendTagsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.SetPlayerSecretRequest))
          if (_instance.OnSetPlayerSecretRequestEvent != null) {
            _instance.OnSetPlayerSecretRequestEvent((ClientModels.SetPlayerSecretRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.StartGameRequest))
          if (_instance.OnStartGameRequestEvent != null) {
            _instance.OnStartGameRequestEvent((ClientModels.StartGameRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.StartPurchaseRequest))
          if (_instance.OnStartPurchaseRequestEvent != null) {
            _instance.OnStartPurchaseRequestEvent((ClientModels.StartPurchaseRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.SubtractUserVirtualCurrencyRequest))
          if (_instance.OnSubtractUserVirtualCurrencyRequestEvent != null) {
            _instance.OnSubtractUserVirtualCurrencyRequestEvent(
              (ClientModels.SubtractUserVirtualCurrencyRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UnlinkAndroidDeviceIDRequest))
          if (_instance.OnUnlinkAndroidDeviceIDRequestEvent != null) {
            _instance.OnUnlinkAndroidDeviceIDRequestEvent((ClientModels.UnlinkAndroidDeviceIDRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UnlinkAppleRequest))
          if (_instance.OnUnlinkAppleRequestEvent != null) {
            _instance.OnUnlinkAppleRequestEvent((ClientModels.UnlinkAppleRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UnlinkCustomIDRequest))
          if (_instance.OnUnlinkCustomIDRequestEvent != null) {
            _instance.OnUnlinkCustomIDRequestEvent((ClientModels.UnlinkCustomIDRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UnlinkFacebookAccountRequest))
          if (_instance.OnUnlinkFacebookAccountRequestEvent != null) {
            _instance.OnUnlinkFacebookAccountRequestEvent((ClientModels.UnlinkFacebookAccountRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UnlinkFacebookInstantGamesIdRequest))
          if (_instance.OnUnlinkFacebookInstantGamesIdRequestEvent != null) {
            _instance.OnUnlinkFacebookInstantGamesIdRequestEvent(
              (ClientModels.UnlinkFacebookInstantGamesIdRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UnlinkGameCenterAccountRequest))
          if (_instance.OnUnlinkGameCenterAccountRequestEvent != null) {
            _instance.OnUnlinkGameCenterAccountRequestEvent((ClientModels.UnlinkGameCenterAccountRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UnlinkGoogleAccountRequest))
          if (_instance.OnUnlinkGoogleAccountRequestEvent != null) {
            _instance.OnUnlinkGoogleAccountRequestEvent((ClientModels.UnlinkGoogleAccountRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UnlinkIOSDeviceIDRequest))
          if (_instance.OnUnlinkIOSDeviceIDRequestEvent != null) {
            _instance.OnUnlinkIOSDeviceIDRequestEvent((ClientModels.UnlinkIOSDeviceIDRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UnlinkKongregateAccountRequest))
          if (_instance.OnUnlinkKongregateRequestEvent != null) {
            _instance.OnUnlinkKongregateRequestEvent((ClientModels.UnlinkKongregateAccountRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UnlinkNintendoAccountRequest))
          if (_instance.OnUnlinkNintendoAccountRequestEvent != null) {
            _instance.OnUnlinkNintendoAccountRequestEvent((ClientModels.UnlinkNintendoAccountRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UnlinkNintendoSwitchDeviceIdRequest))
          if (_instance.OnUnlinkNintendoSwitchDeviceIdRequestEvent != null) {
            _instance.OnUnlinkNintendoSwitchDeviceIdRequestEvent(
              (ClientModels.UnlinkNintendoSwitchDeviceIdRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UnlinkOpenIdConnectRequest))
          if (_instance.OnUnlinkOpenIdConnectRequestEvent != null) {
            _instance.OnUnlinkOpenIdConnectRequestEvent((ClientModels.UnlinkOpenIdConnectRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UnlinkPSNAccountRequest))
          if (_instance.OnUnlinkPSNAccountRequestEvent != null) {
            _instance.OnUnlinkPSNAccountRequestEvent((ClientModels.UnlinkPSNAccountRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UnlinkSteamAccountRequest))
          if (_instance.OnUnlinkSteamAccountRequestEvent != null) {
            _instance.OnUnlinkSteamAccountRequestEvent((ClientModels.UnlinkSteamAccountRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UnlinkTwitchAccountRequest))
          if (_instance.OnUnlinkTwitchRequestEvent != null) {
            _instance.OnUnlinkTwitchRequestEvent((ClientModels.UnlinkTwitchAccountRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UnlinkWindowsHelloAccountRequest))
          if (_instance.OnUnlinkWindowsHelloRequestEvent != null) {
            _instance.OnUnlinkWindowsHelloRequestEvent((ClientModels.UnlinkWindowsHelloAccountRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UnlinkXboxAccountRequest))
          if (_instance.OnUnlinkXboxAccountRequestEvent != null) {
            _instance.OnUnlinkXboxAccountRequestEvent((ClientModels.UnlinkXboxAccountRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UnlockContainerInstanceRequest))
          if (_instance.OnUnlockContainerInstanceRequestEvent != null) {
            _instance.OnUnlockContainerInstanceRequestEvent((ClientModels.UnlockContainerInstanceRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UnlockContainerItemRequest))
          if (_instance.OnUnlockContainerItemRequestEvent != null) {
            _instance.OnUnlockContainerItemRequestEvent((ClientModels.UnlockContainerItemRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UpdateAvatarUrlRequest))
          if (_instance.OnUpdateAvatarUrlRequestEvent != null) {
            _instance.OnUpdateAvatarUrlRequestEvent((ClientModels.UpdateAvatarUrlRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UpdateCharacterDataRequest))
          if (_instance.OnUpdateCharacterDataRequestEvent != null) {
            _instance.OnUpdateCharacterDataRequestEvent((ClientModels.UpdateCharacterDataRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UpdateCharacterStatisticsRequest))
          if (_instance.OnUpdateCharacterStatisticsRequestEvent != null) {
            _instance.OnUpdateCharacterStatisticsRequestEvent(
              (ClientModels.UpdateCharacterStatisticsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UpdatePlayerStatisticsRequest))
          if (_instance.OnUpdatePlayerStatisticsRequestEvent != null) {
            _instance.OnUpdatePlayerStatisticsRequestEvent((ClientModels.UpdatePlayerStatisticsRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UpdateSharedGroupDataRequest))
          if (_instance.OnUpdateSharedGroupDataRequestEvent != null) {
            _instance.OnUpdateSharedGroupDataRequestEvent((ClientModels.UpdateSharedGroupDataRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UpdateUserDataRequest))
          if (_instance.OnUpdateUserDataRequestEvent != null) {
            _instance.OnUpdateUserDataRequestEvent((ClientModels.UpdateUserDataRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UpdateUserDataRequest))
          if (_instance.OnUpdateUserPublisherDataRequestEvent != null) {
            _instance.OnUpdateUserPublisherDataRequestEvent((ClientModels.UpdateUserDataRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.UpdateUserTitleDisplayNameRequest))
          if (_instance.OnUpdateUserTitleDisplayNameRequestEvent != null) {
            _instance.OnUpdateUserTitleDisplayNameRequestEvent(
              (ClientModels.UpdateUserTitleDisplayNameRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.ValidateAmazonReceiptRequest))
          if (_instance.OnValidateAmazonIAPReceiptRequestEvent != null) {
            _instance.OnValidateAmazonIAPReceiptRequestEvent((ClientModels.ValidateAmazonReceiptRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.ValidateGooglePlayPurchaseRequest))
          if (_instance.OnValidateGooglePlayPurchaseRequestEvent != null) {
            _instance.OnValidateGooglePlayPurchaseRequestEvent(
              (ClientModels.ValidateGooglePlayPurchaseRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.ValidateIOSReceiptRequest))
          if (_instance.OnValidateIOSReceiptRequestEvent != null) {
            _instance.OnValidateIOSReceiptRequestEvent((ClientModels.ValidateIOSReceiptRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.ValidateWindowsReceiptRequest))
          if (_instance.OnValidateWindowsStoreReceiptRequestEvent != null) {
            _instance.OnValidateWindowsStoreReceiptRequestEvent((ClientModels.ValidateWindowsReceiptRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.WriteClientCharacterEventRequest))
          if (_instance.OnWriteCharacterEventRequestEvent != null) {
            _instance.OnWriteCharacterEventRequestEvent((ClientModels.WriteClientCharacterEventRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.WriteClientPlayerEventRequest))
          if (_instance.OnWritePlayerEventRequestEvent != null) {
            _instance.OnWritePlayerEventRequestEvent((ClientModels.WriteClientPlayerEventRequest) e.Request);
            return;
          }

        if (type == typeof(ClientModels.WriteTitleEventRequest))
          if (_instance.OnWriteTitleEventRequestEvent != null) {
            _instance.OnWriteTitleEventRequestEvent((ClientModels.WriteTitleEventRequest) e.Request);
            return;
          }
#endif
#if ENABLE_PLAYFABSERVER_API
                if (type == typeof(MatchmakerModels.AuthUserRequest)) { if (_instance.OnMatchmakerAuthUserRequestEvent != null) { _instance.OnMatchmakerAuthUserRequestEvent((MatchmakerModels.AuthUserRequest)e.Request); return; } }
                if (type == typeof(MatchmakerModels.PlayerJoinedRequest)) { if (_instance.OnMatchmakerPlayerJoinedRequestEvent != null) { _instance.OnMatchmakerPlayerJoinedRequestEvent((MatchmakerModels.PlayerJoinedRequest)e.Request); return; } }
                if (type == typeof(MatchmakerModels.PlayerLeftRequest)) { if (_instance.OnMatchmakerPlayerLeftRequestEvent != null) { _instance.OnMatchmakerPlayerLeftRequestEvent((MatchmakerModels.PlayerLeftRequest)e.Request); return; } }
                if (type == typeof(MatchmakerModels.StartGameRequest)) { if (_instance.OnMatchmakerStartGameRequestEvent != null) { _instance.OnMatchmakerStartGameRequestEvent((MatchmakerModels.StartGameRequest)e.Request); return; } }
                if (type == typeof(MatchmakerModels.UserInfoRequest)) { if (_instance.OnMatchmakerUserInfoRequestEvent != null) { _instance.OnMatchmakerUserInfoRequestEvent((MatchmakerModels.UserInfoRequest)e.Request); return; } }
#endif
#if ENABLE_PLAYFABSERVER_API
                if (type == typeof(ServerModels.AddCharacterVirtualCurrencyRequest)) { if (_instance.OnServerAddCharacterVirtualCurrencyRequestEvent != null) { _instance.OnServerAddCharacterVirtualCurrencyRequestEvent((ServerModels.AddCharacterVirtualCurrencyRequest)e.Request); return; } }
                if (type == typeof(ServerModels.AddFriendRequest)) { if (_instance.OnServerAddFriendRequestEvent != null) { _instance.OnServerAddFriendRequestEvent((ServerModels.AddFriendRequest)e.Request); return; } }
                if (type == typeof(ServerModels.AddGenericIDRequest)) { if (_instance.OnServerAddGenericIDRequestEvent != null) { _instance.OnServerAddGenericIDRequestEvent((ServerModels.AddGenericIDRequest)e.Request); return; } }
                if (type == typeof(ServerModels.AddPlayerTagRequest)) { if (_instance.OnServerAddPlayerTagRequestEvent != null) { _instance.OnServerAddPlayerTagRequestEvent((ServerModels.AddPlayerTagRequest)e.Request); return; } }
                if (type == typeof(ServerModels.AddSharedGroupMembersRequest)) { if (_instance.OnServerAddSharedGroupMembersRequestEvent != null) { _instance.OnServerAddSharedGroupMembersRequestEvent((ServerModels.AddSharedGroupMembersRequest)e.Request); return; } }
                if (type == typeof(ServerModels.AddUserVirtualCurrencyRequest)) { if (_instance.OnServerAddUserVirtualCurrencyRequestEvent != null) { _instance.OnServerAddUserVirtualCurrencyRequestEvent((ServerModels.AddUserVirtualCurrencyRequest)e.Request); return; } }
                if (type == typeof(ServerModels.AuthenticateSessionTicketRequest)) { if (_instance.OnServerAuthenticateSessionTicketRequestEvent != null) { _instance.OnServerAuthenticateSessionTicketRequestEvent((ServerModels.AuthenticateSessionTicketRequest)e.Request); return; } }
                if (type == typeof(ServerModels.AwardSteamAchievementRequest)) { if (_instance.OnServerAwardSteamAchievementRequestEvent != null) { _instance.OnServerAwardSteamAchievementRequestEvent((ServerModels.AwardSteamAchievementRequest)e.Request); return; } }
                if (type == typeof(ServerModels.BanUsersRequest)) { if (_instance.OnServerBanUsersRequestEvent != null) { _instance.OnServerBanUsersRequestEvent((ServerModels.BanUsersRequest)e.Request); return; } }
                if (type == typeof(ServerModels.ConsumeItemRequest)) { if (_instance.OnServerConsumeItemRequestEvent != null) { _instance.OnServerConsumeItemRequestEvent((ServerModels.ConsumeItemRequest)e.Request); return; } }
                if (type == typeof(ServerModels.CreateSharedGroupRequest)) { if (_instance.OnServerCreateSharedGroupRequestEvent != null) { _instance.OnServerCreateSharedGroupRequestEvent((ServerModels.CreateSharedGroupRequest)e.Request); return; } }
                if (type == typeof(ServerModels.DeleteCharacterFromUserRequest)) { if (_instance.OnServerDeleteCharacterFromUserRequestEvent != null) { _instance.OnServerDeleteCharacterFromUserRequestEvent((ServerModels.DeleteCharacterFromUserRequest)e.Request); return; } }
                if (type == typeof(ServerModels.DeletePlayerRequest)) { if (_instance.OnServerDeletePlayerRequestEvent != null) { _instance.OnServerDeletePlayerRequestEvent((ServerModels.DeletePlayerRequest)e.Request); return; } }
                if (type == typeof(ServerModels.DeletePushNotificationTemplateRequest)) { if (_instance.OnServerDeletePushNotificationTemplateRequestEvent != null) { _instance.OnServerDeletePushNotificationTemplateRequestEvent((ServerModels.DeletePushNotificationTemplateRequest)e.Request); return; } }
                if (type == typeof(ServerModels.DeleteSharedGroupRequest)) { if (_instance.OnServerDeleteSharedGroupRequestEvent != null) { _instance.OnServerDeleteSharedGroupRequestEvent((ServerModels.DeleteSharedGroupRequest)e.Request); return; } }
                if (type == typeof(ServerModels.DeregisterGameRequest)) { if (_instance.OnServerDeregisterGameRequestEvent != null) { _instance.OnServerDeregisterGameRequestEvent((ServerModels.DeregisterGameRequest)e.Request); return; } }
                if (type == typeof(ServerModels.EvaluateRandomResultTableRequest)) { if (_instance.OnServerEvaluateRandomResultTableRequestEvent != null) { _instance.OnServerEvaluateRandomResultTableRequestEvent((ServerModels.EvaluateRandomResultTableRequest)e.Request); return; } }
                if (type == typeof(ServerModels.ExecuteCloudScriptServerRequest)) { if (_instance.OnServerExecuteCloudScriptRequestEvent != null) { _instance.OnServerExecuteCloudScriptRequestEvent((ServerModels.ExecuteCloudScriptServerRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetAllSegmentsRequest)) { if (_instance.OnServerGetAllSegmentsRequestEvent != null) { _instance.OnServerGetAllSegmentsRequestEvent((ServerModels.GetAllSegmentsRequest)e.Request); return; } }
                if (type == typeof(ServerModels.ListUsersCharactersRequest)) { if (_instance.OnServerGetAllUsersCharactersRequestEvent != null) { _instance.OnServerGetAllUsersCharactersRequestEvent((ServerModels.ListUsersCharactersRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetCatalogItemsRequest)) { if (_instance.OnServerGetCatalogItemsRequestEvent != null) { _instance.OnServerGetCatalogItemsRequestEvent((ServerModels.GetCatalogItemsRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetCharacterDataRequest)) { if (_instance.OnServerGetCharacterDataRequestEvent != null) { _instance.OnServerGetCharacterDataRequestEvent((ServerModels.GetCharacterDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetCharacterDataRequest)) { if (_instance.OnServerGetCharacterInternalDataRequestEvent != null) { _instance.OnServerGetCharacterInternalDataRequestEvent((ServerModels.GetCharacterDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetCharacterInventoryRequest)) { if (_instance.OnServerGetCharacterInventoryRequestEvent != null) { _instance.OnServerGetCharacterInventoryRequestEvent((ServerModels.GetCharacterInventoryRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetCharacterLeaderboardRequest)) { if (_instance.OnServerGetCharacterLeaderboardRequestEvent != null) { _instance.OnServerGetCharacterLeaderboardRequestEvent((ServerModels.GetCharacterLeaderboardRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetCharacterDataRequest)) { if (_instance.OnServerGetCharacterReadOnlyDataRequestEvent != null) { _instance.OnServerGetCharacterReadOnlyDataRequestEvent((ServerModels.GetCharacterDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetCharacterStatisticsRequest)) { if (_instance.OnServerGetCharacterStatisticsRequestEvent != null) { _instance.OnServerGetCharacterStatisticsRequestEvent((ServerModels.GetCharacterStatisticsRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetContentDownloadUrlRequest)) { if (_instance.OnServerGetContentDownloadUrlRequestEvent != null) { _instance.OnServerGetContentDownloadUrlRequestEvent((ServerModels.GetContentDownloadUrlRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetFriendLeaderboardRequest)) { if (_instance.OnServerGetFriendLeaderboardRequestEvent != null) { _instance.OnServerGetFriendLeaderboardRequestEvent((ServerModels.GetFriendLeaderboardRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetFriendsListRequest)) { if (_instance.OnServerGetFriendsListRequestEvent != null) { _instance.OnServerGetFriendsListRequestEvent((ServerModels.GetFriendsListRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetLeaderboardRequest)) { if (_instance.OnServerGetLeaderboardRequestEvent != null) { _instance.OnServerGetLeaderboardRequestEvent((ServerModels.GetLeaderboardRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetLeaderboardAroundCharacterRequest)) { if (_instance.OnServerGetLeaderboardAroundCharacterRequestEvent != null) { _instance.OnServerGetLeaderboardAroundCharacterRequestEvent((ServerModels.GetLeaderboardAroundCharacterRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetLeaderboardAroundUserRequest)) { if (_instance.OnServerGetLeaderboardAroundUserRequestEvent != null) { _instance.OnServerGetLeaderboardAroundUserRequestEvent((ServerModels.GetLeaderboardAroundUserRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetLeaderboardForUsersCharactersRequest)) { if (_instance.OnServerGetLeaderboardForUserCharactersRequestEvent != null) { _instance.OnServerGetLeaderboardForUserCharactersRequestEvent((ServerModels.GetLeaderboardForUsersCharactersRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetPlayerCombinedInfoRequest)) { if (_instance.OnServerGetPlayerCombinedInfoRequestEvent != null) { _instance.OnServerGetPlayerCombinedInfoRequestEvent((ServerModels.GetPlayerCombinedInfoRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetPlayerProfileRequest)) { if (_instance.OnServerGetPlayerProfileRequestEvent != null) { _instance.OnServerGetPlayerProfileRequestEvent((ServerModels.GetPlayerProfileRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetPlayersSegmentsRequest)) { if (_instance.OnServerGetPlayerSegmentsRequestEvent != null) { _instance.OnServerGetPlayerSegmentsRequestEvent((ServerModels.GetPlayersSegmentsRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetPlayersInSegmentRequest)) { if (_instance.OnServerGetPlayersInSegmentRequestEvent != null) { _instance.OnServerGetPlayersInSegmentRequestEvent((ServerModels.GetPlayersInSegmentRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetPlayerStatisticsRequest)) { if (_instance.OnServerGetPlayerStatisticsRequestEvent != null) { _instance.OnServerGetPlayerStatisticsRequestEvent((ServerModels.GetPlayerStatisticsRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetPlayerStatisticVersionsRequest)) { if (_instance.OnServerGetPlayerStatisticVersionsRequestEvent != null) { _instance.OnServerGetPlayerStatisticVersionsRequestEvent((ServerModels.GetPlayerStatisticVersionsRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetPlayerTagsRequest)) { if (_instance.OnServerGetPlayerTagsRequestEvent != null) { _instance.OnServerGetPlayerTagsRequestEvent((ServerModels.GetPlayerTagsRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetPlayFabIDsFromFacebookIDsRequest)) { if (_instance.OnServerGetPlayFabIDsFromFacebookIDsRequestEvent != null) { _instance.OnServerGetPlayFabIDsFromFacebookIDsRequestEvent((ServerModels.GetPlayFabIDsFromFacebookIDsRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetPlayFabIDsFromFacebookInstantGamesIdsRequest)) { if (_instance.OnServerGetPlayFabIDsFromFacebookInstantGamesIdsRequestEvent != null) { _instance.OnServerGetPlayFabIDsFromFacebookInstantGamesIdsRequestEvent((ServerModels.GetPlayFabIDsFromFacebookInstantGamesIdsRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetPlayFabIDsFromGenericIDsRequest)) { if (_instance.OnServerGetPlayFabIDsFromGenericIDsRequestEvent != null) { _instance.OnServerGetPlayFabIDsFromGenericIDsRequestEvent((ServerModels.GetPlayFabIDsFromGenericIDsRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetPlayFabIDsFromNintendoSwitchDeviceIdsRequest)) { if (_instance.OnServerGetPlayFabIDsFromNintendoSwitchDeviceIdsRequestEvent != null) { _instance.OnServerGetPlayFabIDsFromNintendoSwitchDeviceIdsRequestEvent((ServerModels.GetPlayFabIDsFromNintendoSwitchDeviceIdsRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetPlayFabIDsFromPSNAccountIDsRequest)) { if (_instance.OnServerGetPlayFabIDsFromPSNAccountIDsRequestEvent != null) { _instance.OnServerGetPlayFabIDsFromPSNAccountIDsRequestEvent((ServerModels.GetPlayFabIDsFromPSNAccountIDsRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetPlayFabIDsFromSteamIDsRequest)) { if (_instance.OnServerGetPlayFabIDsFromSteamIDsRequestEvent != null) { _instance.OnServerGetPlayFabIDsFromSteamIDsRequestEvent((ServerModels.GetPlayFabIDsFromSteamIDsRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetPlayFabIDsFromXboxLiveIDsRequest)) { if (_instance.OnServerGetPlayFabIDsFromXboxLiveIDsRequestEvent != null) { _instance.OnServerGetPlayFabIDsFromXboxLiveIDsRequestEvent((ServerModels.GetPlayFabIDsFromXboxLiveIDsRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetPublisherDataRequest)) { if (_instance.OnServerGetPublisherDataRequestEvent != null) { _instance.OnServerGetPublisherDataRequestEvent((ServerModels.GetPublisherDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetRandomResultTablesRequest)) { if (_instance.OnServerGetRandomResultTablesRequestEvent != null) { _instance.OnServerGetRandomResultTablesRequestEvent((ServerModels.GetRandomResultTablesRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetServerCustomIDsFromPlayFabIDsRequest)) { if (_instance.OnServerGetServerCustomIDsFromPlayFabIDsRequestEvent != null) { _instance.OnServerGetServerCustomIDsFromPlayFabIDsRequestEvent((ServerModels.GetServerCustomIDsFromPlayFabIDsRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetSharedGroupDataRequest)) { if (_instance.OnServerGetSharedGroupDataRequestEvent != null) { _instance.OnServerGetSharedGroupDataRequestEvent((ServerModels.GetSharedGroupDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetStoreItemsServerRequest)) { if (_instance.OnServerGetStoreItemsRequestEvent != null) { _instance.OnServerGetStoreItemsRequestEvent((ServerModels.GetStoreItemsServerRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetTimeRequest)) { if (_instance.OnServerGetTimeRequestEvent != null) { _instance.OnServerGetTimeRequestEvent((ServerModels.GetTimeRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetTitleDataRequest)) { if (_instance.OnServerGetTitleDataRequestEvent != null) { _instance.OnServerGetTitleDataRequestEvent((ServerModels.GetTitleDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetTitleDataRequest)) { if (_instance.OnServerGetTitleInternalDataRequestEvent != null) { _instance.OnServerGetTitleInternalDataRequestEvent((ServerModels.GetTitleDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetTitleNewsRequest)) { if (_instance.OnServerGetTitleNewsRequestEvent != null) { _instance.OnServerGetTitleNewsRequestEvent((ServerModels.GetTitleNewsRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetUserAccountInfoRequest)) { if (_instance.OnServerGetUserAccountInfoRequestEvent != null) { _instance.OnServerGetUserAccountInfoRequestEvent((ServerModels.GetUserAccountInfoRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetUserBansRequest)) { if (_instance.OnServerGetUserBansRequestEvent != null) { _instance.OnServerGetUserBansRequestEvent((ServerModels.GetUserBansRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetUserDataRequest)) { if (_instance.OnServerGetUserDataRequestEvent != null) { _instance.OnServerGetUserDataRequestEvent((ServerModels.GetUserDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetUserDataRequest)) { if (_instance.OnServerGetUserInternalDataRequestEvent != null) { _instance.OnServerGetUserInternalDataRequestEvent((ServerModels.GetUserDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetUserInventoryRequest)) { if (_instance.OnServerGetUserInventoryRequestEvent != null) { _instance.OnServerGetUserInventoryRequestEvent((ServerModels.GetUserInventoryRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetUserDataRequest)) { if (_instance.OnServerGetUserPublisherDataRequestEvent != null) { _instance.OnServerGetUserPublisherDataRequestEvent((ServerModels.GetUserDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetUserDataRequest)) { if (_instance.OnServerGetUserPublisherInternalDataRequestEvent != null) { _instance.OnServerGetUserPublisherInternalDataRequestEvent((ServerModels.GetUserDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetUserDataRequest)) { if (_instance.OnServerGetUserPublisherReadOnlyDataRequestEvent != null) { _instance.OnServerGetUserPublisherReadOnlyDataRequestEvent((ServerModels.GetUserDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GetUserDataRequest)) { if (_instance.OnServerGetUserReadOnlyDataRequestEvent != null) { _instance.OnServerGetUserReadOnlyDataRequestEvent((ServerModels.GetUserDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GrantCharacterToUserRequest)) { if (_instance.OnServerGrantCharacterToUserRequestEvent != null) { _instance.OnServerGrantCharacterToUserRequestEvent((ServerModels.GrantCharacterToUserRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GrantItemsToCharacterRequest)) { if (_instance.OnServerGrantItemsToCharacterRequestEvent != null) { _instance.OnServerGrantItemsToCharacterRequestEvent((ServerModels.GrantItemsToCharacterRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GrantItemsToUserRequest)) { if (_instance.OnServerGrantItemsToUserRequestEvent != null) { _instance.OnServerGrantItemsToUserRequestEvent((ServerModels.GrantItemsToUserRequest)e.Request); return; } }
                if (type == typeof(ServerModels.GrantItemsToUsersRequest)) { if (_instance.OnServerGrantItemsToUsersRequestEvent != null) { _instance.OnServerGrantItemsToUsersRequestEvent((ServerModels.GrantItemsToUsersRequest)e.Request); return; } }
                if (type == typeof(ServerModels.LinkPSNAccountRequest)) { if (_instance.OnServerLinkPSNAccountRequestEvent != null) { _instance.OnServerLinkPSNAccountRequestEvent((ServerModels.LinkPSNAccountRequest)e.Request); return; } }
                if (type == typeof(ServerModels.LinkServerCustomIdRequest)) { if (_instance.OnServerLinkServerCustomIdRequestEvent != null) { _instance.OnServerLinkServerCustomIdRequestEvent((ServerModels.LinkServerCustomIdRequest)e.Request); return; } }
                if (type == typeof(ServerModels.LinkXboxAccountRequest)) { if (_instance.OnServerLinkXboxAccountRequestEvent != null) { _instance.OnServerLinkXboxAccountRequestEvent((ServerModels.LinkXboxAccountRequest)e.Request); return; } }
                if (type == typeof(ServerModels.LoginWithServerCustomIdRequest)) { if (_instance.OnServerLoginWithServerCustomIdRequestEvent != null) { _instance.OnServerLoginWithServerCustomIdRequestEvent((ServerModels.LoginWithServerCustomIdRequest)e.Request); return; } }
                if (type == typeof(ServerModels.LoginWithXboxRequest)) { if (_instance.OnServerLoginWithXboxRequestEvent != null) { _instance.OnServerLoginWithXboxRequestEvent((ServerModels.LoginWithXboxRequest)e.Request); return; } }
                if (type == typeof(ServerModels.LoginWithXboxIdRequest)) { if (_instance.OnServerLoginWithXboxIdRequestEvent != null) { _instance.OnServerLoginWithXboxIdRequestEvent((ServerModels.LoginWithXboxIdRequest)e.Request); return; } }
                if (type == typeof(ServerModels.ModifyItemUsesRequest)) { if (_instance.OnServerModifyItemUsesRequestEvent != null) { _instance.OnServerModifyItemUsesRequestEvent((ServerModels.ModifyItemUsesRequest)e.Request); return; } }
                if (type == typeof(ServerModels.MoveItemToCharacterFromCharacterRequest)) { if (_instance.OnServerMoveItemToCharacterFromCharacterRequestEvent != null) { _instance.OnServerMoveItemToCharacterFromCharacterRequestEvent((ServerModels.MoveItemToCharacterFromCharacterRequest)e.Request); return; } }
                if (type == typeof(ServerModels.MoveItemToCharacterFromUserRequest)) { if (_instance.OnServerMoveItemToCharacterFromUserRequestEvent != null) { _instance.OnServerMoveItemToCharacterFromUserRequestEvent((ServerModels.MoveItemToCharacterFromUserRequest)e.Request); return; } }
                if (type == typeof(ServerModels.MoveItemToUserFromCharacterRequest)) { if (_instance.OnServerMoveItemToUserFromCharacterRequestEvent != null) { _instance.OnServerMoveItemToUserFromCharacterRequestEvent((ServerModels.MoveItemToUserFromCharacterRequest)e.Request); return; } }
                if (type == typeof(ServerModels.NotifyMatchmakerPlayerLeftRequest)) { if (_instance.OnServerNotifyMatchmakerPlayerLeftRequestEvent != null) { _instance.OnServerNotifyMatchmakerPlayerLeftRequestEvent((ServerModels.NotifyMatchmakerPlayerLeftRequest)e.Request); return; } }
                if (type == typeof(ServerModels.RedeemCouponRequest)) { if (_instance.OnServerRedeemCouponRequestEvent != null) { _instance.OnServerRedeemCouponRequestEvent((ServerModels.RedeemCouponRequest)e.Request); return; } }
                if (type == typeof(ServerModels.RedeemMatchmakerTicketRequest)) { if (_instance.OnServerRedeemMatchmakerTicketRequestEvent != null) { _instance.OnServerRedeemMatchmakerTicketRequestEvent((ServerModels.RedeemMatchmakerTicketRequest)e.Request); return; } }
                if (type == typeof(ServerModels.RefreshGameServerInstanceHeartbeatRequest)) { if (_instance.OnServerRefreshGameServerInstanceHeartbeatRequestEvent != null) { _instance.OnServerRefreshGameServerInstanceHeartbeatRequestEvent((ServerModels.RefreshGameServerInstanceHeartbeatRequest)e.Request); return; } }
                if (type == typeof(ServerModels.RegisterGameRequest)) { if (_instance.OnServerRegisterGameRequestEvent != null) { _instance.OnServerRegisterGameRequestEvent((ServerModels.RegisterGameRequest)e.Request); return; } }
                if (type == typeof(ServerModels.RemoveFriendRequest)) { if (_instance.OnServerRemoveFriendRequestEvent != null) { _instance.OnServerRemoveFriendRequestEvent((ServerModels.RemoveFriendRequest)e.Request); return; } }
                if (type == typeof(ServerModels.RemoveGenericIDRequest)) { if (_instance.OnServerRemoveGenericIDRequestEvent != null) { _instance.OnServerRemoveGenericIDRequestEvent((ServerModels.RemoveGenericIDRequest)e.Request); return; } }
                if (type == typeof(ServerModels.RemovePlayerTagRequest)) { if (_instance.OnServerRemovePlayerTagRequestEvent != null) { _instance.OnServerRemovePlayerTagRequestEvent((ServerModels.RemovePlayerTagRequest)e.Request); return; } }
                if (type == typeof(ServerModels.RemoveSharedGroupMembersRequest)) { if (_instance.OnServerRemoveSharedGroupMembersRequestEvent != null) { _instance.OnServerRemoveSharedGroupMembersRequestEvent((ServerModels.RemoveSharedGroupMembersRequest)e.Request); return; } }
                if (type == typeof(ServerModels.ReportPlayerServerRequest)) { if (_instance.OnServerReportPlayerRequestEvent != null) { _instance.OnServerReportPlayerRequestEvent((ServerModels.ReportPlayerServerRequest)e.Request); return; } }
                if (type == typeof(ServerModels.RevokeAllBansForUserRequest)) { if (_instance.OnServerRevokeAllBansForUserRequestEvent != null) { _instance.OnServerRevokeAllBansForUserRequestEvent((ServerModels.RevokeAllBansForUserRequest)e.Request); return; } }
                if (type == typeof(ServerModels.RevokeBansRequest)) { if (_instance.OnServerRevokeBansRequestEvent != null) { _instance.OnServerRevokeBansRequestEvent((ServerModels.RevokeBansRequest)e.Request); return; } }
                if (type == typeof(ServerModels.RevokeInventoryItemRequest)) { if (_instance.OnServerRevokeInventoryItemRequestEvent != null) { _instance.OnServerRevokeInventoryItemRequestEvent((ServerModels.RevokeInventoryItemRequest)e.Request); return; } }
                if (type == typeof(ServerModels.RevokeInventoryItemsRequest)) { if (_instance.OnServerRevokeInventoryItemsRequestEvent != null) { _instance.OnServerRevokeInventoryItemsRequestEvent((ServerModels.RevokeInventoryItemsRequest)e.Request); return; } }
                if (type == typeof(ServerModels.SavePushNotificationTemplateRequest)) { if (_instance.OnServerSavePushNotificationTemplateRequestEvent != null) { _instance.OnServerSavePushNotificationTemplateRequestEvent((ServerModels.SavePushNotificationTemplateRequest)e.Request); return; } }
                if (type == typeof(ServerModels.SendCustomAccountRecoveryEmailRequest)) { if (_instance.OnServerSendCustomAccountRecoveryEmailRequestEvent != null) { _instance.OnServerSendCustomAccountRecoveryEmailRequestEvent((ServerModels.SendCustomAccountRecoveryEmailRequest)e.Request); return; } }
                if (type == typeof(ServerModels.SendEmailFromTemplateRequest)) { if (_instance.OnServerSendEmailFromTemplateRequestEvent != null) { _instance.OnServerSendEmailFromTemplateRequestEvent((ServerModels.SendEmailFromTemplateRequest)e.Request); return; } }
                if (type == typeof(ServerModels.SendPushNotificationRequest)) { if (_instance.OnServerSendPushNotificationRequestEvent != null) { _instance.OnServerSendPushNotificationRequestEvent((ServerModels.SendPushNotificationRequest)e.Request); return; } }
                if (type == typeof(ServerModels.SendPushNotificationFromTemplateRequest)) { if (_instance.OnServerSendPushNotificationFromTemplateRequestEvent != null) { _instance.OnServerSendPushNotificationFromTemplateRequestEvent((ServerModels.SendPushNotificationFromTemplateRequest)e.Request); return; } }
                if (type == typeof(ServerModels.SetFriendTagsRequest)) { if (_instance.OnServerSetFriendTagsRequestEvent != null) { _instance.OnServerSetFriendTagsRequestEvent((ServerModels.SetFriendTagsRequest)e.Request); return; } }
                if (type == typeof(ServerModels.SetGameServerInstanceDataRequest)) { if (_instance.OnServerSetGameServerInstanceDataRequestEvent != null) { _instance.OnServerSetGameServerInstanceDataRequestEvent((ServerModels.SetGameServerInstanceDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.SetGameServerInstanceStateRequest)) { if (_instance.OnServerSetGameServerInstanceStateRequestEvent != null) { _instance.OnServerSetGameServerInstanceStateRequestEvent((ServerModels.SetGameServerInstanceStateRequest)e.Request); return; } }
                if (type == typeof(ServerModels.SetGameServerInstanceTagsRequest)) { if (_instance.OnServerSetGameServerInstanceTagsRequestEvent != null) { _instance.OnServerSetGameServerInstanceTagsRequestEvent((ServerModels.SetGameServerInstanceTagsRequest)e.Request); return; } }
                if (type == typeof(ServerModels.SetPlayerSecretRequest)) { if (_instance.OnServerSetPlayerSecretRequestEvent != null) { _instance.OnServerSetPlayerSecretRequestEvent((ServerModels.SetPlayerSecretRequest)e.Request); return; } }
                if (type == typeof(ServerModels.SetPublisherDataRequest)) { if (_instance.OnServerSetPublisherDataRequestEvent != null) { _instance.OnServerSetPublisherDataRequestEvent((ServerModels.SetPublisherDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.SetTitleDataRequest)) { if (_instance.OnServerSetTitleDataRequestEvent != null) { _instance.OnServerSetTitleDataRequestEvent((ServerModels.SetTitleDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.SetTitleDataRequest)) { if (_instance.OnServerSetTitleInternalDataRequestEvent != null) { _instance.OnServerSetTitleInternalDataRequestEvent((ServerModels.SetTitleDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.SubtractCharacterVirtualCurrencyRequest)) { if (_instance.OnServerSubtractCharacterVirtualCurrencyRequestEvent != null) { _instance.OnServerSubtractCharacterVirtualCurrencyRequestEvent((ServerModels.SubtractCharacterVirtualCurrencyRequest)e.Request); return; } }
                if (type == typeof(ServerModels.SubtractUserVirtualCurrencyRequest)) { if (_instance.OnServerSubtractUserVirtualCurrencyRequestEvent != null) { _instance.OnServerSubtractUserVirtualCurrencyRequestEvent((ServerModels.SubtractUserVirtualCurrencyRequest)e.Request); return; } }
                if (type == typeof(ServerModels.UnlinkPSNAccountRequest)) { if (_instance.OnServerUnlinkPSNAccountRequestEvent != null) { _instance.OnServerUnlinkPSNAccountRequestEvent((ServerModels.UnlinkPSNAccountRequest)e.Request); return; } }
                if (type == typeof(ServerModels.UnlinkServerCustomIdRequest)) { if (_instance.OnServerUnlinkServerCustomIdRequestEvent != null) { _instance.OnServerUnlinkServerCustomIdRequestEvent((ServerModels.UnlinkServerCustomIdRequest)e.Request); return; } }
                if (type == typeof(ServerModels.UnlinkXboxAccountRequest)) { if (_instance.OnServerUnlinkXboxAccountRequestEvent != null) { _instance.OnServerUnlinkXboxAccountRequestEvent((ServerModels.UnlinkXboxAccountRequest)e.Request); return; } }
                if (type == typeof(ServerModels.UnlockContainerInstanceRequest)) { if (_instance.OnServerUnlockContainerInstanceRequestEvent != null) { _instance.OnServerUnlockContainerInstanceRequestEvent((ServerModels.UnlockContainerInstanceRequest)e.Request); return; } }
                if (type == typeof(ServerModels.UnlockContainerItemRequest)) { if (_instance.OnServerUnlockContainerItemRequestEvent != null) { _instance.OnServerUnlockContainerItemRequestEvent((ServerModels.UnlockContainerItemRequest)e.Request); return; } }
                if (type == typeof(ServerModels.UpdateAvatarUrlRequest)) { if (_instance.OnServerUpdateAvatarUrlRequestEvent != null) { _instance.OnServerUpdateAvatarUrlRequestEvent((ServerModels.UpdateAvatarUrlRequest)e.Request); return; } }
                if (type == typeof(ServerModels.UpdateBansRequest)) { if (_instance.OnServerUpdateBansRequestEvent != null) { _instance.OnServerUpdateBansRequestEvent((ServerModels.UpdateBansRequest)e.Request); return; } }
                if (type == typeof(ServerModels.UpdateCharacterDataRequest)) { if (_instance.OnServerUpdateCharacterDataRequestEvent != null) { _instance.OnServerUpdateCharacterDataRequestEvent((ServerModels.UpdateCharacterDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.UpdateCharacterDataRequest)) { if (_instance.OnServerUpdateCharacterInternalDataRequestEvent != null) { _instance.OnServerUpdateCharacterInternalDataRequestEvent((ServerModels.UpdateCharacterDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.UpdateCharacterDataRequest)) { if (_instance.OnServerUpdateCharacterReadOnlyDataRequestEvent != null) { _instance.OnServerUpdateCharacterReadOnlyDataRequestEvent((ServerModels.UpdateCharacterDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.UpdateCharacterStatisticsRequest)) { if (_instance.OnServerUpdateCharacterStatisticsRequestEvent != null) { _instance.OnServerUpdateCharacterStatisticsRequestEvent((ServerModels.UpdateCharacterStatisticsRequest)e.Request); return; } }
                if (type == typeof(ServerModels.UpdatePlayerStatisticsRequest)) { if (_instance.OnServerUpdatePlayerStatisticsRequestEvent != null) { _instance.OnServerUpdatePlayerStatisticsRequestEvent((ServerModels.UpdatePlayerStatisticsRequest)e.Request); return; } }
                if (type == typeof(ServerModels.UpdateSharedGroupDataRequest)) { if (_instance.OnServerUpdateSharedGroupDataRequestEvent != null) { _instance.OnServerUpdateSharedGroupDataRequestEvent((ServerModels.UpdateSharedGroupDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.UpdateUserDataRequest)) { if (_instance.OnServerUpdateUserDataRequestEvent != null) { _instance.OnServerUpdateUserDataRequestEvent((ServerModels.UpdateUserDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.UpdateUserInternalDataRequest)) { if (_instance.OnServerUpdateUserInternalDataRequestEvent != null) { _instance.OnServerUpdateUserInternalDataRequestEvent((ServerModels.UpdateUserInternalDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.UpdateUserInventoryItemDataRequest)) { if (_instance.OnServerUpdateUserInventoryItemCustomDataRequestEvent != null) { _instance.OnServerUpdateUserInventoryItemCustomDataRequestEvent((ServerModels.UpdateUserInventoryItemDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.UpdateUserDataRequest)) { if (_instance.OnServerUpdateUserPublisherDataRequestEvent != null) { _instance.OnServerUpdateUserPublisherDataRequestEvent((ServerModels.UpdateUserDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.UpdateUserInternalDataRequest)) { if (_instance.OnServerUpdateUserPublisherInternalDataRequestEvent != null) { _instance.OnServerUpdateUserPublisherInternalDataRequestEvent((ServerModels.UpdateUserInternalDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.UpdateUserDataRequest)) { if (_instance.OnServerUpdateUserPublisherReadOnlyDataRequestEvent != null) { _instance.OnServerUpdateUserPublisherReadOnlyDataRequestEvent((ServerModels.UpdateUserDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.UpdateUserDataRequest)) { if (_instance.OnServerUpdateUserReadOnlyDataRequestEvent != null) { _instance.OnServerUpdateUserReadOnlyDataRequestEvent((ServerModels.UpdateUserDataRequest)e.Request); return; } }
                if (type == typeof(ServerModels.WriteServerCharacterEventRequest)) { if (_instance.OnServerWriteCharacterEventRequestEvent != null) { _instance.OnServerWriteCharacterEventRequestEvent((ServerModels.WriteServerCharacterEventRequest)e.Request); return; } }
                if (type == typeof(ServerModels.WriteServerPlayerEventRequest)) { if (_instance.OnServerWritePlayerEventRequestEvent != null) { _instance.OnServerWritePlayerEventRequestEvent((ServerModels.WriteServerPlayerEventRequest)e.Request); return; } }
                if (type == typeof(ServerModels.WriteTitleEventRequest)) { if (_instance.OnServerWriteTitleEventRequestEvent != null) { _instance.OnServerWriteTitleEventRequestEvent((ServerModels.WriteTitleEventRequest)e.Request); return; } }
#endif
#if !DISABLE_PLAYFABENTITY_API
        if (type == typeof(AuthenticationModels.GetEntityTokenRequest))
          if (_instance.OnAuthenticationGetEntityTokenRequestEvent != null) {
            _instance.OnAuthenticationGetEntityTokenRequestEvent(
              (AuthenticationModels.GetEntityTokenRequest) e.Request);
            return;
          }

        if (type == typeof(AuthenticationModels.ValidateEntityTokenRequest))
          if (_instance.OnAuthenticationValidateEntityTokenRequestEvent != null) {
            _instance.OnAuthenticationValidateEntityTokenRequestEvent(
              (AuthenticationModels.ValidateEntityTokenRequest) e.Request);
            return;
          }
#endif
#if !DISABLE_PLAYFABENTITY_API
        if (type == typeof(CloudScriptModels.ExecuteEntityCloudScriptRequest))
          if (_instance.OnCloudScriptExecuteEntityCloudScriptRequestEvent != null) {
            _instance.OnCloudScriptExecuteEntityCloudScriptRequestEvent(
              (CloudScriptModels.ExecuteEntityCloudScriptRequest) e.Request);
            return;
          }

        if (type == typeof(CloudScriptModels.ExecuteFunctionRequest))
          if (_instance.OnCloudScriptExecuteFunctionRequestEvent != null) {
            _instance.OnCloudScriptExecuteFunctionRequestEvent((CloudScriptModels.ExecuteFunctionRequest) e.Request);
            return;
          }

        if (type == typeof(CloudScriptModels.ListFunctionsRequest))
          if (_instance.OnCloudScriptListFunctionsRequestEvent != null) {
            _instance.OnCloudScriptListFunctionsRequestEvent((CloudScriptModels.ListFunctionsRequest) e.Request);
            return;
          }

        if (type == typeof(CloudScriptModels.ListFunctionsRequest))
          if (_instance.OnCloudScriptListHttpFunctionsRequestEvent != null) {
            _instance.OnCloudScriptListHttpFunctionsRequestEvent((CloudScriptModels.ListFunctionsRequest) e.Request);
            return;
          }

        if (type == typeof(CloudScriptModels.ListFunctionsRequest))
          if (_instance.OnCloudScriptListQueuedFunctionsRequestEvent != null) {
            _instance.OnCloudScriptListQueuedFunctionsRequestEvent((CloudScriptModels.ListFunctionsRequest) e.Request);
            return;
          }

        if (type == typeof(CloudScriptModels.PostFunctionResultForEntityTriggeredActionRequest))
          if (_instance.OnCloudScriptPostFunctionResultForEntityTriggeredActionRequestEvent != null) {
            _instance.OnCloudScriptPostFunctionResultForEntityTriggeredActionRequestEvent(
              (CloudScriptModels.PostFunctionResultForEntityTriggeredActionRequest) e.Request);
            return;
          }

        if (type == typeof(CloudScriptModels.PostFunctionResultForFunctionExecutionRequest))
          if (_instance.OnCloudScriptPostFunctionResultForFunctionExecutionRequestEvent != null) {
            _instance.OnCloudScriptPostFunctionResultForFunctionExecutionRequestEvent(
              (CloudScriptModels.PostFunctionResultForFunctionExecutionRequest) e.Request);
            return;
          }

        if (type == typeof(CloudScriptModels.PostFunctionResultForPlayerTriggeredActionRequest))
          if (_instance.OnCloudScriptPostFunctionResultForPlayerTriggeredActionRequestEvent != null) {
            _instance.OnCloudScriptPostFunctionResultForPlayerTriggeredActionRequestEvent(
              (CloudScriptModels.PostFunctionResultForPlayerTriggeredActionRequest) e.Request);
            return;
          }

        if (type == typeof(CloudScriptModels.PostFunctionResultForScheduledTaskRequest))
          if (_instance.OnCloudScriptPostFunctionResultForScheduledTaskRequestEvent != null) {
            _instance.OnCloudScriptPostFunctionResultForScheduledTaskRequestEvent(
              (CloudScriptModels.PostFunctionResultForScheduledTaskRequest) e.Request);
            return;
          }

        if (type == typeof(CloudScriptModels.RegisterHttpFunctionRequest))
          if (_instance.OnCloudScriptRegisterHttpFunctionRequestEvent != null) {
            _instance.OnCloudScriptRegisterHttpFunctionRequestEvent(
              (CloudScriptModels.RegisterHttpFunctionRequest) e.Request);
            return;
          }

        if (type == typeof(CloudScriptModels.RegisterQueuedFunctionRequest))
          if (_instance.OnCloudScriptRegisterQueuedFunctionRequestEvent != null) {
            _instance.OnCloudScriptRegisterQueuedFunctionRequestEvent(
              (CloudScriptModels.RegisterQueuedFunctionRequest) e.Request);
            return;
          }

        if (type == typeof(CloudScriptModels.UnregisterFunctionRequest))
          if (_instance.OnCloudScriptUnregisterFunctionRequestEvent != null) {
            _instance.OnCloudScriptUnregisterFunctionRequestEvent(
              (CloudScriptModels.UnregisterFunctionRequest) e.Request);
            return;
          }
#endif
#if !DISABLE_PLAYFABENTITY_API
        if (type == typeof(DataModels.AbortFileUploadsRequest))
          if (_instance.OnDataAbortFileUploadsRequestEvent != null) {
            _instance.OnDataAbortFileUploadsRequestEvent((DataModels.AbortFileUploadsRequest) e.Request);
            return;
          }

        if (type == typeof(DataModels.DeleteFilesRequest))
          if (_instance.OnDataDeleteFilesRequestEvent != null) {
            _instance.OnDataDeleteFilesRequestEvent((DataModels.DeleteFilesRequest) e.Request);
            return;
          }

        if (type == typeof(DataModels.FinalizeFileUploadsRequest))
          if (_instance.OnDataFinalizeFileUploadsRequestEvent != null) {
            _instance.OnDataFinalizeFileUploadsRequestEvent((DataModels.FinalizeFileUploadsRequest) e.Request);
            return;
          }

        if (type == typeof(DataModels.GetFilesRequest))
          if (_instance.OnDataGetFilesRequestEvent != null) {
            _instance.OnDataGetFilesRequestEvent((DataModels.GetFilesRequest) e.Request);
            return;
          }

        if (type == typeof(DataModels.GetObjectsRequest))
          if (_instance.OnDataGetObjectsRequestEvent != null) {
            _instance.OnDataGetObjectsRequestEvent((DataModels.GetObjectsRequest) e.Request);
            return;
          }

        if (type == typeof(DataModels.InitiateFileUploadsRequest))
          if (_instance.OnDataInitiateFileUploadsRequestEvent != null) {
            _instance.OnDataInitiateFileUploadsRequestEvent((DataModels.InitiateFileUploadsRequest) e.Request);
            return;
          }

        if (type == typeof(DataModels.SetObjectsRequest))
          if (_instance.OnDataSetObjectsRequestEvent != null) {
            _instance.OnDataSetObjectsRequestEvent((DataModels.SetObjectsRequest) e.Request);
            return;
          }
#endif
#if !DISABLE_PLAYFABENTITY_API
        if (type == typeof(EventsModels.WriteEventsRequest))
          if (_instance.OnEventsWriteEventsRequestEvent != null) {
            _instance.OnEventsWriteEventsRequestEvent((EventsModels.WriteEventsRequest) e.Request);
            return;
          }

        if (type == typeof(EventsModels.WriteEventsRequest))
          if (_instance.OnEventsWriteTelemetryEventsRequestEvent != null) {
            _instance.OnEventsWriteTelemetryEventsRequestEvent((EventsModels.WriteEventsRequest) e.Request);
            return;
          }
#endif
#if !DISABLE_PLAYFABENTITY_API
        if (type == typeof(ExperimentationModels.CreateExperimentRequest))
          if (_instance.OnExperimentationCreateExperimentRequestEvent != null) {
            _instance.OnExperimentationCreateExperimentRequestEvent(
              (ExperimentationModels.CreateExperimentRequest) e.Request);
            return;
          }

        if (type == typeof(ExperimentationModels.DeleteExperimentRequest))
          if (_instance.OnExperimentationDeleteExperimentRequestEvent != null) {
            _instance.OnExperimentationDeleteExperimentRequestEvent(
              (ExperimentationModels.DeleteExperimentRequest) e.Request);
            return;
          }

        if (type == typeof(ExperimentationModels.GetExperimentsRequest))
          if (_instance.OnExperimentationGetExperimentsRequestEvent != null) {
            _instance.OnExperimentationGetExperimentsRequestEvent(
              (ExperimentationModels.GetExperimentsRequest) e.Request);
            return;
          }

        if (type == typeof(ExperimentationModels.GetLatestScorecardRequest))
          if (_instance.OnExperimentationGetLatestScorecardRequestEvent != null) {
            _instance.OnExperimentationGetLatestScorecardRequestEvent(
              (ExperimentationModels.GetLatestScorecardRequest) e.Request);
            return;
          }

        if (type == typeof(ExperimentationModels.GetTreatmentAssignmentRequest))
          if (_instance.OnExperimentationGetTreatmentAssignmentRequestEvent != null) {
            _instance.OnExperimentationGetTreatmentAssignmentRequestEvent(
              (ExperimentationModels.GetTreatmentAssignmentRequest) e.Request);
            return;
          }

        if (type == typeof(ExperimentationModels.StartExperimentRequest))
          if (_instance.OnExperimentationStartExperimentRequestEvent != null) {
            _instance.OnExperimentationStartExperimentRequestEvent(
              (ExperimentationModels.StartExperimentRequest) e.Request);
            return;
          }

        if (type == typeof(ExperimentationModels.StopExperimentRequest))
          if (_instance.OnExperimentationStopExperimentRequestEvent != null) {
            _instance.OnExperimentationStopExperimentRequestEvent(
              (ExperimentationModels.StopExperimentRequest) e.Request);
            return;
          }

        if (type == typeof(ExperimentationModels.UpdateExperimentRequest))
          if (_instance.OnExperimentationUpdateExperimentRequestEvent != null) {
            _instance.OnExperimentationUpdateExperimentRequestEvent(
              (ExperimentationModels.UpdateExperimentRequest) e.Request);
            return;
          }
#endif
#if !DISABLE_PLAYFABENTITY_API
        if (type == typeof(InsightsModels.InsightsEmptyRequest))
          if (_instance.OnInsightsGetDetailsRequestEvent != null) {
            _instance.OnInsightsGetDetailsRequestEvent((InsightsModels.InsightsEmptyRequest) e.Request);
            return;
          }

        if (type == typeof(InsightsModels.InsightsEmptyRequest))
          if (_instance.OnInsightsGetLimitsRequestEvent != null) {
            _instance.OnInsightsGetLimitsRequestEvent((InsightsModels.InsightsEmptyRequest) e.Request);
            return;
          }

        if (type == typeof(InsightsModels.InsightsGetOperationStatusRequest))
          if (_instance.OnInsightsGetOperationStatusRequestEvent != null) {
            _instance.OnInsightsGetOperationStatusRequestEvent(
              (InsightsModels.InsightsGetOperationStatusRequest) e.Request);
            return;
          }

        if (type == typeof(InsightsModels.InsightsGetPendingOperationsRequest))
          if (_instance.OnInsightsGetPendingOperationsRequestEvent != null) {
            _instance.OnInsightsGetPendingOperationsRequestEvent(
              (InsightsModels.InsightsGetPendingOperationsRequest) e.Request);
            return;
          }

        if (type == typeof(InsightsModels.InsightsSetPerformanceRequest))
          if (_instance.OnInsightsSetPerformanceRequestEvent != null) {
            _instance.OnInsightsSetPerformanceRequestEvent((InsightsModels.InsightsSetPerformanceRequest) e.Request);
            return;
          }

        if (type == typeof(InsightsModels.InsightsSetStorageRetentionRequest))
          if (_instance.OnInsightsSetStorageRetentionRequestEvent != null) {
            _instance.OnInsightsSetStorageRetentionRequestEvent(
              (InsightsModels.InsightsSetStorageRetentionRequest) e.Request);
            return;
          }
#endif
#if !DISABLE_PLAYFABENTITY_API
        if (type == typeof(GroupsModels.AcceptGroupApplicationRequest))
          if (_instance.OnGroupsAcceptGroupApplicationRequestEvent != null) {
            _instance.OnGroupsAcceptGroupApplicationRequestEvent(
              (GroupsModels.AcceptGroupApplicationRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.AcceptGroupInvitationRequest))
          if (_instance.OnGroupsAcceptGroupInvitationRequestEvent != null) {
            _instance.OnGroupsAcceptGroupInvitationRequestEvent((GroupsModels.AcceptGroupInvitationRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.AddMembersRequest))
          if (_instance.OnGroupsAddMembersRequestEvent != null) {
            _instance.OnGroupsAddMembersRequestEvent((GroupsModels.AddMembersRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.ApplyToGroupRequest))
          if (_instance.OnGroupsApplyToGroupRequestEvent != null) {
            _instance.OnGroupsApplyToGroupRequestEvent((GroupsModels.ApplyToGroupRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.BlockEntityRequest))
          if (_instance.OnGroupsBlockEntityRequestEvent != null) {
            _instance.OnGroupsBlockEntityRequestEvent((GroupsModels.BlockEntityRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.ChangeMemberRoleRequest))
          if (_instance.OnGroupsChangeMemberRoleRequestEvent != null) {
            _instance.OnGroupsChangeMemberRoleRequestEvent((GroupsModels.ChangeMemberRoleRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.CreateGroupRequest))
          if (_instance.OnGroupsCreateGroupRequestEvent != null) {
            _instance.OnGroupsCreateGroupRequestEvent((GroupsModels.CreateGroupRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.CreateGroupRoleRequest))
          if (_instance.OnGroupsCreateRoleRequestEvent != null) {
            _instance.OnGroupsCreateRoleRequestEvent((GroupsModels.CreateGroupRoleRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.DeleteGroupRequest))
          if (_instance.OnGroupsDeleteGroupRequestEvent != null) {
            _instance.OnGroupsDeleteGroupRequestEvent((GroupsModels.DeleteGroupRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.DeleteRoleRequest))
          if (_instance.OnGroupsDeleteRoleRequestEvent != null) {
            _instance.OnGroupsDeleteRoleRequestEvent((GroupsModels.DeleteRoleRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.GetGroupRequest))
          if (_instance.OnGroupsGetGroupRequestEvent != null) {
            _instance.OnGroupsGetGroupRequestEvent((GroupsModels.GetGroupRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.InviteToGroupRequest))
          if (_instance.OnGroupsInviteToGroupRequestEvent != null) {
            _instance.OnGroupsInviteToGroupRequestEvent((GroupsModels.InviteToGroupRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.IsMemberRequest))
          if (_instance.OnGroupsIsMemberRequestEvent != null) {
            _instance.OnGroupsIsMemberRequestEvent((GroupsModels.IsMemberRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.ListGroupApplicationsRequest))
          if (_instance.OnGroupsListGroupApplicationsRequestEvent != null) {
            _instance.OnGroupsListGroupApplicationsRequestEvent((GroupsModels.ListGroupApplicationsRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.ListGroupBlocksRequest))
          if (_instance.OnGroupsListGroupBlocksRequestEvent != null) {
            _instance.OnGroupsListGroupBlocksRequestEvent((GroupsModels.ListGroupBlocksRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.ListGroupInvitationsRequest))
          if (_instance.OnGroupsListGroupInvitationsRequestEvent != null) {
            _instance.OnGroupsListGroupInvitationsRequestEvent((GroupsModels.ListGroupInvitationsRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.ListGroupMembersRequest))
          if (_instance.OnGroupsListGroupMembersRequestEvent != null) {
            _instance.OnGroupsListGroupMembersRequestEvent((GroupsModels.ListGroupMembersRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.ListMembershipRequest))
          if (_instance.OnGroupsListMembershipRequestEvent != null) {
            _instance.OnGroupsListMembershipRequestEvent((GroupsModels.ListMembershipRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.ListMembershipOpportunitiesRequest))
          if (_instance.OnGroupsListMembershipOpportunitiesRequestEvent != null) {
            _instance.OnGroupsListMembershipOpportunitiesRequestEvent(
              (GroupsModels.ListMembershipOpportunitiesRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.RemoveGroupApplicationRequest))
          if (_instance.OnGroupsRemoveGroupApplicationRequestEvent != null) {
            _instance.OnGroupsRemoveGroupApplicationRequestEvent(
              (GroupsModels.RemoveGroupApplicationRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.RemoveGroupInvitationRequest))
          if (_instance.OnGroupsRemoveGroupInvitationRequestEvent != null) {
            _instance.OnGroupsRemoveGroupInvitationRequestEvent((GroupsModels.RemoveGroupInvitationRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.RemoveMembersRequest))
          if (_instance.OnGroupsRemoveMembersRequestEvent != null) {
            _instance.OnGroupsRemoveMembersRequestEvent((GroupsModels.RemoveMembersRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.UnblockEntityRequest))
          if (_instance.OnGroupsUnblockEntityRequestEvent != null) {
            _instance.OnGroupsUnblockEntityRequestEvent((GroupsModels.UnblockEntityRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.UpdateGroupRequest))
          if (_instance.OnGroupsUpdateGroupRequestEvent != null) {
            _instance.OnGroupsUpdateGroupRequestEvent((GroupsModels.UpdateGroupRequest) e.Request);
            return;
          }

        if (type == typeof(GroupsModels.UpdateGroupRoleRequest))
          if (_instance.OnGroupsUpdateRoleRequestEvent != null) {
            _instance.OnGroupsUpdateRoleRequestEvent((GroupsModels.UpdateGroupRoleRequest) e.Request);
            return;
          }
#endif
#if !DISABLE_PLAYFABENTITY_API
        if (type == typeof(LocalizationModels.GetLanguageListRequest))
          if (_instance.OnLocalizationGetLanguageListRequestEvent != null) {
            _instance.OnLocalizationGetLanguageListRequestEvent((LocalizationModels.GetLanguageListRequest) e.Request);
            return;
          }
#endif
#if !DISABLE_PLAYFABENTITY_API
        if (type == typeof(MultiplayerModels.CancelAllMatchmakingTicketsForPlayerRequest))
          if (_instance.OnMultiplayerCancelAllMatchmakingTicketsForPlayerRequestEvent != null) {
            _instance.OnMultiplayerCancelAllMatchmakingTicketsForPlayerRequestEvent(
              (MultiplayerModels.CancelAllMatchmakingTicketsForPlayerRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.CancelAllServerBackfillTicketsForPlayerRequest))
          if (_instance.OnMultiplayerCancelAllServerBackfillTicketsForPlayerRequestEvent != null) {
            _instance.OnMultiplayerCancelAllServerBackfillTicketsForPlayerRequestEvent(
              (MultiplayerModels.CancelAllServerBackfillTicketsForPlayerRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.CancelMatchmakingTicketRequest))
          if (_instance.OnMultiplayerCancelMatchmakingTicketRequestEvent != null) {
            _instance.OnMultiplayerCancelMatchmakingTicketRequestEvent(
              (MultiplayerModels.CancelMatchmakingTicketRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.CancelServerBackfillTicketRequest))
          if (_instance.OnMultiplayerCancelServerBackfillTicketRequestEvent != null) {
            _instance.OnMultiplayerCancelServerBackfillTicketRequestEvent(
              (MultiplayerModels.CancelServerBackfillTicketRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.CreateBuildAliasRequest))
          if (_instance.OnMultiplayerCreateBuildAliasRequestEvent != null) {
            _instance.OnMultiplayerCreateBuildAliasRequestEvent((MultiplayerModels.CreateBuildAliasRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.CreateBuildWithCustomContainerRequest))
          if (_instance.OnMultiplayerCreateBuildWithCustomContainerRequestEvent != null) {
            _instance.OnMultiplayerCreateBuildWithCustomContainerRequestEvent(
              (MultiplayerModels.CreateBuildWithCustomContainerRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.CreateBuildWithManagedContainerRequest))
          if (_instance.OnMultiplayerCreateBuildWithManagedContainerRequestEvent != null) {
            _instance.OnMultiplayerCreateBuildWithManagedContainerRequestEvent(
              (MultiplayerModels.CreateBuildWithManagedContainerRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.CreateMatchmakingTicketRequest))
          if (_instance.OnMultiplayerCreateMatchmakingTicketRequestEvent != null) {
            _instance.OnMultiplayerCreateMatchmakingTicketRequestEvent(
              (MultiplayerModels.CreateMatchmakingTicketRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.CreateRemoteUserRequest))
          if (_instance.OnMultiplayerCreateRemoteUserRequestEvent != null) {
            _instance.OnMultiplayerCreateRemoteUserRequestEvent((MultiplayerModels.CreateRemoteUserRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.CreateServerBackfillTicketRequest))
          if (_instance.OnMultiplayerCreateServerBackfillTicketRequestEvent != null) {
            _instance.OnMultiplayerCreateServerBackfillTicketRequestEvent(
              (MultiplayerModels.CreateServerBackfillTicketRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.CreateServerMatchmakingTicketRequest))
          if (_instance.OnMultiplayerCreateServerMatchmakingTicketRequestEvent != null) {
            _instance.OnMultiplayerCreateServerMatchmakingTicketRequestEvent(
              (MultiplayerModels.CreateServerMatchmakingTicketRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.DeleteAssetRequest))
          if (_instance.OnMultiplayerDeleteAssetRequestEvent != null) {
            _instance.OnMultiplayerDeleteAssetRequestEvent((MultiplayerModels.DeleteAssetRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.DeleteBuildRequest))
          if (_instance.OnMultiplayerDeleteBuildRequestEvent != null) {
            _instance.OnMultiplayerDeleteBuildRequestEvent((MultiplayerModels.DeleteBuildRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.DeleteBuildAliasRequest))
          if (_instance.OnMultiplayerDeleteBuildAliasRequestEvent != null) {
            _instance.OnMultiplayerDeleteBuildAliasRequestEvent((MultiplayerModels.DeleteBuildAliasRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.DeleteBuildRegionRequest))
          if (_instance.OnMultiplayerDeleteBuildRegionRequestEvent != null) {
            _instance.OnMultiplayerDeleteBuildRegionRequestEvent(
              (MultiplayerModels.DeleteBuildRegionRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.DeleteCertificateRequest))
          if (_instance.OnMultiplayerDeleteCertificateRequestEvent != null) {
            _instance.OnMultiplayerDeleteCertificateRequestEvent(
              (MultiplayerModels.DeleteCertificateRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.DeleteContainerImageRequest))
          if (_instance.OnMultiplayerDeleteContainerImageRepositoryRequestEvent != null) {
            _instance.OnMultiplayerDeleteContainerImageRepositoryRequestEvent(
              (MultiplayerModels.DeleteContainerImageRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.DeleteRemoteUserRequest))
          if (_instance.OnMultiplayerDeleteRemoteUserRequestEvent != null) {
            _instance.OnMultiplayerDeleteRemoteUserRequestEvent((MultiplayerModels.DeleteRemoteUserRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.EnableMultiplayerServersForTitleRequest))
          if (_instance.OnMultiplayerEnableMultiplayerServersForTitleRequestEvent != null) {
            _instance.OnMultiplayerEnableMultiplayerServersForTitleRequestEvent(
              (MultiplayerModels.EnableMultiplayerServersForTitleRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.GetAssetUploadUrlRequest))
          if (_instance.OnMultiplayerGetAssetUploadUrlRequestEvent != null) {
            _instance.OnMultiplayerGetAssetUploadUrlRequestEvent(
              (MultiplayerModels.GetAssetUploadUrlRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.GetBuildRequest))
          if (_instance.OnMultiplayerGetBuildRequestEvent != null) {
            _instance.OnMultiplayerGetBuildRequestEvent((MultiplayerModels.GetBuildRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.GetBuildAliasRequest))
          if (_instance.OnMultiplayerGetBuildAliasRequestEvent != null) {
            _instance.OnMultiplayerGetBuildAliasRequestEvent((MultiplayerModels.GetBuildAliasRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.GetContainerRegistryCredentialsRequest))
          if (_instance.OnMultiplayerGetContainerRegistryCredentialsRequestEvent != null) {
            _instance.OnMultiplayerGetContainerRegistryCredentialsRequestEvent(
              (MultiplayerModels.GetContainerRegistryCredentialsRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.GetMatchRequest))
          if (_instance.OnMultiplayerGetMatchRequestEvent != null) {
            _instance.OnMultiplayerGetMatchRequestEvent((MultiplayerModels.GetMatchRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.GetMatchmakingQueueRequest))
          if (_instance.OnMultiplayerGetMatchmakingQueueRequestEvent != null) {
            _instance.OnMultiplayerGetMatchmakingQueueRequestEvent(
              (MultiplayerModels.GetMatchmakingQueueRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.GetMatchmakingTicketRequest))
          if (_instance.OnMultiplayerGetMatchmakingTicketRequestEvent != null) {
            _instance.OnMultiplayerGetMatchmakingTicketRequestEvent(
              (MultiplayerModels.GetMatchmakingTicketRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.GetMultiplayerServerDetailsRequest))
          if (_instance.OnMultiplayerGetMultiplayerServerDetailsRequestEvent != null) {
            _instance.OnMultiplayerGetMultiplayerServerDetailsRequestEvent(
              (MultiplayerModels.GetMultiplayerServerDetailsRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.GetMultiplayerServerLogsRequest))
          if (_instance.OnMultiplayerGetMultiplayerServerLogsRequestEvent != null) {
            _instance.OnMultiplayerGetMultiplayerServerLogsRequestEvent(
              (MultiplayerModels.GetMultiplayerServerLogsRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.GetMultiplayerSessionLogsBySessionIdRequest))
          if (_instance.OnMultiplayerGetMultiplayerSessionLogsBySessionIdRequestEvent != null) {
            _instance.OnMultiplayerGetMultiplayerSessionLogsBySessionIdRequestEvent(
              (MultiplayerModels.GetMultiplayerSessionLogsBySessionIdRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.GetQueueStatisticsRequest))
          if (_instance.OnMultiplayerGetQueueStatisticsRequestEvent != null) {
            _instance.OnMultiplayerGetQueueStatisticsRequestEvent(
              (MultiplayerModels.GetQueueStatisticsRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.GetRemoteLoginEndpointRequest))
          if (_instance.OnMultiplayerGetRemoteLoginEndpointRequestEvent != null) {
            _instance.OnMultiplayerGetRemoteLoginEndpointRequestEvent(
              (MultiplayerModels.GetRemoteLoginEndpointRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.GetServerBackfillTicketRequest))
          if (_instance.OnMultiplayerGetServerBackfillTicketRequestEvent != null) {
            _instance.OnMultiplayerGetServerBackfillTicketRequestEvent(
              (MultiplayerModels.GetServerBackfillTicketRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.GetTitleEnabledForMultiplayerServersStatusRequest))
          if (_instance.OnMultiplayerGetTitleEnabledForMultiplayerServersStatusRequestEvent != null) {
            _instance.OnMultiplayerGetTitleEnabledForMultiplayerServersStatusRequestEvent(
              (MultiplayerModels.GetTitleEnabledForMultiplayerServersStatusRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.GetTitleMultiplayerServersQuotasRequest))
          if (_instance.OnMultiplayerGetTitleMultiplayerServersQuotasRequestEvent != null) {
            _instance.OnMultiplayerGetTitleMultiplayerServersQuotasRequestEvent(
              (MultiplayerModels.GetTitleMultiplayerServersQuotasRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.JoinMatchmakingTicketRequest))
          if (_instance.OnMultiplayerJoinMatchmakingTicketRequestEvent != null) {
            _instance.OnMultiplayerJoinMatchmakingTicketRequestEvent(
              (MultiplayerModels.JoinMatchmakingTicketRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.ListMultiplayerServersRequest))
          if (_instance.OnMultiplayerListArchivedMultiplayerServersRequestEvent != null) {
            _instance.OnMultiplayerListArchivedMultiplayerServersRequestEvent(
              (MultiplayerModels.ListMultiplayerServersRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.ListAssetSummariesRequest))
          if (_instance.OnMultiplayerListAssetSummariesRequestEvent != null) {
            _instance.OnMultiplayerListAssetSummariesRequestEvent(
              (MultiplayerModels.ListAssetSummariesRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.MultiplayerEmptyRequest))
          if (_instance.OnMultiplayerListBuildAliasesRequestEvent != null) {
            _instance.OnMultiplayerListBuildAliasesRequestEvent((MultiplayerModels.MultiplayerEmptyRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.ListBuildSummariesRequest))
          if (_instance.OnMultiplayerListBuildSummariesRequestEvent != null) {
            _instance.OnMultiplayerListBuildSummariesRequestEvent(
              (MultiplayerModels.ListBuildSummariesRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.ListCertificateSummariesRequest))
          if (_instance.OnMultiplayerListCertificateSummariesRequestEvent != null) {
            _instance.OnMultiplayerListCertificateSummariesRequestEvent(
              (MultiplayerModels.ListCertificateSummariesRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.ListContainerImagesRequest))
          if (_instance.OnMultiplayerListContainerImagesRequestEvent != null) {
            _instance.OnMultiplayerListContainerImagesRequestEvent(
              (MultiplayerModels.ListContainerImagesRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.ListContainerImageTagsRequest))
          if (_instance.OnMultiplayerListContainerImageTagsRequestEvent != null) {
            _instance.OnMultiplayerListContainerImageTagsRequestEvent(
              (MultiplayerModels.ListContainerImageTagsRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.ListMatchmakingQueuesRequest))
          if (_instance.OnMultiplayerListMatchmakingQueuesRequestEvent != null) {
            _instance.OnMultiplayerListMatchmakingQueuesRequestEvent(
              (MultiplayerModels.ListMatchmakingQueuesRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.ListMatchmakingTicketsForPlayerRequest))
          if (_instance.OnMultiplayerListMatchmakingTicketsForPlayerRequestEvent != null) {
            _instance.OnMultiplayerListMatchmakingTicketsForPlayerRequestEvent(
              (MultiplayerModels.ListMatchmakingTicketsForPlayerRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.ListMultiplayerServersRequest))
          if (_instance.OnMultiplayerListMultiplayerServersRequestEvent != null) {
            _instance.OnMultiplayerListMultiplayerServersRequestEvent(
              (MultiplayerModels.ListMultiplayerServersRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.ListPartyQosServersRequest))
          if (_instance.OnMultiplayerListPartyQosServersRequestEvent != null) {
            _instance.OnMultiplayerListPartyQosServersRequestEvent(
              (MultiplayerModels.ListPartyQosServersRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.ListQosServersRequest))
          if (_instance.OnMultiplayerListQosServersRequestEvent != null) {
            _instance.OnMultiplayerListQosServersRequestEvent((MultiplayerModels.ListQosServersRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.ListQosServersForTitleRequest))
          if (_instance.OnMultiplayerListQosServersForTitleRequestEvent != null) {
            _instance.OnMultiplayerListQosServersForTitleRequestEvent(
              (MultiplayerModels.ListQosServersForTitleRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.ListServerBackfillTicketsForPlayerRequest))
          if (_instance.OnMultiplayerListServerBackfillTicketsForPlayerRequestEvent != null) {
            _instance.OnMultiplayerListServerBackfillTicketsForPlayerRequestEvent(
              (MultiplayerModels.ListServerBackfillTicketsForPlayerRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.ListVirtualMachineSummariesRequest))
          if (_instance.OnMultiplayerListVirtualMachineSummariesRequestEvent != null) {
            _instance.OnMultiplayerListVirtualMachineSummariesRequestEvent(
              (MultiplayerModels.ListVirtualMachineSummariesRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.RemoveMatchmakingQueueRequest))
          if (_instance.OnMultiplayerRemoveMatchmakingQueueRequestEvent != null) {
            _instance.OnMultiplayerRemoveMatchmakingQueueRequestEvent(
              (MultiplayerModels.RemoveMatchmakingQueueRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.RequestMultiplayerServerRequest))
          if (_instance.OnMultiplayerRequestMultiplayerServerRequestEvent != null) {
            _instance.OnMultiplayerRequestMultiplayerServerRequestEvent(
              (MultiplayerModels.RequestMultiplayerServerRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.RolloverContainerRegistryCredentialsRequest))
          if (_instance.OnMultiplayerRolloverContainerRegistryCredentialsRequestEvent != null) {
            _instance.OnMultiplayerRolloverContainerRegistryCredentialsRequestEvent(
              (MultiplayerModels.RolloverContainerRegistryCredentialsRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.SetMatchmakingQueueRequest))
          if (_instance.OnMultiplayerSetMatchmakingQueueRequestEvent != null) {
            _instance.OnMultiplayerSetMatchmakingQueueRequestEvent(
              (MultiplayerModels.SetMatchmakingQueueRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.ShutdownMultiplayerServerRequest))
          if (_instance.OnMultiplayerShutdownMultiplayerServerRequestEvent != null) {
            _instance.OnMultiplayerShutdownMultiplayerServerRequestEvent(
              (MultiplayerModels.ShutdownMultiplayerServerRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.UntagContainerImageRequest))
          if (_instance.OnMultiplayerUntagContainerImageRequestEvent != null) {
            _instance.OnMultiplayerUntagContainerImageRequestEvent(
              (MultiplayerModels.UntagContainerImageRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.UpdateBuildAliasRequest))
          if (_instance.OnMultiplayerUpdateBuildAliasRequestEvent != null) {
            _instance.OnMultiplayerUpdateBuildAliasRequestEvent((MultiplayerModels.UpdateBuildAliasRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.UpdateBuildRegionRequest))
          if (_instance.OnMultiplayerUpdateBuildRegionRequestEvent != null) {
            _instance.OnMultiplayerUpdateBuildRegionRequestEvent(
              (MultiplayerModels.UpdateBuildRegionRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.UpdateBuildRegionsRequest))
          if (_instance.OnMultiplayerUpdateBuildRegionsRequestEvent != null) {
            _instance.OnMultiplayerUpdateBuildRegionsRequestEvent(
              (MultiplayerModels.UpdateBuildRegionsRequest) e.Request);
            return;
          }

        if (type == typeof(MultiplayerModels.UploadCertificateRequest))
          if (_instance.OnMultiplayerUploadCertificateRequestEvent != null) {
            _instance.OnMultiplayerUploadCertificateRequestEvent(
              (MultiplayerModels.UploadCertificateRequest) e.Request);
            return;
          }
#endif
#if !DISABLE_PLAYFABENTITY_API
        if (type == typeof(ProfilesModels.GetGlobalPolicyRequest))
          if (_instance.OnProfilesGetGlobalPolicyRequestEvent != null) {
            _instance.OnProfilesGetGlobalPolicyRequestEvent((ProfilesModels.GetGlobalPolicyRequest) e.Request);
            return;
          }

        if (type == typeof(ProfilesModels.GetEntityProfileRequest))
          if (_instance.OnProfilesGetProfileRequestEvent != null) {
            _instance.OnProfilesGetProfileRequestEvent((ProfilesModels.GetEntityProfileRequest) e.Request);
            return;
          }

        if (type == typeof(ProfilesModels.GetEntityProfilesRequest))
          if (_instance.OnProfilesGetProfilesRequestEvent != null) {
            _instance.OnProfilesGetProfilesRequestEvent((ProfilesModels.GetEntityProfilesRequest) e.Request);
            return;
          }

        if (type == typeof(ProfilesModels.GetTitlePlayersFromMasterPlayerAccountIdsRequest))
          if (_instance.OnProfilesGetTitlePlayersFromMasterPlayerAccountIdsRequestEvent != null) {
            _instance.OnProfilesGetTitlePlayersFromMasterPlayerAccountIdsRequestEvent(
              (ProfilesModels.GetTitlePlayersFromMasterPlayerAccountIdsRequest) e.Request);
            return;
          }

        if (type == typeof(ProfilesModels.SetGlobalPolicyRequest))
          if (_instance.OnProfilesSetGlobalPolicyRequestEvent != null) {
            _instance.OnProfilesSetGlobalPolicyRequestEvent((ProfilesModels.SetGlobalPolicyRequest) e.Request);
            return;
          }

        if (type == typeof(ProfilesModels.SetProfileLanguageRequest))
          if (_instance.OnProfilesSetProfileLanguageRequestEvent != null) {
            _instance.OnProfilesSetProfileLanguageRequestEvent((ProfilesModels.SetProfileLanguageRequest) e.Request);
            return;
          }

        if (type == typeof(ProfilesModels.SetEntityProfilePolicyRequest))
          if (_instance.OnProfilesSetProfilePolicyRequestEvent != null) {
            _instance.OnProfilesSetProfilePolicyRequestEvent((ProfilesModels.SetEntityProfilePolicyRequest) e.Request);
            return;
          }
#endif
      }
      else {
        var type = e.Result.GetType();
#if ENABLE_PLAYFABADMIN_API
                if (type == typeof(AdminModels.EmptyResponse)) { if (_instance.OnAdminAbortTaskInstanceResultEvent != null) { _instance.OnAdminAbortTaskInstanceResultEvent((AdminModels.EmptyResponse)e.Result); return; } }
                if (type == typeof(AdminModels.AddLocalizedNewsResult)) { if (_instance.OnAdminAddLocalizedNewsResultEvent != null) { _instance.OnAdminAddLocalizedNewsResultEvent((AdminModels.AddLocalizedNewsResult)e.Result); return; } }
                if (type == typeof(AdminModels.AddNewsResult)) { if (_instance.OnAdminAddNewsResultEvent != null) { _instance.OnAdminAddNewsResultEvent((AdminModels.AddNewsResult)e.Result); return; } }
                if (type == typeof(AdminModels.AddPlayerTagResult)) { if (_instance.OnAdminAddPlayerTagResultEvent != null) { _instance.OnAdminAddPlayerTagResultEvent((AdminModels.AddPlayerTagResult)e.Result); return; } }
                if (type == typeof(AdminModels.AddServerBuildResult)) { if (_instance.OnAdminAddServerBuildResultEvent != null) { _instance.OnAdminAddServerBuildResultEvent((AdminModels.AddServerBuildResult)e.Result); return; } }
                if (type == typeof(AdminModels.ModifyUserVirtualCurrencyResult)) { if (_instance.OnAdminAddUserVirtualCurrencyResultEvent != null) { _instance.OnAdminAddUserVirtualCurrencyResultEvent((AdminModels.ModifyUserVirtualCurrencyResult)e.Result); return; } }
                if (type == typeof(AdminModels.BlankResult)) { if (_instance.OnAdminAddVirtualCurrencyTypesResultEvent != null) { _instance.OnAdminAddVirtualCurrencyTypesResultEvent((AdminModels.BlankResult)e.Result); return; } }
                if (type == typeof(AdminModels.BanUsersResult)) { if (_instance.OnAdminBanUsersResultEvent != null) { _instance.OnAdminBanUsersResultEvent((AdminModels.BanUsersResult)e.Result); return; } }
                if (type == typeof(AdminModels.CheckLimitedEditionItemAvailabilityResult)) { if (_instance.OnAdminCheckLimitedEditionItemAvailabilityResultEvent != null) { _instance.OnAdminCheckLimitedEditionItemAvailabilityResultEvent((AdminModels.CheckLimitedEditionItemAvailabilityResult)e.Result); return; } }
                if (type == typeof(AdminModels.CreateTaskResult)) { if (_instance.OnAdminCreateActionsOnPlayersInSegmentTaskResultEvent != null) { _instance.OnAdminCreateActionsOnPlayersInSegmentTaskResultEvent((AdminModels.CreateTaskResult)e.Result); return; } }
                if (type == typeof(AdminModels.CreateTaskResult)) { if (_instance.OnAdminCreateCloudScriptTaskResultEvent != null) { _instance.OnAdminCreateCloudScriptTaskResultEvent((AdminModels.CreateTaskResult)e.Result); return; } }
                if (type == typeof(AdminModels.CreateTaskResult)) { if (_instance.OnAdminCreateInsightsScheduledScalingTaskResultEvent != null) { _instance.OnAdminCreateInsightsScheduledScalingTaskResultEvent((AdminModels.CreateTaskResult)e.Result); return; } }
                if (type == typeof(AdminModels.EmptyResponse)) { if (_instance.OnAdminCreateOpenIdConnectionResultEvent != null) { _instance.OnAdminCreateOpenIdConnectionResultEvent((AdminModels.EmptyResponse)e.Result); return; } }
                if (type == typeof(AdminModels.CreatePlayerSharedSecretResult)) { if (_instance.OnAdminCreatePlayerSharedSecretResultEvent != null) { _instance.OnAdminCreatePlayerSharedSecretResultEvent((AdminModels.CreatePlayerSharedSecretResult)e.Result); return; } }
                if (type == typeof(AdminModels.CreatePlayerStatisticDefinitionResult)) { if (_instance.OnAdminCreatePlayerStatisticDefinitionResultEvent != null) { _instance.OnAdminCreatePlayerStatisticDefinitionResultEvent((AdminModels.CreatePlayerStatisticDefinitionResult)e.Result); return; } }
                if (type == typeof(AdminModels.BlankResult)) { if (_instance.OnAdminDeleteContentResultEvent != null) { _instance.OnAdminDeleteContentResultEvent((AdminModels.BlankResult)e.Result); return; } }
                if (type == typeof(AdminModels.DeleteMasterPlayerAccountResult)) { if (_instance.OnAdminDeleteMasterPlayerAccountResultEvent != null) { _instance.OnAdminDeleteMasterPlayerAccountResultEvent((AdminModels.DeleteMasterPlayerAccountResult)e.Result); return; } }
                if (type == typeof(AdminModels.EmptyResponse)) { if (_instance.OnAdminDeleteOpenIdConnectionResultEvent != null) { _instance.OnAdminDeleteOpenIdConnectionResultEvent((AdminModels.EmptyResponse)e.Result); return; } }
                if (type == typeof(AdminModels.DeletePlayerResult)) { if (_instance.OnAdminDeletePlayerResultEvent != null) { _instance.OnAdminDeletePlayerResultEvent((AdminModels.DeletePlayerResult)e.Result); return; } }
                if (type == typeof(AdminModels.DeletePlayerSharedSecretResult)) { if (_instance.OnAdminDeletePlayerSharedSecretResultEvent != null) { _instance.OnAdminDeletePlayerSharedSecretResultEvent((AdminModels.DeletePlayerSharedSecretResult)e.Result); return; } }
                if (type == typeof(AdminModels.DeleteStoreResult)) { if (_instance.OnAdminDeleteStoreResultEvent != null) { _instance.OnAdminDeleteStoreResultEvent((AdminModels.DeleteStoreResult)e.Result); return; } }
                if (type == typeof(AdminModels.EmptyResponse)) { if (_instance.OnAdminDeleteTaskResultEvent != null) { _instance.OnAdminDeleteTaskResultEvent((AdminModels.EmptyResponse)e.Result); return; } }
                if (type == typeof(AdminModels.DeleteTitleResult)) { if (_instance.OnAdminDeleteTitleResultEvent != null) { _instance.OnAdminDeleteTitleResultEvent((AdminModels.DeleteTitleResult)e.Result); return; } }
                if (type == typeof(AdminModels.ExportMasterPlayerDataResult)) { if (_instance.OnAdminExportMasterPlayerDataResultEvent != null) { _instance.OnAdminExportMasterPlayerDataResultEvent((AdminModels.ExportMasterPlayerDataResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetActionsOnPlayersInSegmentTaskInstanceResult)) { if (_instance.OnAdminGetActionsOnPlayersInSegmentTaskInstanceResultEvent != null) { _instance.OnAdminGetActionsOnPlayersInSegmentTaskInstanceResultEvent((AdminModels.GetActionsOnPlayersInSegmentTaskInstanceResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetAllSegmentsResult)) { if (_instance.OnAdminGetAllSegmentsResultEvent != null) { _instance.OnAdminGetAllSegmentsResultEvent((AdminModels.GetAllSegmentsResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetCatalogItemsResult)) { if (_instance.OnAdminGetCatalogItemsResultEvent != null) { _instance.OnAdminGetCatalogItemsResultEvent((AdminModels.GetCatalogItemsResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetCloudScriptRevisionResult)) { if (_instance.OnAdminGetCloudScriptRevisionResultEvent != null) { _instance.OnAdminGetCloudScriptRevisionResultEvent((AdminModels.GetCloudScriptRevisionResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetCloudScriptTaskInstanceResult)) { if (_instance.OnAdminGetCloudScriptTaskInstanceResultEvent != null) { _instance.OnAdminGetCloudScriptTaskInstanceResultEvent((AdminModels.GetCloudScriptTaskInstanceResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetCloudScriptVersionsResult)) { if (_instance.OnAdminGetCloudScriptVersionsResultEvent != null) { _instance.OnAdminGetCloudScriptVersionsResultEvent((AdminModels.GetCloudScriptVersionsResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetContentListResult)) { if (_instance.OnAdminGetContentListResultEvent != null) { _instance.OnAdminGetContentListResultEvent((AdminModels.GetContentListResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetContentUploadUrlResult)) { if (_instance.OnAdminGetContentUploadUrlResultEvent != null) { _instance.OnAdminGetContentUploadUrlResultEvent((AdminModels.GetContentUploadUrlResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetDataReportResult)) { if (_instance.OnAdminGetDataReportResultEvent != null) { _instance.OnAdminGetDataReportResultEvent((AdminModels.GetDataReportResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetMatchmakerGameInfoResult)) { if (_instance.OnAdminGetMatchmakerGameInfoResultEvent != null) { _instance.OnAdminGetMatchmakerGameInfoResultEvent((AdminModels.GetMatchmakerGameInfoResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetMatchmakerGameModesResult)) { if (_instance.OnAdminGetMatchmakerGameModesResultEvent != null) { _instance.OnAdminGetMatchmakerGameModesResultEvent((AdminModels.GetMatchmakerGameModesResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetPlayedTitleListResult)) { if (_instance.OnAdminGetPlayedTitleListResultEvent != null) { _instance.OnAdminGetPlayedTitleListResultEvent((AdminModels.GetPlayedTitleListResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetPlayerIdFromAuthTokenResult)) { if (_instance.OnAdminGetPlayerIdFromAuthTokenResultEvent != null) { _instance.OnAdminGetPlayerIdFromAuthTokenResultEvent((AdminModels.GetPlayerIdFromAuthTokenResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetPlayerProfileResult)) { if (_instance.OnAdminGetPlayerProfileResultEvent != null) { _instance.OnAdminGetPlayerProfileResultEvent((AdminModels.GetPlayerProfileResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetPlayerSegmentsResult)) { if (_instance.OnAdminGetPlayerSegmentsResultEvent != null) { _instance.OnAdminGetPlayerSegmentsResultEvent((AdminModels.GetPlayerSegmentsResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetPlayerSharedSecretsResult)) { if (_instance.OnAdminGetPlayerSharedSecretsResultEvent != null) { _instance.OnAdminGetPlayerSharedSecretsResultEvent((AdminModels.GetPlayerSharedSecretsResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetPlayersInSegmentResult)) { if (_instance.OnAdminGetPlayersInSegmentResultEvent != null) { _instance.OnAdminGetPlayersInSegmentResultEvent((AdminModels.GetPlayersInSegmentResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetPlayerStatisticDefinitionsResult)) { if (_instance.OnAdminGetPlayerStatisticDefinitionsResultEvent != null) { _instance.OnAdminGetPlayerStatisticDefinitionsResultEvent((AdminModels.GetPlayerStatisticDefinitionsResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetPlayerStatisticVersionsResult)) { if (_instance.OnAdminGetPlayerStatisticVersionsResultEvent != null) { _instance.OnAdminGetPlayerStatisticVersionsResultEvent((AdminModels.GetPlayerStatisticVersionsResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetPlayerTagsResult)) { if (_instance.OnAdminGetPlayerTagsResultEvent != null) { _instance.OnAdminGetPlayerTagsResultEvent((AdminModels.GetPlayerTagsResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetPolicyResponse)) { if (_instance.OnAdminGetPolicyResultEvent != null) { _instance.OnAdminGetPolicyResultEvent((AdminModels.GetPolicyResponse)e.Result); return; } }
                if (type == typeof(AdminModels.GetPublisherDataResult)) { if (_instance.OnAdminGetPublisherDataResultEvent != null) { _instance.OnAdminGetPublisherDataResultEvent((AdminModels.GetPublisherDataResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetRandomResultTablesResult)) { if (_instance.OnAdminGetRandomResultTablesResultEvent != null) { _instance.OnAdminGetRandomResultTablesResultEvent((AdminModels.GetRandomResultTablesResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetServerBuildInfoResult)) { if (_instance.OnAdminGetServerBuildInfoResultEvent != null) { _instance.OnAdminGetServerBuildInfoResultEvent((AdminModels.GetServerBuildInfoResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetServerBuildUploadURLResult)) { if (_instance.OnAdminGetServerBuildUploadUrlResultEvent != null) { _instance.OnAdminGetServerBuildUploadUrlResultEvent((AdminModels.GetServerBuildUploadURLResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetStoreItemsResult)) { if (_instance.OnAdminGetStoreItemsResultEvent != null) { _instance.OnAdminGetStoreItemsResultEvent((AdminModels.GetStoreItemsResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetTaskInstancesResult)) { if (_instance.OnAdminGetTaskInstancesResultEvent != null) { _instance.OnAdminGetTaskInstancesResultEvent((AdminModels.GetTaskInstancesResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetTasksResult)) { if (_instance.OnAdminGetTasksResultEvent != null) { _instance.OnAdminGetTasksResultEvent((AdminModels.GetTasksResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetTitleDataResult)) { if (_instance.OnAdminGetTitleDataResultEvent != null) { _instance.OnAdminGetTitleDataResultEvent((AdminModels.GetTitleDataResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetTitleDataResult)) { if (_instance.OnAdminGetTitleInternalDataResultEvent != null) { _instance.OnAdminGetTitleInternalDataResultEvent((AdminModels.GetTitleDataResult)e.Result); return; } }
                if (type == typeof(AdminModels.LookupUserAccountInfoResult)) { if (_instance.OnAdminGetUserAccountInfoResultEvent != null) { _instance.OnAdminGetUserAccountInfoResultEvent((AdminModels.LookupUserAccountInfoResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetUserBansResult)) { if (_instance.OnAdminGetUserBansResultEvent != null) { _instance.OnAdminGetUserBansResultEvent((AdminModels.GetUserBansResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetUserDataResult)) { if (_instance.OnAdminGetUserDataResultEvent != null) { _instance.OnAdminGetUserDataResultEvent((AdminModels.GetUserDataResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetUserDataResult)) { if (_instance.OnAdminGetUserInternalDataResultEvent != null) { _instance.OnAdminGetUserInternalDataResultEvent((AdminModels.GetUserDataResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetUserInventoryResult)) { if (_instance.OnAdminGetUserInventoryResultEvent != null) { _instance.OnAdminGetUserInventoryResultEvent((AdminModels.GetUserInventoryResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetUserDataResult)) { if (_instance.OnAdminGetUserPublisherDataResultEvent != null) { _instance.OnAdminGetUserPublisherDataResultEvent((AdminModels.GetUserDataResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetUserDataResult)) { if (_instance.OnAdminGetUserPublisherInternalDataResultEvent != null) { _instance.OnAdminGetUserPublisherInternalDataResultEvent((AdminModels.GetUserDataResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetUserDataResult)) { if (_instance.OnAdminGetUserPublisherReadOnlyDataResultEvent != null) { _instance.OnAdminGetUserPublisherReadOnlyDataResultEvent((AdminModels.GetUserDataResult)e.Result); return; } }
                if (type == typeof(AdminModels.GetUserDataResult)) { if (_instance.OnAdminGetUserReadOnlyDataResultEvent != null) { _instance.OnAdminGetUserReadOnlyDataResultEvent((AdminModels.GetUserDataResult)e.Result); return; } }
                if (type == typeof(AdminModels.GrantItemsToUsersResult)) { if (_instance.OnAdminGrantItemsToUsersResultEvent != null) { _instance.OnAdminGrantItemsToUsersResultEvent((AdminModels.GrantItemsToUsersResult)e.Result); return; } }
                if (type == typeof(AdminModels.IncrementLimitedEditionItemAvailabilityResult)) { if (_instance.OnAdminIncrementLimitedEditionItemAvailabilityResultEvent != null) { _instance.OnAdminIncrementLimitedEditionItemAvailabilityResultEvent((AdminModels.IncrementLimitedEditionItemAvailabilityResult)e.Result); return; } }
                if (type == typeof(AdminModels.IncrementPlayerStatisticVersionResult)) { if (_instance.OnAdminIncrementPlayerStatisticVersionResultEvent != null) { _instance.OnAdminIncrementPlayerStatisticVersionResultEvent((AdminModels.IncrementPlayerStatisticVersionResult)e.Result); return; } }
                if (type == typeof(AdminModels.ListOpenIdConnectionResponse)) { if (_instance.OnAdminListOpenIdConnectionResultEvent != null) { _instance.OnAdminListOpenIdConnectionResultEvent((AdminModels.ListOpenIdConnectionResponse)e.Result); return; } }
                if (type == typeof(AdminModels.ListBuildsResult)) { if (_instance.OnAdminListServerBuildsResultEvent != null) { _instance.OnAdminListServerBuildsResultEvent((AdminModels.ListBuildsResult)e.Result); return; } }
                if (type == typeof(AdminModels.ListVirtualCurrencyTypesResult)) { if (_instance.OnAdminListVirtualCurrencyTypesResultEvent != null) { _instance.OnAdminListVirtualCurrencyTypesResultEvent((AdminModels.ListVirtualCurrencyTypesResult)e.Result); return; } }
                if (type == typeof(AdminModels.ModifyMatchmakerGameModesResult)) { if (_instance.OnAdminModifyMatchmakerGameModesResultEvent != null) { _instance.OnAdminModifyMatchmakerGameModesResultEvent((AdminModels.ModifyMatchmakerGameModesResult)e.Result); return; } }
                if (type == typeof(AdminModels.ModifyServerBuildResult)) { if (_instance.OnAdminModifyServerBuildResultEvent != null) { _instance.OnAdminModifyServerBuildResultEvent((AdminModels.ModifyServerBuildResult)e.Result); return; } }
                if (type == typeof(AdminModels.RefundPurchaseResponse)) { if (_instance.OnAdminRefundPurchaseResultEvent != null) { _instance.OnAdminRefundPurchaseResultEvent((AdminModels.RefundPurchaseResponse)e.Result); return; } }
                if (type == typeof(AdminModels.RemovePlayerTagResult)) { if (_instance.OnAdminRemovePlayerTagResultEvent != null) { _instance.OnAdminRemovePlayerTagResultEvent((AdminModels.RemovePlayerTagResult)e.Result); return; } }
                if (type == typeof(AdminModels.RemoveServerBuildResult)) { if (_instance.OnAdminRemoveServerBuildResultEvent != null) { _instance.OnAdminRemoveServerBuildResultEvent((AdminModels.RemoveServerBuildResult)e.Result); return; } }
                if (type == typeof(AdminModels.BlankResult)) { if (_instance.OnAdminRemoveVirtualCurrencyTypesResultEvent != null) { _instance.OnAdminRemoveVirtualCurrencyTypesResultEvent((AdminModels.BlankResult)e.Result); return; } }
                if (type == typeof(AdminModels.ResetCharacterStatisticsResult)) { if (_instance.OnAdminResetCharacterStatisticsResultEvent != null) { _instance.OnAdminResetCharacterStatisticsResultEvent((AdminModels.ResetCharacterStatisticsResult)e.Result); return; } }
                if (type == typeof(AdminModels.ResetPasswordResult)) { if (_instance.OnAdminResetPasswordResultEvent != null) { _instance.OnAdminResetPasswordResultEvent((AdminModels.ResetPasswordResult)e.Result); return; } }
                if (type == typeof(AdminModels.ResetUserStatisticsResult)) { if (_instance.OnAdminResetUserStatisticsResultEvent != null) { _instance.OnAdminResetUserStatisticsResultEvent((AdminModels.ResetUserStatisticsResult)e.Result); return; } }
                if (type == typeof(AdminModels.ResolvePurchaseDisputeResponse)) { if (_instance.OnAdminResolvePurchaseDisputeResultEvent != null) { _instance.OnAdminResolvePurchaseDisputeResultEvent((AdminModels.ResolvePurchaseDisputeResponse)e.Result); return; } }
                if (type == typeof(AdminModels.RevokeAllBansForUserResult)) { if (_instance.OnAdminRevokeAllBansForUserResultEvent != null) { _instance.OnAdminRevokeAllBansForUserResultEvent((AdminModels.RevokeAllBansForUserResult)e.Result); return; } }
                if (type == typeof(AdminModels.RevokeBansResult)) { if (_instance.OnAdminRevokeBansResultEvent != null) { _instance.OnAdminRevokeBansResultEvent((AdminModels.RevokeBansResult)e.Result); return; } }
                if (type == typeof(AdminModels.RevokeInventoryResult)) { if (_instance.OnAdminRevokeInventoryItemResultEvent != null) { _instance.OnAdminRevokeInventoryItemResultEvent((AdminModels.RevokeInventoryResult)e.Result); return; } }
                if (type == typeof(AdminModels.RevokeInventoryItemsResult)) { if (_instance.OnAdminRevokeInventoryItemsResultEvent != null) { _instance.OnAdminRevokeInventoryItemsResultEvent((AdminModels.RevokeInventoryItemsResult)e.Result); return; } }
                if (type == typeof(AdminModels.RunTaskResult)) { if (_instance.OnAdminRunTaskResultEvent != null) { _instance.OnAdminRunTaskResultEvent((AdminModels.RunTaskResult)e.Result); return; } }
                if (type == typeof(AdminModels.SendAccountRecoveryEmailResult)) { if (_instance.OnAdminSendAccountRecoveryEmailResultEvent != null) { _instance.OnAdminSendAccountRecoveryEmailResultEvent((AdminModels.SendAccountRecoveryEmailResult)e.Result); return; } }
                if (type == typeof(AdminModels.UpdateCatalogItemsResult)) { if (_instance.OnAdminSetCatalogItemsResultEvent != null) { _instance.OnAdminSetCatalogItemsResultEvent((AdminModels.UpdateCatalogItemsResult)e.Result); return; } }
                if (type == typeof(AdminModels.SetPlayerSecretResult)) { if (_instance.OnAdminSetPlayerSecretResultEvent != null) { _instance.OnAdminSetPlayerSecretResultEvent((AdminModels.SetPlayerSecretResult)e.Result); return; } }
                if (type == typeof(AdminModels.SetPublishedRevisionResult)) { if (_instance.OnAdminSetPublishedRevisionResultEvent != null) { _instance.OnAdminSetPublishedRevisionResultEvent((AdminModels.SetPublishedRevisionResult)e.Result); return; } }
                if (type == typeof(AdminModels.SetPublisherDataResult)) { if (_instance.OnAdminSetPublisherDataResultEvent != null) { _instance.OnAdminSetPublisherDataResultEvent((AdminModels.SetPublisherDataResult)e.Result); return; } }
                if (type == typeof(AdminModels.UpdateStoreItemsResult)) { if (_instance.OnAdminSetStoreItemsResultEvent != null) { _instance.OnAdminSetStoreItemsResultEvent((AdminModels.UpdateStoreItemsResult)e.Result); return; } }
                if (type == typeof(AdminModels.SetTitleDataResult)) { if (_instance.OnAdminSetTitleDataResultEvent != null) { _instance.OnAdminSetTitleDataResultEvent((AdminModels.SetTitleDataResult)e.Result); return; } }
                if (type == typeof(AdminModels.SetTitleDataResult)) { if (_instance.OnAdminSetTitleInternalDataResultEvent != null) { _instance.OnAdminSetTitleInternalDataResultEvent((AdminModels.SetTitleDataResult)e.Result); return; } }
                if (type == typeof(AdminModels.SetupPushNotificationResult)) { if (_instance.OnAdminSetupPushNotificationResultEvent != null) { _instance.OnAdminSetupPushNotificationResultEvent((AdminModels.SetupPushNotificationResult)e.Result); return; } }
                if (type == typeof(AdminModels.ModifyUserVirtualCurrencyResult)) { if (_instance.OnAdminSubtractUserVirtualCurrencyResultEvent != null) { _instance.OnAdminSubtractUserVirtualCurrencyResultEvent((AdminModels.ModifyUserVirtualCurrencyResult)e.Result); return; } }
                if (type == typeof(AdminModels.UpdateBansResult)) { if (_instance.OnAdminUpdateBansResultEvent != null) { _instance.OnAdminUpdateBansResultEvent((AdminModels.UpdateBansResult)e.Result); return; } }
                if (type == typeof(AdminModels.UpdateCatalogItemsResult)) { if (_instance.OnAdminUpdateCatalogItemsResultEvent != null) { _instance.OnAdminUpdateCatalogItemsResultEvent((AdminModels.UpdateCatalogItemsResult)e.Result); return; } }
                if (type == typeof(AdminModels.UpdateCloudScriptResult)) { if (_instance.OnAdminUpdateCloudScriptResultEvent != null) { _instance.OnAdminUpdateCloudScriptResultEvent((AdminModels.UpdateCloudScriptResult)e.Result); return; } }
                if (type == typeof(AdminModels.EmptyResponse)) { if (_instance.OnAdminUpdateOpenIdConnectionResultEvent != null) { _instance.OnAdminUpdateOpenIdConnectionResultEvent((AdminModels.EmptyResponse)e.Result); return; } }
                if (type == typeof(AdminModels.UpdatePlayerSharedSecretResult)) { if (_instance.OnAdminUpdatePlayerSharedSecretResultEvent != null) { _instance.OnAdminUpdatePlayerSharedSecretResultEvent((AdminModels.UpdatePlayerSharedSecretResult)e.Result); return; } }
                if (type == typeof(AdminModels.UpdatePlayerStatisticDefinitionResult)) { if (_instance.OnAdminUpdatePlayerStatisticDefinitionResultEvent != null) { _instance.OnAdminUpdatePlayerStatisticDefinitionResultEvent((AdminModels.UpdatePlayerStatisticDefinitionResult)e.Result); return; } }
                if (type == typeof(AdminModels.UpdatePolicyResponse)) { if (_instance.OnAdminUpdatePolicyResultEvent != null) { _instance.OnAdminUpdatePolicyResultEvent((AdminModels.UpdatePolicyResponse)e.Result); return; } }
                if (type == typeof(AdminModels.UpdateRandomResultTablesResult)) { if (_instance.OnAdminUpdateRandomResultTablesResultEvent != null) { _instance.OnAdminUpdateRandomResultTablesResultEvent((AdminModels.UpdateRandomResultTablesResult)e.Result); return; } }
                if (type == typeof(AdminModels.UpdateStoreItemsResult)) { if (_instance.OnAdminUpdateStoreItemsResultEvent != null) { _instance.OnAdminUpdateStoreItemsResultEvent((AdminModels.UpdateStoreItemsResult)e.Result); return; } }
                if (type == typeof(AdminModels.EmptyResponse)) { if (_instance.OnAdminUpdateTaskResultEvent != null) { _instance.OnAdminUpdateTaskResultEvent((AdminModels.EmptyResponse)e.Result); return; } }
                if (type == typeof(AdminModels.UpdateUserDataResult)) { if (_instance.OnAdminUpdateUserDataResultEvent != null) { _instance.OnAdminUpdateUserDataResultEvent((AdminModels.UpdateUserDataResult)e.Result); return; } }
                if (type == typeof(AdminModels.UpdateUserDataResult)) { if (_instance.OnAdminUpdateUserInternalDataResultEvent != null) { _instance.OnAdminUpdateUserInternalDataResultEvent((AdminModels.UpdateUserDataResult)e.Result); return; } }
                if (type == typeof(AdminModels.UpdateUserDataResult)) { if (_instance.OnAdminUpdateUserPublisherDataResultEvent != null) { _instance.OnAdminUpdateUserPublisherDataResultEvent((AdminModels.UpdateUserDataResult)e.Result); return; } }
                if (type == typeof(AdminModels.UpdateUserDataResult)) { if (_instance.OnAdminUpdateUserPublisherInternalDataResultEvent != null) { _instance.OnAdminUpdateUserPublisherInternalDataResultEvent((AdminModels.UpdateUserDataResult)e.Result); return; } }
                if (type == typeof(AdminModels.UpdateUserDataResult)) { if (_instance.OnAdminUpdateUserPublisherReadOnlyDataResultEvent != null) { _instance.OnAdminUpdateUserPublisherReadOnlyDataResultEvent((AdminModels.UpdateUserDataResult)e.Result); return; } }
                if (type == typeof(AdminModels.UpdateUserDataResult)) { if (_instance.OnAdminUpdateUserReadOnlyDataResultEvent != null) { _instance.OnAdminUpdateUserReadOnlyDataResultEvent((AdminModels.UpdateUserDataResult)e.Result); return; } }
                if (type == typeof(AdminModels.UpdateUserTitleDisplayNameResult)) { if (_instance.OnAdminUpdateUserTitleDisplayNameResultEvent != null) { _instance.OnAdminUpdateUserTitleDisplayNameResultEvent((AdminModels.UpdateUserTitleDisplayNameResult)e.Result); return; } }
#endif
#if !DISABLE_PLAYFABCLIENT_API
        if (type == typeof(ClientModels.LoginResult))
          if (_instance.OnLoginResultEvent != null) {
            _instance.OnLoginResultEvent((ClientModels.LoginResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.AcceptTradeResponse))
          if (_instance.OnAcceptTradeResultEvent != null) {
            _instance.OnAcceptTradeResultEvent((ClientModels.AcceptTradeResponse) e.Result);
            return;
          }

        if (type == typeof(ClientModels.AddFriendResult))
          if (_instance.OnAddFriendResultEvent != null) {
            _instance.OnAddFriendResultEvent((ClientModels.AddFriendResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.AddGenericIDResult))
          if (_instance.OnAddGenericIDResultEvent != null) {
            _instance.OnAddGenericIDResultEvent((ClientModels.AddGenericIDResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.AddOrUpdateContactEmailResult))
          if (_instance.OnAddOrUpdateContactEmailResultEvent != null) {
            _instance.OnAddOrUpdateContactEmailResultEvent((ClientModels.AddOrUpdateContactEmailResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.AddSharedGroupMembersResult))
          if (_instance.OnAddSharedGroupMembersResultEvent != null) {
            _instance.OnAddSharedGroupMembersResultEvent((ClientModels.AddSharedGroupMembersResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.AddUsernamePasswordResult))
          if (_instance.OnAddUsernamePasswordResultEvent != null) {
            _instance.OnAddUsernamePasswordResultEvent((ClientModels.AddUsernamePasswordResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.ModifyUserVirtualCurrencyResult))
          if (_instance.OnAddUserVirtualCurrencyResultEvent != null) {
            _instance.OnAddUserVirtualCurrencyResultEvent((ClientModels.ModifyUserVirtualCurrencyResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.AndroidDevicePushNotificationRegistrationResult))
          if (_instance.OnAndroidDevicePushNotificationRegistrationResultEvent != null) {
            _instance.OnAndroidDevicePushNotificationRegistrationResultEvent(
              (ClientModels.AndroidDevicePushNotificationRegistrationResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.AttributeInstallResult))
          if (_instance.OnAttributeInstallResultEvent != null) {
            _instance.OnAttributeInstallResultEvent((ClientModels.AttributeInstallResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.CancelTradeResponse))
          if (_instance.OnCancelTradeResultEvent != null) {
            _instance.OnCancelTradeResultEvent((ClientModels.CancelTradeResponse) e.Result);
            return;
          }

        if (type == typeof(ClientModels.ConfirmPurchaseResult))
          if (_instance.OnConfirmPurchaseResultEvent != null) {
            _instance.OnConfirmPurchaseResultEvent((ClientModels.ConfirmPurchaseResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.ConsumeItemResult))
          if (_instance.OnConsumeItemResultEvent != null) {
            _instance.OnConsumeItemResultEvent((ClientModels.ConsumeItemResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.ConsumePSNEntitlementsResult))
          if (_instance.OnConsumePSNEntitlementsResultEvent != null) {
            _instance.OnConsumePSNEntitlementsResultEvent((ClientModels.ConsumePSNEntitlementsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.ConsumeXboxEntitlementsResult))
          if (_instance.OnConsumeXboxEntitlementsResultEvent != null) {
            _instance.OnConsumeXboxEntitlementsResultEvent((ClientModels.ConsumeXboxEntitlementsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.CreateSharedGroupResult))
          if (_instance.OnCreateSharedGroupResultEvent != null) {
            _instance.OnCreateSharedGroupResultEvent((ClientModels.CreateSharedGroupResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.ExecuteCloudScriptResult))
          if (_instance.OnExecuteCloudScriptResultEvent != null) {
            _instance.OnExecuteCloudScriptResultEvent((ClientModels.ExecuteCloudScriptResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetAccountInfoResult))
          if (_instance.OnGetAccountInfoResultEvent != null) {
            _instance.OnGetAccountInfoResultEvent((ClientModels.GetAccountInfoResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetAdPlacementsResult))
          if (_instance.OnGetAdPlacementsResultEvent != null) {
            _instance.OnGetAdPlacementsResultEvent((ClientModels.GetAdPlacementsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.ListUsersCharactersResult))
          if (_instance.OnGetAllUsersCharactersResultEvent != null) {
            _instance.OnGetAllUsersCharactersResultEvent((ClientModels.ListUsersCharactersResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetCatalogItemsResult))
          if (_instance.OnGetCatalogItemsResultEvent != null) {
            _instance.OnGetCatalogItemsResultEvent((ClientModels.GetCatalogItemsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetCharacterDataResult))
          if (_instance.OnGetCharacterDataResultEvent != null) {
            _instance.OnGetCharacterDataResultEvent((ClientModels.GetCharacterDataResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetCharacterInventoryResult))
          if (_instance.OnGetCharacterInventoryResultEvent != null) {
            _instance.OnGetCharacterInventoryResultEvent((ClientModels.GetCharacterInventoryResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetCharacterLeaderboardResult))
          if (_instance.OnGetCharacterLeaderboardResultEvent != null) {
            _instance.OnGetCharacterLeaderboardResultEvent((ClientModels.GetCharacterLeaderboardResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetCharacterDataResult))
          if (_instance.OnGetCharacterReadOnlyDataResultEvent != null) {
            _instance.OnGetCharacterReadOnlyDataResultEvent((ClientModels.GetCharacterDataResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetCharacterStatisticsResult))
          if (_instance.OnGetCharacterStatisticsResultEvent != null) {
            _instance.OnGetCharacterStatisticsResultEvent((ClientModels.GetCharacterStatisticsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetContentDownloadUrlResult))
          if (_instance.OnGetContentDownloadUrlResultEvent != null) {
            _instance.OnGetContentDownloadUrlResultEvent((ClientModels.GetContentDownloadUrlResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.CurrentGamesResult))
          if (_instance.OnGetCurrentGamesResultEvent != null) {
            _instance.OnGetCurrentGamesResultEvent((ClientModels.CurrentGamesResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetLeaderboardResult))
          if (_instance.OnGetFriendLeaderboardResultEvent != null) {
            _instance.OnGetFriendLeaderboardResultEvent((ClientModels.GetLeaderboardResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetFriendLeaderboardAroundPlayerResult))
          if (_instance.OnGetFriendLeaderboardAroundPlayerResultEvent != null) {
            _instance.OnGetFriendLeaderboardAroundPlayerResultEvent(
              (ClientModels.GetFriendLeaderboardAroundPlayerResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetFriendsListResult))
          if (_instance.OnGetFriendsListResultEvent != null) {
            _instance.OnGetFriendsListResultEvent((ClientModels.GetFriendsListResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GameServerRegionsResult))
          if (_instance.OnGetGameServerRegionsResultEvent != null) {
            _instance.OnGetGameServerRegionsResultEvent((ClientModels.GameServerRegionsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetLeaderboardResult))
          if (_instance.OnGetLeaderboardResultEvent != null) {
            _instance.OnGetLeaderboardResultEvent((ClientModels.GetLeaderboardResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetLeaderboardAroundCharacterResult))
          if (_instance.OnGetLeaderboardAroundCharacterResultEvent != null) {
            _instance.OnGetLeaderboardAroundCharacterResultEvent(
              (ClientModels.GetLeaderboardAroundCharacterResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetLeaderboardAroundPlayerResult))
          if (_instance.OnGetLeaderboardAroundPlayerResultEvent != null) {
            _instance.OnGetLeaderboardAroundPlayerResultEvent((ClientModels.GetLeaderboardAroundPlayerResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetLeaderboardForUsersCharactersResult))
          if (_instance.OnGetLeaderboardForUserCharactersResultEvent != null) {
            _instance.OnGetLeaderboardForUserCharactersResultEvent(
              (ClientModels.GetLeaderboardForUsersCharactersResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetPaymentTokenResult))
          if (_instance.OnGetPaymentTokenResultEvent != null) {
            _instance.OnGetPaymentTokenResultEvent((ClientModels.GetPaymentTokenResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetPhotonAuthenticationTokenResult))
          if (_instance.OnGetPhotonAuthenticationTokenResultEvent != null) {
            _instance.OnGetPhotonAuthenticationTokenResultEvent(
              (ClientModels.GetPhotonAuthenticationTokenResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetPlayerCombinedInfoResult))
          if (_instance.OnGetPlayerCombinedInfoResultEvent != null) {
            _instance.OnGetPlayerCombinedInfoResultEvent((ClientModels.GetPlayerCombinedInfoResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetPlayerProfileResult))
          if (_instance.OnGetPlayerProfileResultEvent != null) {
            _instance.OnGetPlayerProfileResultEvent((ClientModels.GetPlayerProfileResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetPlayerSegmentsResult))
          if (_instance.OnGetPlayerSegmentsResultEvent != null) {
            _instance.OnGetPlayerSegmentsResultEvent((ClientModels.GetPlayerSegmentsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetPlayerStatisticsResult))
          if (_instance.OnGetPlayerStatisticsResultEvent != null) {
            _instance.OnGetPlayerStatisticsResultEvent((ClientModels.GetPlayerStatisticsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetPlayerStatisticVersionsResult))
          if (_instance.OnGetPlayerStatisticVersionsResultEvent != null) {
            _instance.OnGetPlayerStatisticVersionsResultEvent((ClientModels.GetPlayerStatisticVersionsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetPlayerTagsResult))
          if (_instance.OnGetPlayerTagsResultEvent != null) {
            _instance.OnGetPlayerTagsResultEvent((ClientModels.GetPlayerTagsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetPlayerTradesResponse))
          if (_instance.OnGetPlayerTradesResultEvent != null) {
            _instance.OnGetPlayerTradesResultEvent((ClientModels.GetPlayerTradesResponse) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetPlayFabIDsFromFacebookIDsResult))
          if (_instance.OnGetPlayFabIDsFromFacebookIDsResultEvent != null) {
            _instance.OnGetPlayFabIDsFromFacebookIDsResultEvent(
              (ClientModels.GetPlayFabIDsFromFacebookIDsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetPlayFabIDsFromFacebookInstantGamesIdsResult))
          if (_instance.OnGetPlayFabIDsFromFacebookInstantGamesIdsResultEvent != null) {
            _instance.OnGetPlayFabIDsFromFacebookInstantGamesIdsResultEvent(
              (ClientModels.GetPlayFabIDsFromFacebookInstantGamesIdsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetPlayFabIDsFromGameCenterIDsResult))
          if (_instance.OnGetPlayFabIDsFromGameCenterIDsResultEvent != null) {
            _instance.OnGetPlayFabIDsFromGameCenterIDsResultEvent(
              (ClientModels.GetPlayFabIDsFromGameCenterIDsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetPlayFabIDsFromGenericIDsResult))
          if (_instance.OnGetPlayFabIDsFromGenericIDsResultEvent != null) {
            _instance.OnGetPlayFabIDsFromGenericIDsResultEvent(
              (ClientModels.GetPlayFabIDsFromGenericIDsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetPlayFabIDsFromGoogleIDsResult))
          if (_instance.OnGetPlayFabIDsFromGoogleIDsResultEvent != null) {
            _instance.OnGetPlayFabIDsFromGoogleIDsResultEvent((ClientModels.GetPlayFabIDsFromGoogleIDsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetPlayFabIDsFromKongregateIDsResult))
          if (_instance.OnGetPlayFabIDsFromKongregateIDsResultEvent != null) {
            _instance.OnGetPlayFabIDsFromKongregateIDsResultEvent(
              (ClientModels.GetPlayFabIDsFromKongregateIDsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetPlayFabIDsFromNintendoSwitchDeviceIdsResult))
          if (_instance.OnGetPlayFabIDsFromNintendoSwitchDeviceIdsResultEvent != null) {
            _instance.OnGetPlayFabIDsFromNintendoSwitchDeviceIdsResultEvent(
              (ClientModels.GetPlayFabIDsFromNintendoSwitchDeviceIdsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetPlayFabIDsFromPSNAccountIDsResult))
          if (_instance.OnGetPlayFabIDsFromPSNAccountIDsResultEvent != null) {
            _instance.OnGetPlayFabIDsFromPSNAccountIDsResultEvent(
              (ClientModels.GetPlayFabIDsFromPSNAccountIDsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetPlayFabIDsFromSteamIDsResult))
          if (_instance.OnGetPlayFabIDsFromSteamIDsResultEvent != null) {
            _instance.OnGetPlayFabIDsFromSteamIDsResultEvent((ClientModels.GetPlayFabIDsFromSteamIDsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetPlayFabIDsFromTwitchIDsResult))
          if (_instance.OnGetPlayFabIDsFromTwitchIDsResultEvent != null) {
            _instance.OnGetPlayFabIDsFromTwitchIDsResultEvent((ClientModels.GetPlayFabIDsFromTwitchIDsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetPlayFabIDsFromXboxLiveIDsResult))
          if (_instance.OnGetPlayFabIDsFromXboxLiveIDsResultEvent != null) {
            _instance.OnGetPlayFabIDsFromXboxLiveIDsResultEvent(
              (ClientModels.GetPlayFabIDsFromXboxLiveIDsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetPublisherDataResult))
          if (_instance.OnGetPublisherDataResultEvent != null) {
            _instance.OnGetPublisherDataResultEvent((ClientModels.GetPublisherDataResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetPurchaseResult))
          if (_instance.OnGetPurchaseResultEvent != null) {
            _instance.OnGetPurchaseResultEvent((ClientModels.GetPurchaseResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetSharedGroupDataResult))
          if (_instance.OnGetSharedGroupDataResultEvent != null) {
            _instance.OnGetSharedGroupDataResultEvent((ClientModels.GetSharedGroupDataResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetStoreItemsResult))
          if (_instance.OnGetStoreItemsResultEvent != null) {
            _instance.OnGetStoreItemsResultEvent((ClientModels.GetStoreItemsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetTimeResult))
          if (_instance.OnGetTimeResultEvent != null) {
            _instance.OnGetTimeResultEvent((ClientModels.GetTimeResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetTitleDataResult))
          if (_instance.OnGetTitleDataResultEvent != null) {
            _instance.OnGetTitleDataResultEvent((ClientModels.GetTitleDataResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetTitleNewsResult))
          if (_instance.OnGetTitleNewsResultEvent != null) {
            _instance.OnGetTitleNewsResultEvent((ClientModels.GetTitleNewsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetTitlePublicKeyResult))
          if (_instance.OnGetTitlePublicKeyResultEvent != null) {
            _instance.OnGetTitlePublicKeyResultEvent((ClientModels.GetTitlePublicKeyResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetTradeStatusResponse))
          if (_instance.OnGetTradeStatusResultEvent != null) {
            _instance.OnGetTradeStatusResultEvent((ClientModels.GetTradeStatusResponse) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetUserDataResult))
          if (_instance.OnGetUserDataResultEvent != null) {
            _instance.OnGetUserDataResultEvent((ClientModels.GetUserDataResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetUserInventoryResult))
          if (_instance.OnGetUserInventoryResultEvent != null) {
            _instance.OnGetUserInventoryResultEvent((ClientModels.GetUserInventoryResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetUserDataResult))
          if (_instance.OnGetUserPublisherDataResultEvent != null) {
            _instance.OnGetUserPublisherDataResultEvent((ClientModels.GetUserDataResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetUserDataResult))
          if (_instance.OnGetUserPublisherReadOnlyDataResultEvent != null) {
            _instance.OnGetUserPublisherReadOnlyDataResultEvent((ClientModels.GetUserDataResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetUserDataResult))
          if (_instance.OnGetUserReadOnlyDataResultEvent != null) {
            _instance.OnGetUserReadOnlyDataResultEvent((ClientModels.GetUserDataResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GetWindowsHelloChallengeResponse))
          if (_instance.OnGetWindowsHelloChallengeResultEvent != null) {
            _instance.OnGetWindowsHelloChallengeResultEvent((ClientModels.GetWindowsHelloChallengeResponse) e.Result);
            return;
          }

        if (type == typeof(ClientModels.GrantCharacterToUserResult))
          if (_instance.OnGrantCharacterToUserResultEvent != null) {
            _instance.OnGrantCharacterToUserResultEvent((ClientModels.GrantCharacterToUserResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.LinkAndroidDeviceIDResult))
          if (_instance.OnLinkAndroidDeviceIDResultEvent != null) {
            _instance.OnLinkAndroidDeviceIDResultEvent((ClientModels.LinkAndroidDeviceIDResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.EmptyResult))
          if (_instance.OnLinkAppleResultEvent != null) {
            _instance.OnLinkAppleResultEvent((ClientModels.EmptyResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.LinkCustomIDResult))
          if (_instance.OnLinkCustomIDResultEvent != null) {
            _instance.OnLinkCustomIDResultEvent((ClientModels.LinkCustomIDResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.LinkFacebookAccountResult))
          if (_instance.OnLinkFacebookAccountResultEvent != null) {
            _instance.OnLinkFacebookAccountResultEvent((ClientModels.LinkFacebookAccountResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.LinkFacebookInstantGamesIdResult))
          if (_instance.OnLinkFacebookInstantGamesIdResultEvent != null) {
            _instance.OnLinkFacebookInstantGamesIdResultEvent((ClientModels.LinkFacebookInstantGamesIdResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.LinkGameCenterAccountResult))
          if (_instance.OnLinkGameCenterAccountResultEvent != null) {
            _instance.OnLinkGameCenterAccountResultEvent((ClientModels.LinkGameCenterAccountResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.LinkGoogleAccountResult))
          if (_instance.OnLinkGoogleAccountResultEvent != null) {
            _instance.OnLinkGoogleAccountResultEvent((ClientModels.LinkGoogleAccountResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.LinkIOSDeviceIDResult))
          if (_instance.OnLinkIOSDeviceIDResultEvent != null) {
            _instance.OnLinkIOSDeviceIDResultEvent((ClientModels.LinkIOSDeviceIDResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.LinkKongregateAccountResult))
          if (_instance.OnLinkKongregateResultEvent != null) {
            _instance.OnLinkKongregateResultEvent((ClientModels.LinkKongregateAccountResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.EmptyResult))
          if (_instance.OnLinkNintendoAccountResultEvent != null) {
            _instance.OnLinkNintendoAccountResultEvent((ClientModels.EmptyResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.LinkNintendoSwitchDeviceIdResult))
          if (_instance.OnLinkNintendoSwitchDeviceIdResultEvent != null) {
            _instance.OnLinkNintendoSwitchDeviceIdResultEvent((ClientModels.LinkNintendoSwitchDeviceIdResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.EmptyResult))
          if (_instance.OnLinkOpenIdConnectResultEvent != null) {
            _instance.OnLinkOpenIdConnectResultEvent((ClientModels.EmptyResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.LinkPSNAccountResult))
          if (_instance.OnLinkPSNAccountResultEvent != null) {
            _instance.OnLinkPSNAccountResultEvent((ClientModels.LinkPSNAccountResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.LinkSteamAccountResult))
          if (_instance.OnLinkSteamAccountResultEvent != null) {
            _instance.OnLinkSteamAccountResultEvent((ClientModels.LinkSteamAccountResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.LinkTwitchAccountResult))
          if (_instance.OnLinkTwitchResultEvent != null) {
            _instance.OnLinkTwitchResultEvent((ClientModels.LinkTwitchAccountResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.LinkWindowsHelloAccountResponse))
          if (_instance.OnLinkWindowsHelloResultEvent != null) {
            _instance.OnLinkWindowsHelloResultEvent((ClientModels.LinkWindowsHelloAccountResponse) e.Result);
            return;
          }

        if (type == typeof(ClientModels.LinkXboxAccountResult))
          if (_instance.OnLinkXboxAccountResultEvent != null) {
            _instance.OnLinkXboxAccountResultEvent((ClientModels.LinkXboxAccountResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.MatchmakeResult))
          if (_instance.OnMatchmakeResultEvent != null) {
            _instance.OnMatchmakeResultEvent((ClientModels.MatchmakeResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.OpenTradeResponse))
          if (_instance.OnOpenTradeResultEvent != null) {
            _instance.OnOpenTradeResultEvent((ClientModels.OpenTradeResponse) e.Result);
            return;
          }

        if (type == typeof(ClientModels.PayForPurchaseResult))
          if (_instance.OnPayForPurchaseResultEvent != null) {
            _instance.OnPayForPurchaseResultEvent((ClientModels.PayForPurchaseResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.PurchaseItemResult))
          if (_instance.OnPurchaseItemResultEvent != null) {
            _instance.OnPurchaseItemResultEvent((ClientModels.PurchaseItemResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.RedeemCouponResult))
          if (_instance.OnRedeemCouponResultEvent != null) {
            _instance.OnRedeemCouponResultEvent((ClientModels.RedeemCouponResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.EmptyResponse))
          if (_instance.OnRefreshPSNAuthTokenResultEvent != null) {
            _instance.OnRefreshPSNAuthTokenResultEvent((ClientModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(ClientModels.RegisterForIOSPushNotificationResult))
          if (_instance.OnRegisterForIOSPushNotificationResultEvent != null) {
            _instance.OnRegisterForIOSPushNotificationResultEvent(
              (ClientModels.RegisterForIOSPushNotificationResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.RegisterPlayFabUserResult))
          if (_instance.OnRegisterPlayFabUserResultEvent != null) {
            _instance.OnRegisterPlayFabUserResultEvent((ClientModels.RegisterPlayFabUserResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.RemoveContactEmailResult))
          if (_instance.OnRemoveContactEmailResultEvent != null) {
            _instance.OnRemoveContactEmailResultEvent((ClientModels.RemoveContactEmailResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.RemoveFriendResult))
          if (_instance.OnRemoveFriendResultEvent != null) {
            _instance.OnRemoveFriendResultEvent((ClientModels.RemoveFriendResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.RemoveGenericIDResult))
          if (_instance.OnRemoveGenericIDResultEvent != null) {
            _instance.OnRemoveGenericIDResultEvent((ClientModels.RemoveGenericIDResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.RemoveSharedGroupMembersResult))
          if (_instance.OnRemoveSharedGroupMembersResultEvent != null) {
            _instance.OnRemoveSharedGroupMembersResultEvent((ClientModels.RemoveSharedGroupMembersResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.ReportAdActivityResult))
          if (_instance.OnReportAdActivityResultEvent != null) {
            _instance.OnReportAdActivityResultEvent((ClientModels.ReportAdActivityResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.EmptyResponse))
          if (_instance.OnReportDeviceInfoResultEvent != null) {
            _instance.OnReportDeviceInfoResultEvent((ClientModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(ClientModels.ReportPlayerClientResult))
          if (_instance.OnReportPlayerResultEvent != null) {
            _instance.OnReportPlayerResultEvent((ClientModels.ReportPlayerClientResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.RestoreIOSPurchasesResult))
          if (_instance.OnRestoreIOSPurchasesResultEvent != null) {
            _instance.OnRestoreIOSPurchasesResultEvent((ClientModels.RestoreIOSPurchasesResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.RewardAdActivityResult))
          if (_instance.OnRewardAdActivityResultEvent != null) {
            _instance.OnRewardAdActivityResultEvent((ClientModels.RewardAdActivityResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.SendAccountRecoveryEmailResult))
          if (_instance.OnSendAccountRecoveryEmailResultEvent != null) {
            _instance.OnSendAccountRecoveryEmailResultEvent((ClientModels.SendAccountRecoveryEmailResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.SetFriendTagsResult))
          if (_instance.OnSetFriendTagsResultEvent != null) {
            _instance.OnSetFriendTagsResultEvent((ClientModels.SetFriendTagsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.SetPlayerSecretResult))
          if (_instance.OnSetPlayerSecretResultEvent != null) {
            _instance.OnSetPlayerSecretResultEvent((ClientModels.SetPlayerSecretResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.StartGameResult))
          if (_instance.OnStartGameResultEvent != null) {
            _instance.OnStartGameResultEvent((ClientModels.StartGameResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.StartPurchaseResult))
          if (_instance.OnStartPurchaseResultEvent != null) {
            _instance.OnStartPurchaseResultEvent((ClientModels.StartPurchaseResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.ModifyUserVirtualCurrencyResult))
          if (_instance.OnSubtractUserVirtualCurrencyResultEvent != null) {
            _instance.OnSubtractUserVirtualCurrencyResultEvent((ClientModels.ModifyUserVirtualCurrencyResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UnlinkAndroidDeviceIDResult))
          if (_instance.OnUnlinkAndroidDeviceIDResultEvent != null) {
            _instance.OnUnlinkAndroidDeviceIDResultEvent((ClientModels.UnlinkAndroidDeviceIDResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.EmptyResponse))
          if (_instance.OnUnlinkAppleResultEvent != null) {
            _instance.OnUnlinkAppleResultEvent((ClientModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UnlinkCustomIDResult))
          if (_instance.OnUnlinkCustomIDResultEvent != null) {
            _instance.OnUnlinkCustomIDResultEvent((ClientModels.UnlinkCustomIDResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UnlinkFacebookAccountResult))
          if (_instance.OnUnlinkFacebookAccountResultEvent != null) {
            _instance.OnUnlinkFacebookAccountResultEvent((ClientModels.UnlinkFacebookAccountResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UnlinkFacebookInstantGamesIdResult))
          if (_instance.OnUnlinkFacebookInstantGamesIdResultEvent != null) {
            _instance.OnUnlinkFacebookInstantGamesIdResultEvent(
              (ClientModels.UnlinkFacebookInstantGamesIdResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UnlinkGameCenterAccountResult))
          if (_instance.OnUnlinkGameCenterAccountResultEvent != null) {
            _instance.OnUnlinkGameCenterAccountResultEvent((ClientModels.UnlinkGameCenterAccountResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UnlinkGoogleAccountResult))
          if (_instance.OnUnlinkGoogleAccountResultEvent != null) {
            _instance.OnUnlinkGoogleAccountResultEvent((ClientModels.UnlinkGoogleAccountResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UnlinkIOSDeviceIDResult))
          if (_instance.OnUnlinkIOSDeviceIDResultEvent != null) {
            _instance.OnUnlinkIOSDeviceIDResultEvent((ClientModels.UnlinkIOSDeviceIDResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UnlinkKongregateAccountResult))
          if (_instance.OnUnlinkKongregateResultEvent != null) {
            _instance.OnUnlinkKongregateResultEvent((ClientModels.UnlinkKongregateAccountResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.EmptyResponse))
          if (_instance.OnUnlinkNintendoAccountResultEvent != null) {
            _instance.OnUnlinkNintendoAccountResultEvent((ClientModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UnlinkNintendoSwitchDeviceIdResult))
          if (_instance.OnUnlinkNintendoSwitchDeviceIdResultEvent != null) {
            _instance.OnUnlinkNintendoSwitchDeviceIdResultEvent(
              (ClientModels.UnlinkNintendoSwitchDeviceIdResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.EmptyResponse))
          if (_instance.OnUnlinkOpenIdConnectResultEvent != null) {
            _instance.OnUnlinkOpenIdConnectResultEvent((ClientModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UnlinkPSNAccountResult))
          if (_instance.OnUnlinkPSNAccountResultEvent != null) {
            _instance.OnUnlinkPSNAccountResultEvent((ClientModels.UnlinkPSNAccountResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UnlinkSteamAccountResult))
          if (_instance.OnUnlinkSteamAccountResultEvent != null) {
            _instance.OnUnlinkSteamAccountResultEvent((ClientModels.UnlinkSteamAccountResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UnlinkTwitchAccountResult))
          if (_instance.OnUnlinkTwitchResultEvent != null) {
            _instance.OnUnlinkTwitchResultEvent((ClientModels.UnlinkTwitchAccountResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UnlinkWindowsHelloAccountResponse))
          if (_instance.OnUnlinkWindowsHelloResultEvent != null) {
            _instance.OnUnlinkWindowsHelloResultEvent((ClientModels.UnlinkWindowsHelloAccountResponse) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UnlinkXboxAccountResult))
          if (_instance.OnUnlinkXboxAccountResultEvent != null) {
            _instance.OnUnlinkXboxAccountResultEvent((ClientModels.UnlinkXboxAccountResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UnlockContainerItemResult))
          if (_instance.OnUnlockContainerInstanceResultEvent != null) {
            _instance.OnUnlockContainerInstanceResultEvent((ClientModels.UnlockContainerItemResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UnlockContainerItemResult))
          if (_instance.OnUnlockContainerItemResultEvent != null) {
            _instance.OnUnlockContainerItemResultEvent((ClientModels.UnlockContainerItemResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.EmptyResponse))
          if (_instance.OnUpdateAvatarUrlResultEvent != null) {
            _instance.OnUpdateAvatarUrlResultEvent((ClientModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UpdateCharacterDataResult))
          if (_instance.OnUpdateCharacterDataResultEvent != null) {
            _instance.OnUpdateCharacterDataResultEvent((ClientModels.UpdateCharacterDataResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UpdateCharacterStatisticsResult))
          if (_instance.OnUpdateCharacterStatisticsResultEvent != null) {
            _instance.OnUpdateCharacterStatisticsResultEvent((ClientModels.UpdateCharacterStatisticsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UpdatePlayerStatisticsResult))
          if (_instance.OnUpdatePlayerStatisticsResultEvent != null) {
            _instance.OnUpdatePlayerStatisticsResultEvent((ClientModels.UpdatePlayerStatisticsResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UpdateSharedGroupDataResult))
          if (_instance.OnUpdateSharedGroupDataResultEvent != null) {
            _instance.OnUpdateSharedGroupDataResultEvent((ClientModels.UpdateSharedGroupDataResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UpdateUserDataResult))
          if (_instance.OnUpdateUserDataResultEvent != null) {
            _instance.OnUpdateUserDataResultEvent((ClientModels.UpdateUserDataResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UpdateUserDataResult))
          if (_instance.OnUpdateUserPublisherDataResultEvent != null) {
            _instance.OnUpdateUserPublisherDataResultEvent((ClientModels.UpdateUserDataResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.UpdateUserTitleDisplayNameResult))
          if (_instance.OnUpdateUserTitleDisplayNameResultEvent != null) {
            _instance.OnUpdateUserTitleDisplayNameResultEvent((ClientModels.UpdateUserTitleDisplayNameResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.ValidateAmazonReceiptResult))
          if (_instance.OnValidateAmazonIAPReceiptResultEvent != null) {
            _instance.OnValidateAmazonIAPReceiptResultEvent((ClientModels.ValidateAmazonReceiptResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.ValidateGooglePlayPurchaseResult))
          if (_instance.OnValidateGooglePlayPurchaseResultEvent != null) {
            _instance.OnValidateGooglePlayPurchaseResultEvent((ClientModels.ValidateGooglePlayPurchaseResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.ValidateIOSReceiptResult))
          if (_instance.OnValidateIOSReceiptResultEvent != null) {
            _instance.OnValidateIOSReceiptResultEvent((ClientModels.ValidateIOSReceiptResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.ValidateWindowsReceiptResult))
          if (_instance.OnValidateWindowsStoreReceiptResultEvent != null) {
            _instance.OnValidateWindowsStoreReceiptResultEvent((ClientModels.ValidateWindowsReceiptResult) e.Result);
            return;
          }

        if (type == typeof(ClientModels.WriteEventResponse))
          if (_instance.OnWriteCharacterEventResultEvent != null) {
            _instance.OnWriteCharacterEventResultEvent((ClientModels.WriteEventResponse) e.Result);
            return;
          }

        if (type == typeof(ClientModels.WriteEventResponse))
          if (_instance.OnWritePlayerEventResultEvent != null) {
            _instance.OnWritePlayerEventResultEvent((ClientModels.WriteEventResponse) e.Result);
            return;
          }

        if (type == typeof(ClientModels.WriteEventResponse))
          if (_instance.OnWriteTitleEventResultEvent != null) {
            _instance.OnWriteTitleEventResultEvent((ClientModels.WriteEventResponse) e.Result);
            return;
          }
#endif
#if ENABLE_PLAYFABSERVER_API
                if (type == typeof(MatchmakerModels.AuthUserResponse)) { if (_instance.OnMatchmakerAuthUserResultEvent != null) { _instance.OnMatchmakerAuthUserResultEvent((MatchmakerModels.AuthUserResponse)e.Result); return; } }
                if (type == typeof(MatchmakerModels.PlayerJoinedResponse)) { if (_instance.OnMatchmakerPlayerJoinedResultEvent != null) { _instance.OnMatchmakerPlayerJoinedResultEvent((MatchmakerModels.PlayerJoinedResponse)e.Result); return; } }
                if (type == typeof(MatchmakerModels.PlayerLeftResponse)) { if (_instance.OnMatchmakerPlayerLeftResultEvent != null) { _instance.OnMatchmakerPlayerLeftResultEvent((MatchmakerModels.PlayerLeftResponse)e.Result); return; } }
                if (type == typeof(MatchmakerModels.StartGameResponse)) { if (_instance.OnMatchmakerStartGameResultEvent != null) { _instance.OnMatchmakerStartGameResultEvent((MatchmakerModels.StartGameResponse)e.Result); return; } }
                if (type == typeof(MatchmakerModels.UserInfoResponse)) { if (_instance.OnMatchmakerUserInfoResultEvent != null) { _instance.OnMatchmakerUserInfoResultEvent((MatchmakerModels.UserInfoResponse)e.Result); return; } }
#endif
#if ENABLE_PLAYFABSERVER_API
                if (type == typeof(ServerModels.ModifyCharacterVirtualCurrencyResult)) { if (_instance.OnServerAddCharacterVirtualCurrencyResultEvent != null) { _instance.OnServerAddCharacterVirtualCurrencyResultEvent((ServerModels.ModifyCharacterVirtualCurrencyResult)e.Result); return; } }
                if (type == typeof(ServerModels.EmptyResponse)) { if (_instance.OnServerAddFriendResultEvent != null) { _instance.OnServerAddFriendResultEvent((ServerModels.EmptyResponse)e.Result); return; } }
                if (type == typeof(ServerModels.EmptyResult)) { if (_instance.OnServerAddGenericIDResultEvent != null) { _instance.OnServerAddGenericIDResultEvent((ServerModels.EmptyResult)e.Result); return; } }
                if (type == typeof(ServerModels.AddPlayerTagResult)) { if (_instance.OnServerAddPlayerTagResultEvent != null) { _instance.OnServerAddPlayerTagResultEvent((ServerModels.AddPlayerTagResult)e.Result); return; } }
                if (type == typeof(ServerModels.AddSharedGroupMembersResult)) { if (_instance.OnServerAddSharedGroupMembersResultEvent != null) { _instance.OnServerAddSharedGroupMembersResultEvent((ServerModels.AddSharedGroupMembersResult)e.Result); return; } }
                if (type == typeof(ServerModels.ModifyUserVirtualCurrencyResult)) { if (_instance.OnServerAddUserVirtualCurrencyResultEvent != null) { _instance.OnServerAddUserVirtualCurrencyResultEvent((ServerModels.ModifyUserVirtualCurrencyResult)e.Result); return; } }
                if (type == typeof(ServerModels.AuthenticateSessionTicketResult)) { if (_instance.OnServerAuthenticateSessionTicketResultEvent != null) { _instance.OnServerAuthenticateSessionTicketResultEvent((ServerModels.AuthenticateSessionTicketResult)e.Result); return; } }
                if (type == typeof(ServerModels.AwardSteamAchievementResult)) { if (_instance.OnServerAwardSteamAchievementResultEvent != null) { _instance.OnServerAwardSteamAchievementResultEvent((ServerModels.AwardSteamAchievementResult)e.Result); return; } }
                if (type == typeof(ServerModels.BanUsersResult)) { if (_instance.OnServerBanUsersResultEvent != null) { _instance.OnServerBanUsersResultEvent((ServerModels.BanUsersResult)e.Result); return; } }
                if (type == typeof(ServerModels.ConsumeItemResult)) { if (_instance.OnServerConsumeItemResultEvent != null) { _instance.OnServerConsumeItemResultEvent((ServerModels.ConsumeItemResult)e.Result); return; } }
                if (type == typeof(ServerModels.CreateSharedGroupResult)) { if (_instance.OnServerCreateSharedGroupResultEvent != null) { _instance.OnServerCreateSharedGroupResultEvent((ServerModels.CreateSharedGroupResult)e.Result); return; } }
                if (type == typeof(ServerModels.DeleteCharacterFromUserResult)) { if (_instance.OnServerDeleteCharacterFromUserResultEvent != null) { _instance.OnServerDeleteCharacterFromUserResultEvent((ServerModels.DeleteCharacterFromUserResult)e.Result); return; } }
                if (type == typeof(ServerModels.DeletePlayerResult)) { if (_instance.OnServerDeletePlayerResultEvent != null) { _instance.OnServerDeletePlayerResultEvent((ServerModels.DeletePlayerResult)e.Result); return; } }
                if (type == typeof(ServerModels.DeletePushNotificationTemplateResult)) { if (_instance.OnServerDeletePushNotificationTemplateResultEvent != null) { _instance.OnServerDeletePushNotificationTemplateResultEvent((ServerModels.DeletePushNotificationTemplateResult)e.Result); return; } }
                if (type == typeof(ServerModels.EmptyResponse)) { if (_instance.OnServerDeleteSharedGroupResultEvent != null) { _instance.OnServerDeleteSharedGroupResultEvent((ServerModels.EmptyResponse)e.Result); return; } }
                if (type == typeof(ServerModels.DeregisterGameResponse)) { if (_instance.OnServerDeregisterGameResultEvent != null) { _instance.OnServerDeregisterGameResultEvent((ServerModels.DeregisterGameResponse)e.Result); return; } }
                if (type == typeof(ServerModels.EvaluateRandomResultTableResult)) { if (_instance.OnServerEvaluateRandomResultTableResultEvent != null) { _instance.OnServerEvaluateRandomResultTableResultEvent((ServerModels.EvaluateRandomResultTableResult)e.Result); return; } }
                if (type == typeof(ServerModels.ExecuteCloudScriptResult)) { if (_instance.OnServerExecuteCloudScriptResultEvent != null) { _instance.OnServerExecuteCloudScriptResultEvent((ServerModels.ExecuteCloudScriptResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetAllSegmentsResult)) { if (_instance.OnServerGetAllSegmentsResultEvent != null) { _instance.OnServerGetAllSegmentsResultEvent((ServerModels.GetAllSegmentsResult)e.Result); return; } }
                if (type == typeof(ServerModels.ListUsersCharactersResult)) { if (_instance.OnServerGetAllUsersCharactersResultEvent != null) { _instance.OnServerGetAllUsersCharactersResultEvent((ServerModels.ListUsersCharactersResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetCatalogItemsResult)) { if (_instance.OnServerGetCatalogItemsResultEvent != null) { _instance.OnServerGetCatalogItemsResultEvent((ServerModels.GetCatalogItemsResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetCharacterDataResult)) { if (_instance.OnServerGetCharacterDataResultEvent != null) { _instance.OnServerGetCharacterDataResultEvent((ServerModels.GetCharacterDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetCharacterDataResult)) { if (_instance.OnServerGetCharacterInternalDataResultEvent != null) { _instance.OnServerGetCharacterInternalDataResultEvent((ServerModels.GetCharacterDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetCharacterInventoryResult)) { if (_instance.OnServerGetCharacterInventoryResultEvent != null) { _instance.OnServerGetCharacterInventoryResultEvent((ServerModels.GetCharacterInventoryResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetCharacterLeaderboardResult)) { if (_instance.OnServerGetCharacterLeaderboardResultEvent != null) { _instance.OnServerGetCharacterLeaderboardResultEvent((ServerModels.GetCharacterLeaderboardResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetCharacterDataResult)) { if (_instance.OnServerGetCharacterReadOnlyDataResultEvent != null) { _instance.OnServerGetCharacterReadOnlyDataResultEvent((ServerModels.GetCharacterDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetCharacterStatisticsResult)) { if (_instance.OnServerGetCharacterStatisticsResultEvent != null) { _instance.OnServerGetCharacterStatisticsResultEvent((ServerModels.GetCharacterStatisticsResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetContentDownloadUrlResult)) { if (_instance.OnServerGetContentDownloadUrlResultEvent != null) { _instance.OnServerGetContentDownloadUrlResultEvent((ServerModels.GetContentDownloadUrlResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetLeaderboardResult)) { if (_instance.OnServerGetFriendLeaderboardResultEvent != null) { _instance.OnServerGetFriendLeaderboardResultEvent((ServerModels.GetLeaderboardResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetFriendsListResult)) { if (_instance.OnServerGetFriendsListResultEvent != null) { _instance.OnServerGetFriendsListResultEvent((ServerModels.GetFriendsListResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetLeaderboardResult)) { if (_instance.OnServerGetLeaderboardResultEvent != null) { _instance.OnServerGetLeaderboardResultEvent((ServerModels.GetLeaderboardResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetLeaderboardAroundCharacterResult)) { if (_instance.OnServerGetLeaderboardAroundCharacterResultEvent != null) { _instance.OnServerGetLeaderboardAroundCharacterResultEvent((ServerModels.GetLeaderboardAroundCharacterResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetLeaderboardAroundUserResult)) { if (_instance.OnServerGetLeaderboardAroundUserResultEvent != null) { _instance.OnServerGetLeaderboardAroundUserResultEvent((ServerModels.GetLeaderboardAroundUserResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetLeaderboardForUsersCharactersResult)) { if (_instance.OnServerGetLeaderboardForUserCharactersResultEvent != null) { _instance.OnServerGetLeaderboardForUserCharactersResultEvent((ServerModels.GetLeaderboardForUsersCharactersResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetPlayerCombinedInfoResult)) { if (_instance.OnServerGetPlayerCombinedInfoResultEvent != null) { _instance.OnServerGetPlayerCombinedInfoResultEvent((ServerModels.GetPlayerCombinedInfoResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetPlayerProfileResult)) { if (_instance.OnServerGetPlayerProfileResultEvent != null) { _instance.OnServerGetPlayerProfileResultEvent((ServerModels.GetPlayerProfileResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetPlayerSegmentsResult)) { if (_instance.OnServerGetPlayerSegmentsResultEvent != null) { _instance.OnServerGetPlayerSegmentsResultEvent((ServerModels.GetPlayerSegmentsResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetPlayersInSegmentResult)) { if (_instance.OnServerGetPlayersInSegmentResultEvent != null) { _instance.OnServerGetPlayersInSegmentResultEvent((ServerModels.GetPlayersInSegmentResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetPlayerStatisticsResult)) { if (_instance.OnServerGetPlayerStatisticsResultEvent != null) { _instance.OnServerGetPlayerStatisticsResultEvent((ServerModels.GetPlayerStatisticsResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetPlayerStatisticVersionsResult)) { if (_instance.OnServerGetPlayerStatisticVersionsResultEvent != null) { _instance.OnServerGetPlayerStatisticVersionsResultEvent((ServerModels.GetPlayerStatisticVersionsResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetPlayerTagsResult)) { if (_instance.OnServerGetPlayerTagsResultEvent != null) { _instance.OnServerGetPlayerTagsResultEvent((ServerModels.GetPlayerTagsResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetPlayFabIDsFromFacebookIDsResult)) { if (_instance.OnServerGetPlayFabIDsFromFacebookIDsResultEvent != null) { _instance.OnServerGetPlayFabIDsFromFacebookIDsResultEvent((ServerModels.GetPlayFabIDsFromFacebookIDsResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetPlayFabIDsFromFacebookInstantGamesIdsResult)) { if (_instance.OnServerGetPlayFabIDsFromFacebookInstantGamesIdsResultEvent != null) { _instance.OnServerGetPlayFabIDsFromFacebookInstantGamesIdsResultEvent((ServerModels.GetPlayFabIDsFromFacebookInstantGamesIdsResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetPlayFabIDsFromGenericIDsResult)) { if (_instance.OnServerGetPlayFabIDsFromGenericIDsResultEvent != null) { _instance.OnServerGetPlayFabIDsFromGenericIDsResultEvent((ServerModels.GetPlayFabIDsFromGenericIDsResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetPlayFabIDsFromNintendoSwitchDeviceIdsResult)) { if (_instance.OnServerGetPlayFabIDsFromNintendoSwitchDeviceIdsResultEvent != null) { _instance.OnServerGetPlayFabIDsFromNintendoSwitchDeviceIdsResultEvent((ServerModels.GetPlayFabIDsFromNintendoSwitchDeviceIdsResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetPlayFabIDsFromPSNAccountIDsResult)) { if (_instance.OnServerGetPlayFabIDsFromPSNAccountIDsResultEvent != null) { _instance.OnServerGetPlayFabIDsFromPSNAccountIDsResultEvent((ServerModels.GetPlayFabIDsFromPSNAccountIDsResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetPlayFabIDsFromSteamIDsResult)) { if (_instance.OnServerGetPlayFabIDsFromSteamIDsResultEvent != null) { _instance.OnServerGetPlayFabIDsFromSteamIDsResultEvent((ServerModels.GetPlayFabIDsFromSteamIDsResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetPlayFabIDsFromXboxLiveIDsResult)) { if (_instance.OnServerGetPlayFabIDsFromXboxLiveIDsResultEvent != null) { _instance.OnServerGetPlayFabIDsFromXboxLiveIDsResultEvent((ServerModels.GetPlayFabIDsFromXboxLiveIDsResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetPublisherDataResult)) { if (_instance.OnServerGetPublisherDataResultEvent != null) { _instance.OnServerGetPublisherDataResultEvent((ServerModels.GetPublisherDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetRandomResultTablesResult)) { if (_instance.OnServerGetRandomResultTablesResultEvent != null) { _instance.OnServerGetRandomResultTablesResultEvent((ServerModels.GetRandomResultTablesResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetServerCustomIDsFromPlayFabIDsResult)) { if (_instance.OnServerGetServerCustomIDsFromPlayFabIDsResultEvent != null) { _instance.OnServerGetServerCustomIDsFromPlayFabIDsResultEvent((ServerModels.GetServerCustomIDsFromPlayFabIDsResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetSharedGroupDataResult)) { if (_instance.OnServerGetSharedGroupDataResultEvent != null) { _instance.OnServerGetSharedGroupDataResultEvent((ServerModels.GetSharedGroupDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetStoreItemsResult)) { if (_instance.OnServerGetStoreItemsResultEvent != null) { _instance.OnServerGetStoreItemsResultEvent((ServerModels.GetStoreItemsResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetTimeResult)) { if (_instance.OnServerGetTimeResultEvent != null) { _instance.OnServerGetTimeResultEvent((ServerModels.GetTimeResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetTitleDataResult)) { if (_instance.OnServerGetTitleDataResultEvent != null) { _instance.OnServerGetTitleDataResultEvent((ServerModels.GetTitleDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetTitleDataResult)) { if (_instance.OnServerGetTitleInternalDataResultEvent != null) { _instance.OnServerGetTitleInternalDataResultEvent((ServerModels.GetTitleDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetTitleNewsResult)) { if (_instance.OnServerGetTitleNewsResultEvent != null) { _instance.OnServerGetTitleNewsResultEvent((ServerModels.GetTitleNewsResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetUserAccountInfoResult)) { if (_instance.OnServerGetUserAccountInfoResultEvent != null) { _instance.OnServerGetUserAccountInfoResultEvent((ServerModels.GetUserAccountInfoResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetUserBansResult)) { if (_instance.OnServerGetUserBansResultEvent != null) { _instance.OnServerGetUserBansResultEvent((ServerModels.GetUserBansResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetUserDataResult)) { if (_instance.OnServerGetUserDataResultEvent != null) { _instance.OnServerGetUserDataResultEvent((ServerModels.GetUserDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetUserDataResult)) { if (_instance.OnServerGetUserInternalDataResultEvent != null) { _instance.OnServerGetUserInternalDataResultEvent((ServerModels.GetUserDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetUserInventoryResult)) { if (_instance.OnServerGetUserInventoryResultEvent != null) { _instance.OnServerGetUserInventoryResultEvent((ServerModels.GetUserInventoryResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetUserDataResult)) { if (_instance.OnServerGetUserPublisherDataResultEvent != null) { _instance.OnServerGetUserPublisherDataResultEvent((ServerModels.GetUserDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetUserDataResult)) { if (_instance.OnServerGetUserPublisherInternalDataResultEvent != null) { _instance.OnServerGetUserPublisherInternalDataResultEvent((ServerModels.GetUserDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetUserDataResult)) { if (_instance.OnServerGetUserPublisherReadOnlyDataResultEvent != null) { _instance.OnServerGetUserPublisherReadOnlyDataResultEvent((ServerModels.GetUserDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.GetUserDataResult)) { if (_instance.OnServerGetUserReadOnlyDataResultEvent != null) { _instance.OnServerGetUserReadOnlyDataResultEvent((ServerModels.GetUserDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.GrantCharacterToUserResult)) { if (_instance.OnServerGrantCharacterToUserResultEvent != null) { _instance.OnServerGrantCharacterToUserResultEvent((ServerModels.GrantCharacterToUserResult)e.Result); return; } }
                if (type == typeof(ServerModels.GrantItemsToCharacterResult)) { if (_instance.OnServerGrantItemsToCharacterResultEvent != null) { _instance.OnServerGrantItemsToCharacterResultEvent((ServerModels.GrantItemsToCharacterResult)e.Result); return; } }
                if (type == typeof(ServerModels.GrantItemsToUserResult)) { if (_instance.OnServerGrantItemsToUserResultEvent != null) { _instance.OnServerGrantItemsToUserResultEvent((ServerModels.GrantItemsToUserResult)e.Result); return; } }
                if (type == typeof(ServerModels.GrantItemsToUsersResult)) { if (_instance.OnServerGrantItemsToUsersResultEvent != null) { _instance.OnServerGrantItemsToUsersResultEvent((ServerModels.GrantItemsToUsersResult)e.Result); return; } }
                if (type == typeof(ServerModels.LinkPSNAccountResult)) { if (_instance.OnServerLinkPSNAccountResultEvent != null) { _instance.OnServerLinkPSNAccountResultEvent((ServerModels.LinkPSNAccountResult)e.Result); return; } }
                if (type == typeof(ServerModels.LinkServerCustomIdResult)) { if (_instance.OnServerLinkServerCustomIdResultEvent != null) { _instance.OnServerLinkServerCustomIdResultEvent((ServerModels.LinkServerCustomIdResult)e.Result); return; } }
                if (type == typeof(ServerModels.LinkXboxAccountResult)) { if (_instance.OnServerLinkXboxAccountResultEvent != null) { _instance.OnServerLinkXboxAccountResultEvent((ServerModels.LinkXboxAccountResult)e.Result); return; } }
                if (type == typeof(ServerModels.ServerLoginResult)) { if (_instance.OnServerLoginWithServerCustomIdResultEvent != null) { _instance.OnServerLoginWithServerCustomIdResultEvent((ServerModels.ServerLoginResult)e.Result); return; } }
                if (type == typeof(ServerModels.ServerLoginResult)) { if (_instance.OnServerLoginWithXboxResultEvent != null) { _instance.OnServerLoginWithXboxResultEvent((ServerModels.ServerLoginResult)e.Result); return; } }
                if (type == typeof(ServerModels.ServerLoginResult)) { if (_instance.OnServerLoginWithXboxIdResultEvent != null) { _instance.OnServerLoginWithXboxIdResultEvent((ServerModels.ServerLoginResult)e.Result); return; } }
                if (type == typeof(ServerModels.ModifyItemUsesResult)) { if (_instance.OnServerModifyItemUsesResultEvent != null) { _instance.OnServerModifyItemUsesResultEvent((ServerModels.ModifyItemUsesResult)e.Result); return; } }
                if (type == typeof(ServerModels.MoveItemToCharacterFromCharacterResult)) { if (_instance.OnServerMoveItemToCharacterFromCharacterResultEvent != null) { _instance.OnServerMoveItemToCharacterFromCharacterResultEvent((ServerModels.MoveItemToCharacterFromCharacterResult)e.Result); return; } }
                if (type == typeof(ServerModels.MoveItemToCharacterFromUserResult)) { if (_instance.OnServerMoveItemToCharacterFromUserResultEvent != null) { _instance.OnServerMoveItemToCharacterFromUserResultEvent((ServerModels.MoveItemToCharacterFromUserResult)e.Result); return; } }
                if (type == typeof(ServerModels.MoveItemToUserFromCharacterResult)) { if (_instance.OnServerMoveItemToUserFromCharacterResultEvent != null) { _instance.OnServerMoveItemToUserFromCharacterResultEvent((ServerModels.MoveItemToUserFromCharacterResult)e.Result); return; } }
                if (type == typeof(ServerModels.NotifyMatchmakerPlayerLeftResult)) { if (_instance.OnServerNotifyMatchmakerPlayerLeftResultEvent != null) { _instance.OnServerNotifyMatchmakerPlayerLeftResultEvent((ServerModels.NotifyMatchmakerPlayerLeftResult)e.Result); return; } }
                if (type == typeof(ServerModels.RedeemCouponResult)) { if (_instance.OnServerRedeemCouponResultEvent != null) { _instance.OnServerRedeemCouponResultEvent((ServerModels.RedeemCouponResult)e.Result); return; } }
                if (type == typeof(ServerModels.RedeemMatchmakerTicketResult)) { if (_instance.OnServerRedeemMatchmakerTicketResultEvent != null) { _instance.OnServerRedeemMatchmakerTicketResultEvent((ServerModels.RedeemMatchmakerTicketResult)e.Result); return; } }
                if (type == typeof(ServerModels.RefreshGameServerInstanceHeartbeatResult)) { if (_instance.OnServerRefreshGameServerInstanceHeartbeatResultEvent != null) { _instance.OnServerRefreshGameServerInstanceHeartbeatResultEvent((ServerModels.RefreshGameServerInstanceHeartbeatResult)e.Result); return; } }
                if (type == typeof(ServerModels.RegisterGameResponse)) { if (_instance.OnServerRegisterGameResultEvent != null) { _instance.OnServerRegisterGameResultEvent((ServerModels.RegisterGameResponse)e.Result); return; } }
                if (type == typeof(ServerModels.EmptyResponse)) { if (_instance.OnServerRemoveFriendResultEvent != null) { _instance.OnServerRemoveFriendResultEvent((ServerModels.EmptyResponse)e.Result); return; } }
                if (type == typeof(ServerModels.EmptyResult)) { if (_instance.OnServerRemoveGenericIDResultEvent != null) { _instance.OnServerRemoveGenericIDResultEvent((ServerModels.EmptyResult)e.Result); return; } }
                if (type == typeof(ServerModels.RemovePlayerTagResult)) { if (_instance.OnServerRemovePlayerTagResultEvent != null) { _instance.OnServerRemovePlayerTagResultEvent((ServerModels.RemovePlayerTagResult)e.Result); return; } }
                if (type == typeof(ServerModels.RemoveSharedGroupMembersResult)) { if (_instance.OnServerRemoveSharedGroupMembersResultEvent != null) { _instance.OnServerRemoveSharedGroupMembersResultEvent((ServerModels.RemoveSharedGroupMembersResult)e.Result); return; } }
                if (type == typeof(ServerModels.ReportPlayerServerResult)) { if (_instance.OnServerReportPlayerResultEvent != null) { _instance.OnServerReportPlayerResultEvent((ServerModels.ReportPlayerServerResult)e.Result); return; } }
                if (type == typeof(ServerModels.RevokeAllBansForUserResult)) { if (_instance.OnServerRevokeAllBansForUserResultEvent != null) { _instance.OnServerRevokeAllBansForUserResultEvent((ServerModels.RevokeAllBansForUserResult)e.Result); return; } }
                if (type == typeof(ServerModels.RevokeBansResult)) { if (_instance.OnServerRevokeBansResultEvent != null) { _instance.OnServerRevokeBansResultEvent((ServerModels.RevokeBansResult)e.Result); return; } }
                if (type == typeof(ServerModels.RevokeInventoryResult)) { if (_instance.OnServerRevokeInventoryItemResultEvent != null) { _instance.OnServerRevokeInventoryItemResultEvent((ServerModels.RevokeInventoryResult)e.Result); return; } }
                if (type == typeof(ServerModels.RevokeInventoryItemsResult)) { if (_instance.OnServerRevokeInventoryItemsResultEvent != null) { _instance.OnServerRevokeInventoryItemsResultEvent((ServerModels.RevokeInventoryItemsResult)e.Result); return; } }
                if (type == typeof(ServerModels.SavePushNotificationTemplateResult)) { if (_instance.OnServerSavePushNotificationTemplateResultEvent != null) { _instance.OnServerSavePushNotificationTemplateResultEvent((ServerModels.SavePushNotificationTemplateResult)e.Result); return; } }
                if (type == typeof(ServerModels.SendCustomAccountRecoveryEmailResult)) { if (_instance.OnServerSendCustomAccountRecoveryEmailResultEvent != null) { _instance.OnServerSendCustomAccountRecoveryEmailResultEvent((ServerModels.SendCustomAccountRecoveryEmailResult)e.Result); return; } }
                if (type == typeof(ServerModels.SendEmailFromTemplateResult)) { if (_instance.OnServerSendEmailFromTemplateResultEvent != null) { _instance.OnServerSendEmailFromTemplateResultEvent((ServerModels.SendEmailFromTemplateResult)e.Result); return; } }
                if (type == typeof(ServerModels.SendPushNotificationResult)) { if (_instance.OnServerSendPushNotificationResultEvent != null) { _instance.OnServerSendPushNotificationResultEvent((ServerModels.SendPushNotificationResult)e.Result); return; } }
                if (type == typeof(ServerModels.SendPushNotificationResult)) { if (_instance.OnServerSendPushNotificationFromTemplateResultEvent != null) { _instance.OnServerSendPushNotificationFromTemplateResultEvent((ServerModels.SendPushNotificationResult)e.Result); return; } }
                if (type == typeof(ServerModels.EmptyResponse)) { if (_instance.OnServerSetFriendTagsResultEvent != null) { _instance.OnServerSetFriendTagsResultEvent((ServerModels.EmptyResponse)e.Result); return; } }
                if (type == typeof(ServerModels.SetGameServerInstanceDataResult)) { if (_instance.OnServerSetGameServerInstanceDataResultEvent != null) { _instance.OnServerSetGameServerInstanceDataResultEvent((ServerModels.SetGameServerInstanceDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.SetGameServerInstanceStateResult)) { if (_instance.OnServerSetGameServerInstanceStateResultEvent != null) { _instance.OnServerSetGameServerInstanceStateResultEvent((ServerModels.SetGameServerInstanceStateResult)e.Result); return; } }
                if (type == typeof(ServerModels.SetGameServerInstanceTagsResult)) { if (_instance.OnServerSetGameServerInstanceTagsResultEvent != null) { _instance.OnServerSetGameServerInstanceTagsResultEvent((ServerModels.SetGameServerInstanceTagsResult)e.Result); return; } }
                if (type == typeof(ServerModels.SetPlayerSecretResult)) { if (_instance.OnServerSetPlayerSecretResultEvent != null) { _instance.OnServerSetPlayerSecretResultEvent((ServerModels.SetPlayerSecretResult)e.Result); return; } }
                if (type == typeof(ServerModels.SetPublisherDataResult)) { if (_instance.OnServerSetPublisherDataResultEvent != null) { _instance.OnServerSetPublisherDataResultEvent((ServerModels.SetPublisherDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.SetTitleDataResult)) { if (_instance.OnServerSetTitleDataResultEvent != null) { _instance.OnServerSetTitleDataResultEvent((ServerModels.SetTitleDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.SetTitleDataResult)) { if (_instance.OnServerSetTitleInternalDataResultEvent != null) { _instance.OnServerSetTitleInternalDataResultEvent((ServerModels.SetTitleDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.ModifyCharacterVirtualCurrencyResult)) { if (_instance.OnServerSubtractCharacterVirtualCurrencyResultEvent != null) { _instance.OnServerSubtractCharacterVirtualCurrencyResultEvent((ServerModels.ModifyCharacterVirtualCurrencyResult)e.Result); return; } }
                if (type == typeof(ServerModels.ModifyUserVirtualCurrencyResult)) { if (_instance.OnServerSubtractUserVirtualCurrencyResultEvent != null) { _instance.OnServerSubtractUserVirtualCurrencyResultEvent((ServerModels.ModifyUserVirtualCurrencyResult)e.Result); return; } }
                if (type == typeof(ServerModels.UnlinkPSNAccountResult)) { if (_instance.OnServerUnlinkPSNAccountResultEvent != null) { _instance.OnServerUnlinkPSNAccountResultEvent((ServerModels.UnlinkPSNAccountResult)e.Result); return; } }
                if (type == typeof(ServerModels.UnlinkServerCustomIdResult)) { if (_instance.OnServerUnlinkServerCustomIdResultEvent != null) { _instance.OnServerUnlinkServerCustomIdResultEvent((ServerModels.UnlinkServerCustomIdResult)e.Result); return; } }
                if (type == typeof(ServerModels.UnlinkXboxAccountResult)) { if (_instance.OnServerUnlinkXboxAccountResultEvent != null) { _instance.OnServerUnlinkXboxAccountResultEvent((ServerModels.UnlinkXboxAccountResult)e.Result); return; } }
                if (type == typeof(ServerModels.UnlockContainerItemResult)) { if (_instance.OnServerUnlockContainerInstanceResultEvent != null) { _instance.OnServerUnlockContainerInstanceResultEvent((ServerModels.UnlockContainerItemResult)e.Result); return; } }
                if (type == typeof(ServerModels.UnlockContainerItemResult)) { if (_instance.OnServerUnlockContainerItemResultEvent != null) { _instance.OnServerUnlockContainerItemResultEvent((ServerModels.UnlockContainerItemResult)e.Result); return; } }
                if (type == typeof(ServerModels.EmptyResponse)) { if (_instance.OnServerUpdateAvatarUrlResultEvent != null) { _instance.OnServerUpdateAvatarUrlResultEvent((ServerModels.EmptyResponse)e.Result); return; } }
                if (type == typeof(ServerModels.UpdateBansResult)) { if (_instance.OnServerUpdateBansResultEvent != null) { _instance.OnServerUpdateBansResultEvent((ServerModels.UpdateBansResult)e.Result); return; } }
                if (type == typeof(ServerModels.UpdateCharacterDataResult)) { if (_instance.OnServerUpdateCharacterDataResultEvent != null) { _instance.OnServerUpdateCharacterDataResultEvent((ServerModels.UpdateCharacterDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.UpdateCharacterDataResult)) { if (_instance.OnServerUpdateCharacterInternalDataResultEvent != null) { _instance.OnServerUpdateCharacterInternalDataResultEvent((ServerModels.UpdateCharacterDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.UpdateCharacterDataResult)) { if (_instance.OnServerUpdateCharacterReadOnlyDataResultEvent != null) { _instance.OnServerUpdateCharacterReadOnlyDataResultEvent((ServerModels.UpdateCharacterDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.UpdateCharacterStatisticsResult)) { if (_instance.OnServerUpdateCharacterStatisticsResultEvent != null) { _instance.OnServerUpdateCharacterStatisticsResultEvent((ServerModels.UpdateCharacterStatisticsResult)e.Result); return; } }
                if (type == typeof(ServerModels.UpdatePlayerStatisticsResult)) { if (_instance.OnServerUpdatePlayerStatisticsResultEvent != null) { _instance.OnServerUpdatePlayerStatisticsResultEvent((ServerModels.UpdatePlayerStatisticsResult)e.Result); return; } }
                if (type == typeof(ServerModels.UpdateSharedGroupDataResult)) { if (_instance.OnServerUpdateSharedGroupDataResultEvent != null) { _instance.OnServerUpdateSharedGroupDataResultEvent((ServerModels.UpdateSharedGroupDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.UpdateUserDataResult)) { if (_instance.OnServerUpdateUserDataResultEvent != null) { _instance.OnServerUpdateUserDataResultEvent((ServerModels.UpdateUserDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.UpdateUserDataResult)) { if (_instance.OnServerUpdateUserInternalDataResultEvent != null) { _instance.OnServerUpdateUserInternalDataResultEvent((ServerModels.UpdateUserDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.EmptyResponse)) { if (_instance.OnServerUpdateUserInventoryItemCustomDataResultEvent != null) { _instance.OnServerUpdateUserInventoryItemCustomDataResultEvent((ServerModels.EmptyResponse)e.Result); return; } }
                if (type == typeof(ServerModels.UpdateUserDataResult)) { if (_instance.OnServerUpdateUserPublisherDataResultEvent != null) { _instance.OnServerUpdateUserPublisherDataResultEvent((ServerModels.UpdateUserDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.UpdateUserDataResult)) { if (_instance.OnServerUpdateUserPublisherInternalDataResultEvent != null) { _instance.OnServerUpdateUserPublisherInternalDataResultEvent((ServerModels.UpdateUserDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.UpdateUserDataResult)) { if (_instance.OnServerUpdateUserPublisherReadOnlyDataResultEvent != null) { _instance.OnServerUpdateUserPublisherReadOnlyDataResultEvent((ServerModels.UpdateUserDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.UpdateUserDataResult)) { if (_instance.OnServerUpdateUserReadOnlyDataResultEvent != null) { _instance.OnServerUpdateUserReadOnlyDataResultEvent((ServerModels.UpdateUserDataResult)e.Result); return; } }
                if (type == typeof(ServerModels.WriteEventResponse)) { if (_instance.OnServerWriteCharacterEventResultEvent != null) { _instance.OnServerWriteCharacterEventResultEvent((ServerModels.WriteEventResponse)e.Result); return; } }
                if (type == typeof(ServerModels.WriteEventResponse)) { if (_instance.OnServerWritePlayerEventResultEvent != null) { _instance.OnServerWritePlayerEventResultEvent((ServerModels.WriteEventResponse)e.Result); return; } }
                if (type == typeof(ServerModels.WriteEventResponse)) { if (_instance.OnServerWriteTitleEventResultEvent != null) { _instance.OnServerWriteTitleEventResultEvent((ServerModels.WriteEventResponse)e.Result); return; } }
#endif
#if !DISABLE_PLAYFABENTITY_API

        if (type == typeof(AuthenticationModels.GetEntityTokenResponse))
          if (_instance.OnAuthenticationGetEntityTokenResultEvent != null) {
            _instance.OnAuthenticationGetEntityTokenResultEvent((AuthenticationModels.GetEntityTokenResponse) e.Result);
            return;
          }

        if (type == typeof(AuthenticationModels.ValidateEntityTokenResponse))
          if (_instance.OnAuthenticationValidateEntityTokenResultEvent != null) {
            _instance.OnAuthenticationValidateEntityTokenResultEvent(
              (AuthenticationModels.ValidateEntityTokenResponse) e.Result);
            return;
          }
#endif
#if !DISABLE_PLAYFABENTITY_API

        if (type == typeof(CloudScriptModels.ExecuteCloudScriptResult))
          if (_instance.OnCloudScriptExecuteEntityCloudScriptResultEvent != null) {
            _instance.OnCloudScriptExecuteEntityCloudScriptResultEvent(
              (CloudScriptModels.ExecuteCloudScriptResult) e.Result);
            return;
          }

        if (type == typeof(CloudScriptModels.ExecuteFunctionResult))
          if (_instance.OnCloudScriptExecuteFunctionResultEvent != null) {
            _instance.OnCloudScriptExecuteFunctionResultEvent((CloudScriptModels.ExecuteFunctionResult) e.Result);
            return;
          }

        if (type == typeof(CloudScriptModels.ListFunctionsResult))
          if (_instance.OnCloudScriptListFunctionsResultEvent != null) {
            _instance.OnCloudScriptListFunctionsResultEvent((CloudScriptModels.ListFunctionsResult) e.Result);
            return;
          }

        if (type == typeof(CloudScriptModels.ListHttpFunctionsResult))
          if (_instance.OnCloudScriptListHttpFunctionsResultEvent != null) {
            _instance.OnCloudScriptListHttpFunctionsResultEvent((CloudScriptModels.ListHttpFunctionsResult) e.Result);
            return;
          }

        if (type == typeof(CloudScriptModels.ListQueuedFunctionsResult))
          if (_instance.OnCloudScriptListQueuedFunctionsResultEvent != null) {
            _instance.OnCloudScriptListQueuedFunctionsResultEvent(
              (CloudScriptModels.ListQueuedFunctionsResult) e.Result);
            return;
          }

        if (type == typeof(CloudScriptModels.EmptyResult))
          if (_instance.OnCloudScriptPostFunctionResultForEntityTriggeredActionResultEvent != null) {
            _instance.OnCloudScriptPostFunctionResultForEntityTriggeredActionResultEvent(
              (CloudScriptModels.EmptyResult) e.Result);
            return;
          }

        if (type == typeof(CloudScriptModels.EmptyResult))
          if (_instance.OnCloudScriptPostFunctionResultForFunctionExecutionResultEvent != null) {
            _instance.OnCloudScriptPostFunctionResultForFunctionExecutionResultEvent(
              (CloudScriptModels.EmptyResult) e.Result);
            return;
          }

        if (type == typeof(CloudScriptModels.EmptyResult))
          if (_instance.OnCloudScriptPostFunctionResultForPlayerTriggeredActionResultEvent != null) {
            _instance.OnCloudScriptPostFunctionResultForPlayerTriggeredActionResultEvent(
              (CloudScriptModels.EmptyResult) e.Result);
            return;
          }

        if (type == typeof(CloudScriptModels.EmptyResult))
          if (_instance.OnCloudScriptPostFunctionResultForScheduledTaskResultEvent != null) {
            _instance.OnCloudScriptPostFunctionResultForScheduledTaskResultEvent(
              (CloudScriptModels.EmptyResult) e.Result);
            return;
          }

        if (type == typeof(CloudScriptModels.EmptyResult))
          if (_instance.OnCloudScriptRegisterHttpFunctionResultEvent != null) {
            _instance.OnCloudScriptRegisterHttpFunctionResultEvent((CloudScriptModels.EmptyResult) e.Result);
            return;
          }

        if (type == typeof(CloudScriptModels.EmptyResult))
          if (_instance.OnCloudScriptRegisterQueuedFunctionResultEvent != null) {
            _instance.OnCloudScriptRegisterQueuedFunctionResultEvent((CloudScriptModels.EmptyResult) e.Result);
            return;
          }

        if (type == typeof(CloudScriptModels.EmptyResult))
          if (_instance.OnCloudScriptUnregisterFunctionResultEvent != null) {
            _instance.OnCloudScriptUnregisterFunctionResultEvent((CloudScriptModels.EmptyResult) e.Result);
            return;
          }
#endif
#if !DISABLE_PLAYFABENTITY_API

        if (type == typeof(DataModels.AbortFileUploadsResponse))
          if (_instance.OnDataAbortFileUploadsResultEvent != null) {
            _instance.OnDataAbortFileUploadsResultEvent((DataModels.AbortFileUploadsResponse) e.Result);
            return;
          }

        if (type == typeof(DataModels.DeleteFilesResponse))
          if (_instance.OnDataDeleteFilesResultEvent != null) {
            _instance.OnDataDeleteFilesResultEvent((DataModels.DeleteFilesResponse) e.Result);
            return;
          }

        if (type == typeof(DataModels.FinalizeFileUploadsResponse))
          if (_instance.OnDataFinalizeFileUploadsResultEvent != null) {
            _instance.OnDataFinalizeFileUploadsResultEvent((DataModels.FinalizeFileUploadsResponse) e.Result);
            return;
          }

        if (type == typeof(DataModels.GetFilesResponse))
          if (_instance.OnDataGetFilesResultEvent != null) {
            _instance.OnDataGetFilesResultEvent((DataModels.GetFilesResponse) e.Result);
            return;
          }

        if (type == typeof(DataModels.GetObjectsResponse))
          if (_instance.OnDataGetObjectsResultEvent != null) {
            _instance.OnDataGetObjectsResultEvent((DataModels.GetObjectsResponse) e.Result);
            return;
          }

        if (type == typeof(DataModels.InitiateFileUploadsResponse))
          if (_instance.OnDataInitiateFileUploadsResultEvent != null) {
            _instance.OnDataInitiateFileUploadsResultEvent((DataModels.InitiateFileUploadsResponse) e.Result);
            return;
          }

        if (type == typeof(DataModels.SetObjectsResponse))
          if (_instance.OnDataSetObjectsResultEvent != null) {
            _instance.OnDataSetObjectsResultEvent((DataModels.SetObjectsResponse) e.Result);
            return;
          }
#endif
#if !DISABLE_PLAYFABENTITY_API

        if (type == typeof(EventsModels.WriteEventsResponse))
          if (_instance.OnEventsWriteEventsResultEvent != null) {
            _instance.OnEventsWriteEventsResultEvent((EventsModels.WriteEventsResponse) e.Result);
            return;
          }

        if (type == typeof(EventsModels.WriteEventsResponse))
          if (_instance.OnEventsWriteTelemetryEventsResultEvent != null) {
            _instance.OnEventsWriteTelemetryEventsResultEvent((EventsModels.WriteEventsResponse) e.Result);
            return;
          }
#endif
#if !DISABLE_PLAYFABENTITY_API

        if (type == typeof(ExperimentationModels.CreateExperimentResult))
          if (_instance.OnExperimentationCreateExperimentResultEvent != null) {
            _instance.OnExperimentationCreateExperimentResultEvent(
              (ExperimentationModels.CreateExperimentResult) e.Result);
            return;
          }

        if (type == typeof(ExperimentationModels.EmptyResponse))
          if (_instance.OnExperimentationDeleteExperimentResultEvent != null) {
            _instance.OnExperimentationDeleteExperimentResultEvent((ExperimentationModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(ExperimentationModels.GetExperimentsResult))
          if (_instance.OnExperimentationGetExperimentsResultEvent != null) {
            _instance.OnExperimentationGetExperimentsResultEvent((ExperimentationModels.GetExperimentsResult) e.Result);
            return;
          }

        if (type == typeof(ExperimentationModels.GetLatestScorecardResult))
          if (_instance.OnExperimentationGetLatestScorecardResultEvent != null) {
            _instance.OnExperimentationGetLatestScorecardResultEvent(
              (ExperimentationModels.GetLatestScorecardResult) e.Result);
            return;
          }

        if (type == typeof(ExperimentationModels.GetTreatmentAssignmentResult))
          if (_instance.OnExperimentationGetTreatmentAssignmentResultEvent != null) {
            _instance.OnExperimentationGetTreatmentAssignmentResultEvent(
              (ExperimentationModels.GetTreatmentAssignmentResult) e.Result);
            return;
          }

        if (type == typeof(ExperimentationModels.EmptyResponse))
          if (_instance.OnExperimentationStartExperimentResultEvent != null) {
            _instance.OnExperimentationStartExperimentResultEvent((ExperimentationModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(ExperimentationModels.EmptyResponse))
          if (_instance.OnExperimentationStopExperimentResultEvent != null) {
            _instance.OnExperimentationStopExperimentResultEvent((ExperimentationModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(ExperimentationModels.EmptyResponse))
          if (_instance.OnExperimentationUpdateExperimentResultEvent != null) {
            _instance.OnExperimentationUpdateExperimentResultEvent((ExperimentationModels.EmptyResponse) e.Result);
            return;
          }
#endif
#if !DISABLE_PLAYFABENTITY_API

        if (type == typeof(InsightsModels.InsightsGetDetailsResponse))
          if (_instance.OnInsightsGetDetailsResultEvent != null) {
            _instance.OnInsightsGetDetailsResultEvent((InsightsModels.InsightsGetDetailsResponse) e.Result);
            return;
          }

        if (type == typeof(InsightsModels.InsightsGetLimitsResponse))
          if (_instance.OnInsightsGetLimitsResultEvent != null) {
            _instance.OnInsightsGetLimitsResultEvent((InsightsModels.InsightsGetLimitsResponse) e.Result);
            return;
          }

        if (type == typeof(InsightsModels.InsightsGetOperationStatusResponse))
          if (_instance.OnInsightsGetOperationStatusResultEvent != null) {
            _instance.OnInsightsGetOperationStatusResultEvent(
              (InsightsModels.InsightsGetOperationStatusResponse) e.Result);
            return;
          }

        if (type == typeof(InsightsModels.InsightsGetPendingOperationsResponse))
          if (_instance.OnInsightsGetPendingOperationsResultEvent != null) {
            _instance.OnInsightsGetPendingOperationsResultEvent(
              (InsightsModels.InsightsGetPendingOperationsResponse) e.Result);
            return;
          }

        if (type == typeof(InsightsModels.InsightsOperationResponse))
          if (_instance.OnInsightsSetPerformanceResultEvent != null) {
            _instance.OnInsightsSetPerformanceResultEvent((InsightsModels.InsightsOperationResponse) e.Result);
            return;
          }

        if (type == typeof(InsightsModels.InsightsOperationResponse))
          if (_instance.OnInsightsSetStorageRetentionResultEvent != null) {
            _instance.OnInsightsSetStorageRetentionResultEvent((InsightsModels.InsightsOperationResponse) e.Result);
            return;
          }
#endif
#if !DISABLE_PLAYFABENTITY_API

        if (type == typeof(GroupsModels.EmptyResponse))
          if (_instance.OnGroupsAcceptGroupApplicationResultEvent != null) {
            _instance.OnGroupsAcceptGroupApplicationResultEvent((GroupsModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.EmptyResponse))
          if (_instance.OnGroupsAcceptGroupInvitationResultEvent != null) {
            _instance.OnGroupsAcceptGroupInvitationResultEvent((GroupsModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.EmptyResponse))
          if (_instance.OnGroupsAddMembersResultEvent != null) {
            _instance.OnGroupsAddMembersResultEvent((GroupsModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.ApplyToGroupResponse))
          if (_instance.OnGroupsApplyToGroupResultEvent != null) {
            _instance.OnGroupsApplyToGroupResultEvent((GroupsModels.ApplyToGroupResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.EmptyResponse))
          if (_instance.OnGroupsBlockEntityResultEvent != null) {
            _instance.OnGroupsBlockEntityResultEvent((GroupsModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.EmptyResponse))
          if (_instance.OnGroupsChangeMemberRoleResultEvent != null) {
            _instance.OnGroupsChangeMemberRoleResultEvent((GroupsModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.CreateGroupResponse))
          if (_instance.OnGroupsCreateGroupResultEvent != null) {
            _instance.OnGroupsCreateGroupResultEvent((GroupsModels.CreateGroupResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.CreateGroupRoleResponse))
          if (_instance.OnGroupsCreateRoleResultEvent != null) {
            _instance.OnGroupsCreateRoleResultEvent((GroupsModels.CreateGroupRoleResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.EmptyResponse))
          if (_instance.OnGroupsDeleteGroupResultEvent != null) {
            _instance.OnGroupsDeleteGroupResultEvent((GroupsModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.EmptyResponse))
          if (_instance.OnGroupsDeleteRoleResultEvent != null) {
            _instance.OnGroupsDeleteRoleResultEvent((GroupsModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.GetGroupResponse))
          if (_instance.OnGroupsGetGroupResultEvent != null) {
            _instance.OnGroupsGetGroupResultEvent((GroupsModels.GetGroupResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.InviteToGroupResponse))
          if (_instance.OnGroupsInviteToGroupResultEvent != null) {
            _instance.OnGroupsInviteToGroupResultEvent((GroupsModels.InviteToGroupResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.IsMemberResponse))
          if (_instance.OnGroupsIsMemberResultEvent != null) {
            _instance.OnGroupsIsMemberResultEvent((GroupsModels.IsMemberResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.ListGroupApplicationsResponse))
          if (_instance.OnGroupsListGroupApplicationsResultEvent != null) {
            _instance.OnGroupsListGroupApplicationsResultEvent((GroupsModels.ListGroupApplicationsResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.ListGroupBlocksResponse))
          if (_instance.OnGroupsListGroupBlocksResultEvent != null) {
            _instance.OnGroupsListGroupBlocksResultEvent((GroupsModels.ListGroupBlocksResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.ListGroupInvitationsResponse))
          if (_instance.OnGroupsListGroupInvitationsResultEvent != null) {
            _instance.OnGroupsListGroupInvitationsResultEvent((GroupsModels.ListGroupInvitationsResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.ListGroupMembersResponse))
          if (_instance.OnGroupsListGroupMembersResultEvent != null) {
            _instance.OnGroupsListGroupMembersResultEvent((GroupsModels.ListGroupMembersResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.ListMembershipResponse))
          if (_instance.OnGroupsListMembershipResultEvent != null) {
            _instance.OnGroupsListMembershipResultEvent((GroupsModels.ListMembershipResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.ListMembershipOpportunitiesResponse))
          if (_instance.OnGroupsListMembershipOpportunitiesResultEvent != null) {
            _instance.OnGroupsListMembershipOpportunitiesResultEvent(
              (GroupsModels.ListMembershipOpportunitiesResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.EmptyResponse))
          if (_instance.OnGroupsRemoveGroupApplicationResultEvent != null) {
            _instance.OnGroupsRemoveGroupApplicationResultEvent((GroupsModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.EmptyResponse))
          if (_instance.OnGroupsRemoveGroupInvitationResultEvent != null) {
            _instance.OnGroupsRemoveGroupInvitationResultEvent((GroupsModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.EmptyResponse))
          if (_instance.OnGroupsRemoveMembersResultEvent != null) {
            _instance.OnGroupsRemoveMembersResultEvent((GroupsModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.EmptyResponse))
          if (_instance.OnGroupsUnblockEntityResultEvent != null) {
            _instance.OnGroupsUnblockEntityResultEvent((GroupsModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.UpdateGroupResponse))
          if (_instance.OnGroupsUpdateGroupResultEvent != null) {
            _instance.OnGroupsUpdateGroupResultEvent((GroupsModels.UpdateGroupResponse) e.Result);
            return;
          }

        if (type == typeof(GroupsModels.UpdateGroupRoleResponse))
          if (_instance.OnGroupsUpdateRoleResultEvent != null) {
            _instance.OnGroupsUpdateRoleResultEvent((GroupsModels.UpdateGroupRoleResponse) e.Result);
            return;
          }
#endif
#if !DISABLE_PLAYFABENTITY_API

        if (type == typeof(LocalizationModels.GetLanguageListResponse))
          if (_instance.OnLocalizationGetLanguageListResultEvent != null) {
            _instance.OnLocalizationGetLanguageListResultEvent((LocalizationModels.GetLanguageListResponse) e.Result);
            return;
          }
#endif
#if !DISABLE_PLAYFABENTITY_API

        if (type == typeof(MultiplayerModels.CancelAllMatchmakingTicketsForPlayerResult))
          if (_instance.OnMultiplayerCancelAllMatchmakingTicketsForPlayerResultEvent != null) {
            _instance.OnMultiplayerCancelAllMatchmakingTicketsForPlayerResultEvent(
              (MultiplayerModels.CancelAllMatchmakingTicketsForPlayerResult) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.CancelAllServerBackfillTicketsForPlayerResult))
          if (_instance.OnMultiplayerCancelAllServerBackfillTicketsForPlayerResultEvent != null) {
            _instance.OnMultiplayerCancelAllServerBackfillTicketsForPlayerResultEvent(
              (MultiplayerModels.CancelAllServerBackfillTicketsForPlayerResult) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.CancelMatchmakingTicketResult))
          if (_instance.OnMultiplayerCancelMatchmakingTicketResultEvent != null) {
            _instance.OnMultiplayerCancelMatchmakingTicketResultEvent(
              (MultiplayerModels.CancelMatchmakingTicketResult) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.CancelServerBackfillTicketResult))
          if (_instance.OnMultiplayerCancelServerBackfillTicketResultEvent != null) {
            _instance.OnMultiplayerCancelServerBackfillTicketResultEvent(
              (MultiplayerModels.CancelServerBackfillTicketResult) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.BuildAliasDetailsResponse))
          if (_instance.OnMultiplayerCreateBuildAliasResultEvent != null) {
            _instance.OnMultiplayerCreateBuildAliasResultEvent((MultiplayerModels.BuildAliasDetailsResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.CreateBuildWithCustomContainerResponse))
          if (_instance.OnMultiplayerCreateBuildWithCustomContainerResultEvent != null) {
            _instance.OnMultiplayerCreateBuildWithCustomContainerResultEvent(
              (MultiplayerModels.CreateBuildWithCustomContainerResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.CreateBuildWithManagedContainerResponse))
          if (_instance.OnMultiplayerCreateBuildWithManagedContainerResultEvent != null) {
            _instance.OnMultiplayerCreateBuildWithManagedContainerResultEvent(
              (MultiplayerModels.CreateBuildWithManagedContainerResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.CreateMatchmakingTicketResult))
          if (_instance.OnMultiplayerCreateMatchmakingTicketResultEvent != null) {
            _instance.OnMultiplayerCreateMatchmakingTicketResultEvent(
              (MultiplayerModels.CreateMatchmakingTicketResult) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.CreateRemoteUserResponse))
          if (_instance.OnMultiplayerCreateRemoteUserResultEvent != null) {
            _instance.OnMultiplayerCreateRemoteUserResultEvent((MultiplayerModels.CreateRemoteUserResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.CreateServerBackfillTicketResult))
          if (_instance.OnMultiplayerCreateServerBackfillTicketResultEvent != null) {
            _instance.OnMultiplayerCreateServerBackfillTicketResultEvent(
              (MultiplayerModels.CreateServerBackfillTicketResult) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.CreateMatchmakingTicketResult))
          if (_instance.OnMultiplayerCreateServerMatchmakingTicketResultEvent != null) {
            _instance.OnMultiplayerCreateServerMatchmakingTicketResultEvent(
              (MultiplayerModels.CreateMatchmakingTicketResult) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.EmptyResponse))
          if (_instance.OnMultiplayerDeleteAssetResultEvent != null) {
            _instance.OnMultiplayerDeleteAssetResultEvent((MultiplayerModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.EmptyResponse))
          if (_instance.OnMultiplayerDeleteBuildResultEvent != null) {
            _instance.OnMultiplayerDeleteBuildResultEvent((MultiplayerModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.EmptyResponse))
          if (_instance.OnMultiplayerDeleteBuildAliasResultEvent != null) {
            _instance.OnMultiplayerDeleteBuildAliasResultEvent((MultiplayerModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.EmptyResponse))
          if (_instance.OnMultiplayerDeleteBuildRegionResultEvent != null) {
            _instance.OnMultiplayerDeleteBuildRegionResultEvent((MultiplayerModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.EmptyResponse))
          if (_instance.OnMultiplayerDeleteCertificateResultEvent != null) {
            _instance.OnMultiplayerDeleteCertificateResultEvent((MultiplayerModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.EmptyResponse))
          if (_instance.OnMultiplayerDeleteContainerImageRepositoryResultEvent != null) {
            _instance.OnMultiplayerDeleteContainerImageRepositoryResultEvent(
              (MultiplayerModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.EmptyResponse))
          if (_instance.OnMultiplayerDeleteRemoteUserResultEvent != null) {
            _instance.OnMultiplayerDeleteRemoteUserResultEvent((MultiplayerModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.EnableMultiplayerServersForTitleResponse))
          if (_instance.OnMultiplayerEnableMultiplayerServersForTitleResultEvent != null) {
            _instance.OnMultiplayerEnableMultiplayerServersForTitleResultEvent(
              (MultiplayerModels.EnableMultiplayerServersForTitleResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.GetAssetUploadUrlResponse))
          if (_instance.OnMultiplayerGetAssetUploadUrlResultEvent != null) {
            _instance.OnMultiplayerGetAssetUploadUrlResultEvent((MultiplayerModels.GetAssetUploadUrlResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.GetBuildResponse))
          if (_instance.OnMultiplayerGetBuildResultEvent != null) {
            _instance.OnMultiplayerGetBuildResultEvent((MultiplayerModels.GetBuildResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.BuildAliasDetailsResponse))
          if (_instance.OnMultiplayerGetBuildAliasResultEvent != null) {
            _instance.OnMultiplayerGetBuildAliasResultEvent((MultiplayerModels.BuildAliasDetailsResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.GetContainerRegistryCredentialsResponse))
          if (_instance.OnMultiplayerGetContainerRegistryCredentialsResultEvent != null) {
            _instance.OnMultiplayerGetContainerRegistryCredentialsResultEvent(
              (MultiplayerModels.GetContainerRegistryCredentialsResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.GetMatchResult))
          if (_instance.OnMultiplayerGetMatchResultEvent != null) {
            _instance.OnMultiplayerGetMatchResultEvent((MultiplayerModels.GetMatchResult) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.GetMatchmakingQueueResult))
          if (_instance.OnMultiplayerGetMatchmakingQueueResultEvent != null) {
            _instance.OnMultiplayerGetMatchmakingQueueResultEvent(
              (MultiplayerModels.GetMatchmakingQueueResult) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.GetMatchmakingTicketResult))
          if (_instance.OnMultiplayerGetMatchmakingTicketResultEvent != null) {
            _instance.OnMultiplayerGetMatchmakingTicketResultEvent(
              (MultiplayerModels.GetMatchmakingTicketResult) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.GetMultiplayerServerDetailsResponse))
          if (_instance.OnMultiplayerGetMultiplayerServerDetailsResultEvent != null) {
            _instance.OnMultiplayerGetMultiplayerServerDetailsResultEvent(
              (MultiplayerModels.GetMultiplayerServerDetailsResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.GetMultiplayerServerLogsResponse))
          if (_instance.OnMultiplayerGetMultiplayerServerLogsResultEvent != null) {
            _instance.OnMultiplayerGetMultiplayerServerLogsResultEvent(
              (MultiplayerModels.GetMultiplayerServerLogsResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.GetMultiplayerServerLogsResponse))
          if (_instance.OnMultiplayerGetMultiplayerSessionLogsBySessionIdResultEvent != null) {
            _instance.OnMultiplayerGetMultiplayerSessionLogsBySessionIdResultEvent(
              (MultiplayerModels.GetMultiplayerServerLogsResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.GetQueueStatisticsResult))
          if (_instance.OnMultiplayerGetQueueStatisticsResultEvent != null) {
            _instance.OnMultiplayerGetQueueStatisticsResultEvent((MultiplayerModels.GetQueueStatisticsResult) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.GetRemoteLoginEndpointResponse))
          if (_instance.OnMultiplayerGetRemoteLoginEndpointResultEvent != null) {
            _instance.OnMultiplayerGetRemoteLoginEndpointResultEvent(
              (MultiplayerModels.GetRemoteLoginEndpointResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.GetServerBackfillTicketResult))
          if (_instance.OnMultiplayerGetServerBackfillTicketResultEvent != null) {
            _instance.OnMultiplayerGetServerBackfillTicketResultEvent(
              (MultiplayerModels.GetServerBackfillTicketResult) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.GetTitleEnabledForMultiplayerServersStatusResponse))
          if (_instance.OnMultiplayerGetTitleEnabledForMultiplayerServersStatusResultEvent != null) {
            _instance.OnMultiplayerGetTitleEnabledForMultiplayerServersStatusResultEvent(
              (MultiplayerModels.GetTitleEnabledForMultiplayerServersStatusResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.GetTitleMultiplayerServersQuotasResponse))
          if (_instance.OnMultiplayerGetTitleMultiplayerServersQuotasResultEvent != null) {
            _instance.OnMultiplayerGetTitleMultiplayerServersQuotasResultEvent(
              (MultiplayerModels.GetTitleMultiplayerServersQuotasResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.JoinMatchmakingTicketResult))
          if (_instance.OnMultiplayerJoinMatchmakingTicketResultEvent != null) {
            _instance.OnMultiplayerJoinMatchmakingTicketResultEvent(
              (MultiplayerModels.JoinMatchmakingTicketResult) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.ListMultiplayerServersResponse))
          if (_instance.OnMultiplayerListArchivedMultiplayerServersResultEvent != null) {
            _instance.OnMultiplayerListArchivedMultiplayerServersResultEvent(
              (MultiplayerModels.ListMultiplayerServersResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.ListAssetSummariesResponse))
          if (_instance.OnMultiplayerListAssetSummariesResultEvent != null) {
            _instance.OnMultiplayerListAssetSummariesResultEvent(
              (MultiplayerModels.ListAssetSummariesResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.ListBuildAliasesForTitleResponse))
          if (_instance.OnMultiplayerListBuildAliasesResultEvent != null) {
            _instance.OnMultiplayerListBuildAliasesResultEvent(
              (MultiplayerModels.ListBuildAliasesForTitleResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.ListBuildSummariesResponse))
          if (_instance.OnMultiplayerListBuildSummariesResultEvent != null) {
            _instance.OnMultiplayerListBuildSummariesResultEvent(
              (MultiplayerModels.ListBuildSummariesResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.ListCertificateSummariesResponse))
          if (_instance.OnMultiplayerListCertificateSummariesResultEvent != null) {
            _instance.OnMultiplayerListCertificateSummariesResultEvent(
              (MultiplayerModels.ListCertificateSummariesResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.ListContainerImagesResponse))
          if (_instance.OnMultiplayerListContainerImagesResultEvent != null) {
            _instance.OnMultiplayerListContainerImagesResultEvent(
              (MultiplayerModels.ListContainerImagesResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.ListContainerImageTagsResponse))
          if (_instance.OnMultiplayerListContainerImageTagsResultEvent != null) {
            _instance.OnMultiplayerListContainerImageTagsResultEvent(
              (MultiplayerModels.ListContainerImageTagsResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.ListMatchmakingQueuesResult))
          if (_instance.OnMultiplayerListMatchmakingQueuesResultEvent != null) {
            _instance.OnMultiplayerListMatchmakingQueuesResultEvent(
              (MultiplayerModels.ListMatchmakingQueuesResult) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.ListMatchmakingTicketsForPlayerResult))
          if (_instance.OnMultiplayerListMatchmakingTicketsForPlayerResultEvent != null) {
            _instance.OnMultiplayerListMatchmakingTicketsForPlayerResultEvent(
              (MultiplayerModels.ListMatchmakingTicketsForPlayerResult) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.ListMultiplayerServersResponse))
          if (_instance.OnMultiplayerListMultiplayerServersResultEvent != null) {
            _instance.OnMultiplayerListMultiplayerServersResultEvent(
              (MultiplayerModels.ListMultiplayerServersResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.ListPartyQosServersResponse))
          if (_instance.OnMultiplayerListPartyQosServersResultEvent != null) {
            _instance.OnMultiplayerListPartyQosServersResultEvent(
              (MultiplayerModels.ListPartyQosServersResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.ListQosServersResponse))
          if (_instance.OnMultiplayerListQosServersResultEvent != null) {
            _instance.OnMultiplayerListQosServersResultEvent((MultiplayerModels.ListQosServersResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.ListQosServersForTitleResponse))
          if (_instance.OnMultiplayerListQosServersForTitleResultEvent != null) {
            _instance.OnMultiplayerListQosServersForTitleResultEvent(
              (MultiplayerModels.ListQosServersForTitleResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.ListServerBackfillTicketsForPlayerResult))
          if (_instance.OnMultiplayerListServerBackfillTicketsForPlayerResultEvent != null) {
            _instance.OnMultiplayerListServerBackfillTicketsForPlayerResultEvent(
              (MultiplayerModels.ListServerBackfillTicketsForPlayerResult) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.ListVirtualMachineSummariesResponse))
          if (_instance.OnMultiplayerListVirtualMachineSummariesResultEvent != null) {
            _instance.OnMultiplayerListVirtualMachineSummariesResultEvent(
              (MultiplayerModels.ListVirtualMachineSummariesResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.RemoveMatchmakingQueueResult))
          if (_instance.OnMultiplayerRemoveMatchmakingQueueResultEvent != null) {
            _instance.OnMultiplayerRemoveMatchmakingQueueResultEvent(
              (MultiplayerModels.RemoveMatchmakingQueueResult) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.RequestMultiplayerServerResponse))
          if (_instance.OnMultiplayerRequestMultiplayerServerResultEvent != null) {
            _instance.OnMultiplayerRequestMultiplayerServerResultEvent(
              (MultiplayerModels.RequestMultiplayerServerResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.RolloverContainerRegistryCredentialsResponse))
          if (_instance.OnMultiplayerRolloverContainerRegistryCredentialsResultEvent != null) {
            _instance.OnMultiplayerRolloverContainerRegistryCredentialsResultEvent(
              (MultiplayerModels.RolloverContainerRegistryCredentialsResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.SetMatchmakingQueueResult))
          if (_instance.OnMultiplayerSetMatchmakingQueueResultEvent != null) {
            _instance.OnMultiplayerSetMatchmakingQueueResultEvent(
              (MultiplayerModels.SetMatchmakingQueueResult) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.EmptyResponse))
          if (_instance.OnMultiplayerShutdownMultiplayerServerResultEvent != null) {
            _instance.OnMultiplayerShutdownMultiplayerServerResultEvent((MultiplayerModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.EmptyResponse))
          if (_instance.OnMultiplayerUntagContainerImageResultEvent != null) {
            _instance.OnMultiplayerUntagContainerImageResultEvent((MultiplayerModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.BuildAliasDetailsResponse))
          if (_instance.OnMultiplayerUpdateBuildAliasResultEvent != null) {
            _instance.OnMultiplayerUpdateBuildAliasResultEvent((MultiplayerModels.BuildAliasDetailsResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.EmptyResponse))
          if (_instance.OnMultiplayerUpdateBuildRegionResultEvent != null) {
            _instance.OnMultiplayerUpdateBuildRegionResultEvent((MultiplayerModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.EmptyResponse))
          if (_instance.OnMultiplayerUpdateBuildRegionsResultEvent != null) {
            _instance.OnMultiplayerUpdateBuildRegionsResultEvent((MultiplayerModels.EmptyResponse) e.Result);
            return;
          }

        if (type == typeof(MultiplayerModels.EmptyResponse))
          if (_instance.OnMultiplayerUploadCertificateResultEvent != null) {
            _instance.OnMultiplayerUploadCertificateResultEvent((MultiplayerModels.EmptyResponse) e.Result);
            return;
          }
#endif
#if !DISABLE_PLAYFABENTITY_API

        if (type == typeof(ProfilesModels.GetGlobalPolicyResponse))
          if (_instance.OnProfilesGetGlobalPolicyResultEvent != null) {
            _instance.OnProfilesGetGlobalPolicyResultEvent((ProfilesModels.GetGlobalPolicyResponse) e.Result);
            return;
          }

        if (type == typeof(ProfilesModels.GetEntityProfileResponse))
          if (_instance.OnProfilesGetProfileResultEvent != null) {
            _instance.OnProfilesGetProfileResultEvent((ProfilesModels.GetEntityProfileResponse) e.Result);
            return;
          }

        if (type == typeof(ProfilesModels.GetEntityProfilesResponse))
          if (_instance.OnProfilesGetProfilesResultEvent != null) {
            _instance.OnProfilesGetProfilesResultEvent((ProfilesModels.GetEntityProfilesResponse) e.Result);
            return;
          }

        if (type == typeof(ProfilesModels.GetTitlePlayersFromMasterPlayerAccountIdsResponse))
          if (_instance.OnProfilesGetTitlePlayersFromMasterPlayerAccountIdsResultEvent != null) {
            _instance.OnProfilesGetTitlePlayersFromMasterPlayerAccountIdsResultEvent(
              (ProfilesModels.GetTitlePlayersFromMasterPlayerAccountIdsResponse) e.Result);
            return;
          }

        if (type == typeof(ProfilesModels.SetGlobalPolicyResponse))
          if (_instance.OnProfilesSetGlobalPolicyResultEvent != null) {
            _instance.OnProfilesSetGlobalPolicyResultEvent((ProfilesModels.SetGlobalPolicyResponse) e.Result);
            return;
          }

        if (type == typeof(ProfilesModels.SetProfileLanguageResponse))
          if (_instance.OnProfilesSetProfileLanguageResultEvent != null) {
            _instance.OnProfilesSetProfileLanguageResultEvent((ProfilesModels.SetProfileLanguageResponse) e.Result);
            return;
          }

        if (type == typeof(ProfilesModels.SetEntityProfilePolicyResponse))
          if (_instance.OnProfilesSetProfilePolicyResultEvent != null) {
            _instance.OnProfilesSetProfilePolicyResultEvent((ProfilesModels.SetEntityProfilePolicyResponse) e.Result);
            return;
          }
#endif
      }
    }
  }
}