Select Top 1000000 tblAssets.AssetID,
  tblAssets.Domain,
  tblAssets.AssetName,
  tblAssets.Username,
  Case
    When tblComputersystem.Domainrole > 1 Then 'Server'
    Else Case
        When Coalesce(tblPortableBattery.AssetID, 0) = 0 Then 'Desktop'
        Else 'Laptop'
      End
  End As Type,
  tsysAssetTypes.AssetTypeIcon10 As icon,
  tblAssets.Lastseen,
  tblOperatingsystem.Caption As OS,
  tSoftware.softwareName,
  tSoftware.SoftwarePublisher,
  tSoftware.softwareVersion,
  tblProcessor.NumberOfCores,
  tblProcessor.NumberOfLogicalProcessors
From tblAssets
  Inner Join tblAssetCustom On tblAssets.AssetID = tblAssetCustom.AssetID
  Inner Join tsysAssetTypes On tsysAssetTypes.AssetType = tblAssets.Assettype
  Left Join (Select tblSoftware.AssetID,
        tblSoftwareUni.softwareName,
        tblSoftwareUni.SoftwarePublisher,
        tblSoftware.softwareVersion
      From tblSoftware
        Inner Join tblSoftwareUni On tblSoftwareUni.SoftID = tblSoftware.softID
      Where (tblSoftwareUni.softwareName Like '%%') Or
        (tblSoftwareUni.SoftwarePublisher Like '%%')) tSoftware On
    tSoftware.AssetID = tblAssets.AssetID
  Left Join tblPortableBattery On tblAssets.AssetID = tblPortableBattery.AssetID
  Inner Join tblOperatingsystem On
    tblAssets.AssetID = tblOperatingsystem.AssetID
  Inner Join tblComputersystem On tblAssets.AssetID = tblComputersystem.AssetID
  Inner Join tblProcessor On tblAssets.AssetID = tblProcessor.AssetID
Order By tblAssets.AssetName,
  tSoftware.softwareName