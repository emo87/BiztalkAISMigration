<#
.SYNOPSIS
Invokes the deployment of all resources into Azure.

.DESCRIPTION
Prior to running this script ensure you are authenticated against Azure.

.PARAMETER minDeploymentPriority
The minimum priority number found in the file name to be deployed.

.PARAMETER maxDeploymentPriority
The maximum priority number found in the file name to be deployed.

.PARAMETER maxRetriesPerScript
The maximum number of retries per script.

.PARAMETER retryPauseInSeconds
The pause in seconds between retries.

.PARAMETER runUnattended
If 1, then the user is not prompted for input and no verification checks are made, any other value, the user is prompted for input and verification checks are made before the scripts are executed.

.EXAMPLE
.\Deploy-All.ps1
.\Deploy-All.ps1 -minDeploymentPriority 10 -maxDeploymentPriority 200 -maxRetriesPerScript 2 -retryPauseInSeconds 5 -runUnattended 1
#>

[CmdletBinding()]
Param(
    [parameter(Mandatory = $false)]
    [int] $minDeploymentPriority = [int32]::MinValue,
    [parameter(Mandatory = $false)]
    [int] $maxDeploymentPriority = [int32]::MaxValue,
    [parameter(Mandatory = $false)]
    [int] $maxRetriesPerScript = 2,
    [parameter(Mandatory = $false)]
    [int]$retryPauseInSeconds = 5,
	[parameter(Mandatory = $false)]
    [int]$runUnattended = 0
)

class Template {
    [string]$FileName
    [string]$FullPath
    [int]$Priority

    Template(
        [string]$fileName,
        [string]$fullPath,
        [int]$priority
    ) {
        $this.FileName = $fileName
        $this.FullPath = $fullPath
        $this.Priority = $priority
    }
}

function New-DeploymentWithRetry {
    <#
    .SYNOPSIS
    Runs the deployment script and retries optionally on failures.

    .PARAMETER scriptFullPath
    The full path to the script for the deployment.
    #>
    Param($scriptFullPath)

    $deploymentComplete = $false
    $retryCount = 0

    while (-not $deploymentComplete) {
        try {
            & $scriptFullPath -ErrorAction Continue    
            $deploymentComplete = $true
        }
        catch {
            [Console]::ResetColor()            
            Write-Error -Exception $_.Exception
            if ($retryCount -gt $maxRetriesPerScript) {
                Write-Host "Exceeded the retry count for script $scriptFullPath"
                $deploymentComplete = $true
            }
            else {
                $retryCount++
                Write-Host "Retrying in $retryPauseInSeconds seconds for script $scriptFullPath"
                Start-Sleep $retryPauseInSeconds                
            }
        }
    }   
}

# Script version 0.2
$version = '0.2'

# Get current text foreground colour for the current shell.
# There is a bug in the Azure CLI which means that on error, it changes the default colour for the PowerShell Host.
# We attempt to get the current colour and use it for non-error Write-Host commands.
$defaultForegroundColour = (get-host).ui.rawui.ForegroundColor
if ( $defaultForegroundColour -eq -1 )
{
    $defaultForegroundColour = White
}

$haveErrors = 'false'
$haveWarnings = 'false'
if ($runUnattended -ne 1)
{
	Write-Host ""
	Write-Host "Welcome to the Microsoft BTS Migrator tool Deployment Script v$version, Logic Apps Consumption edition." -ForegroundColor $defaultForegroundColour
	Write-Host ""
	Write-Host "This script will attempt to deploy all migrated resources, using the Logic Apps Consumption offering." -ForegroundColor $defaultForegroundColour
	Write-Host ""
	Write-Host "Before deploying resources, this script will check the following:" -ForegroundColor $defaultForegroundColour
	Write-Host "   1) Is the Azure CLI installed?" -ForegroundColor $defaultForegroundColour
	Write-Host "   2) Can you login to the Azure CLI?" -ForegroundColor $defaultForegroundColour
	Write-Host "   3) Have you selected a subscription?" -ForegroundColor $defaultForegroundColour
	Write-Host "   4) Is the Azure App Configuration resource provider registered?" -ForegroundColor $defaultForegroundColour
	Write-Host "   5) Is there a Free SKU App Configuration instance deployed?" -ForegroundColor $defaultForegroundColour
	Write-Host "   6) Are there any Free SKU Integration Account instances deployed?" -ForegroundColor $defaultForegroundColour
	Write-Host ""
	Write-Host "After completing these steps, the tool will check if you wish to proceed with deployment." -ForegroundColor $defaultForegroundColour
	Write-Host ""
	Write-Host "NOTE: If this is your first deployment, or your first deployment with a new unique id, " -ForegroundColor $defaultForegroundColour
	Write-Host "please be aware that deployment will take *at least* 45 minutes" -ForegroundColor $defaultForegroundColour
	Write-Host "and that the script will appear to 'pause' for a long while." -ForegroundColor $defaultForegroundColour
	Write-Host "This is due to deployment of Azure API Management, which takes over 25 minutes to provision." -ForegroundColor $defaultForegroundColour
	Write-Host ""
	Read-Host "Press any key to continue..."
	# Step 1: Is the Azure CLI installed
	Write-Host "Step 1: Is the Azure CLI installed?" -ForegroundColor $defaultForegroundColour
	try
	{
		$null = Invoke-Expression -Command "az version" -ErrorVariable cliError -ErrorAction SilentlyContinue
	}
	catch {}

	if ($cliError[0])
	{
		Write-Host "Step 1: Failure: The Azure CLI is not installed." -ForegroundColor Red
		Write-Host "You will need to install it by following the instructions here:" -ForegroundColor $defaultForegroundColour
		Write-Host "https://docs.microsoft.com/en-us/cli/azure/install-azure-cli" -ForegroundColor $defaultForegroundColour
		Write-Host ""
		Write-Host "This script will now terminate, as the rest of the script relies on the Azure CLI being installed." -ForegroundColor $defaultForegroundColour
		Write-Host "Please try running this script again after you have installed the CLI." -ForegroundColor $defaultForegroundColour
		Write-Host ""
		Write-Host "Completed checking pre-requisites for the BTS Migrator tool." -ForegroundColor $defaultForegroundColour
		Write-Host ""
		return
	}
	else 
	{
		$cliVersion = az version --query '\"azure-cli\"' --output tsv
		Write-Host "Step 1: Success: v$cliVersion of the Azure CLI is installed." -ForegroundColor Green
		Write-Host ""
	}

	# Step 2: Can you login to the Azure CLI
	Write-Host "Step 2: Can you login to the Azure CLI?" -ForegroundColor $defaultForegroundColour
	Write-Host "Starting Login Process." -ForegroundColor $defaultForegroundColour
	Write-Host "Note: A browser window should open, prompting you for the account to use with the Azure CLI." -ForegroundColor $defaultForegroundColour
	Write-Host "If this does not happen, manually browse to https://aka.ms/devicelogin and enter the code shown in this window." -ForegroundColor $defaultForegroundColour
	Write-Host "If you are unable to perform this step, follow the instructions here:" -ForegroundColor $defaultForegroundColour
	Write-Host "https://docs.microsoft.com/en-us/cli/azure/authenticate-azure-cli" -ForegroundColor $defaultForegroundColour

	$loginResult = az login --only-show-errors
	if (!$loginResult)
	{
		Write-Host "Step 2: Failure: Unable to login to the Azure CLI." -ForegroundColor Red
		Write-Host "This script will now terminate, as the rest of the script relies on having logged in." -ForegroundColor $defaultForegroundColour
		Write-Host "Please try running this script again after you have fixed the issue." -ForegroundColor $defaultForegroundColour
		Write-Host ""
		Write-Host "Completed checking pre-requisites for the BTS Migrator tool." -ForegroundColor $defaultForegroundColour
		Write-Host ""
		return
	}
	else
	{
		$accountName = az account show --query "user.name" --output tsv
		Write-Host "Step 2: Success: Login to the Azure CLI succeeded." -ForegroundColor Green
		Write-Host "Logged in as: $accountName." -ForegroundColor $defaultForegroundColour
		Write-Host ""
	}

	# Step 3: Can you select a default subscription
	Write-Host "Step 3: Can you select a default subscription?" -ForegroundColor $defaultForegroundColour
	Write-Host "Note: You may have trouble selecting a subscription if Multi-Factor Authentication is enabled for that subscription." -ForegroundColor $defaultForegroundColour
	Write-Host "If that is the case, you may need to edit this PowerShell script, and add --tenant <tenant id> to the az login command." -ForegroundColor $defaultForegroundColour
	Write-Host ""
	$subscriptionsCount = az account list --query "length([?contains(user.name, '$accountName')])" --output tsv
	$subscriptionsTable = az account list --query "[?contains(user.name, '$accountName')].{Name:name, SubscriptionId:id, IsDefault:isDefault, State:state, TenantId:tenantId}" --output table
	if ( $subscriptionsCount -gt 1 )
	{
		Write-Host "You have access to more than one subscription." -ForegroundColor $defaultForegroundColour
		Write-Host "Please choose the subscription you wish to use" -ForegroundColor $defaultForegroundColour
		Write-Host "(or press ENTER to use the default subscription)" -ForegroundColor $defaultForegroundColour
		Write-Host ""
		$subscriptionsTable | Format-Table | Out-String | Write-Host
		$subscriptionId = Read-Host "Enter the SubscriptionId or name (with quotes if contains spaces) of the subscription to use (or ENTER for default)"
		if ( $subscriptionId -ne '' )
		{
			Write-Host "Setting subscription to use..."
			az account set --subscription $subscriptionId
			$currentSubscription = az account show --query "name" --output tsv
			Write-Host "Using subscription: $currentSubscription." -ForegroundColor $defaultForegroundColour
		}
		else
		{
			$currentSubscription = az account show --query "name" --output tsv
			$subscriptionId = az account show --query "id" --output tsv
			Write-Host "Using default subscription: $currentSubscription." -ForegroundColor $defaultForegroundColour
		}
	}
	else
	{
		$currentSubscription = az account show --query "name" --output tsv
		Write-Host "Using subscription: $currentSubscription." -ForegroundColor $defaultForegroundColour
	}

	Write-Host "Step 3: Success: Selected a subscription." -ForegroundColor Green
	Write-Host ""

	# Step 4: Is the App Configuration resource provider registered
	Write-Host "Step 4: Is the App Configuration resource provider registered?" -ForegroundColor $defaultForegroundColour
	# Get the registration status of the App Config resource provider
	$AppConfigState = az provider show --namespace Microsoft.AppConfiguration --query 'registrationState' --output tsv
	if (!$AppConfigState) {
		Write-Host "Step 4: Error: Unable to check if the Azure App Configuration resource provider is registered." -ForegroundColor Red
		Write-Host "Check if the account you're logged in with has the appropriate permissions to check resource provider registration." -ForegroundColor $defaultForegroundColour
		Write-Host ""
		Write-Host "Completed checking pre-requisites for the BTS Migrator tool." -ForegroundColor $defaultForegroundColour
		Write-Host ""
		return
	}

	if ( $AppConfigState -eq "Registered" )
	{
		Write-Host "Step 4: Success: App Configuration resource provider is registered." -ForegroundColor Green
		Write-Host ""
	}
	else
	{
		Write-Host "Step 4: Failure: App Configuration resource provider is not registered." -ForegroundColor Red
		Write-Host "Would you like to try and register it?" -ForegroundColor $defaultForegroundColour
		Write-Host "If your account does not have the permissions necessary to do this," -ForegroundColor $defaultForegroundColour
		Write-Host "then this step will fail and you will need to ask an admin to do it for you," -ForegroundColor $defaultForegroundColour
		Write-Host "following the steps here: https://docs.microsoft.com/en-us/azure/azure-resource-manager/management/resource-providers-and-types#register-resource-provider." -ForegroundColor $defaultForegroundColour
		Write-Host ""
		$registerAppConfig = Read-Host "Would you like to register the Microsoft.AppConfiguration resource provider (Y or N) - default is N"
		if ( $registerAppConfig -eq "Y" )
		{
			# Attempt to register the Microsoft.AppConfiguration resource provider
			Write-Host "Attempting to register the Microsoft.AppConfiguration resource provider (this may take 2-3 minutes)..." -ForegroundColor $defaultForegroundColour
			$registerResult = az provider register --namespace 'Microsoft.AppConfiguration' --wait

			if ( !$? )
			{
				Write-Host "Step 4: Failure: Unable to register the Microsoft.AppConfiguration resource provider due to an error." -ForegroundColor Red
				Write-Host ""
				$haveErrors = 'true'
			}
			else
			{
				Write-Host "Successfully registered the Microsoft.AppConfiguration resource provider." -ForegroundColor $defaultForegroundColour
				Write-Host ""
				Write-Host "Step 4: Success: App Configuration resource provider is registered." -ForegroundColor Green
				Write-Host ""
			}
		}
		else
		{
			Write-Host "Step 4: Failure: User chose to not register the App Configuration resource provider." -ForegroundColor Red
			Write-Host ""
			$haveErrors = 'true'
		}
	}

	# Step 5: Is there a Free SKU App Configuration instance deployed
	Write-Host "Step 5: Is there a Free SKU App Configuration instance deployed?" -ForegroundColor $defaultForegroundColour
	# If there is an existing Free SKU App Configuration resource deployed, get its name
	$ExistingFreeAppConfigName = az resource list --resource-type 'Microsoft.AppConfiguration/configurationStores' --query "[?contains(sku.name, 'free')].[name]" --output tsv
	# Test if we have a Free SKU App Config instance that don't appear to be part of the tool
	if ( $ExistingFreeAppConfigName -ne '' -and $ExistingFreeAppConfigName -notlike 'appcfg-aimrstore-*')
	{
		$haveErrors = 'true'
		Write-Host "Step 5: Failure: There is a Free SKU App Configuration instance deployed." -ForegroundColor Red
		Write-Host "There is an instance of Azure App Configuration" -ForegroundColor $defaultForegroundColour
		Write-Host "using the Free SKU deployed to this subscription" -ForegroundColor $defaultForegroundColour
		Write-Host "which doesn't appear to have been deployed by the BTS Migrator tool." -ForegroundColor $defaultForegroundColour
		Write-Host "The name of this instance is: $ExistingFreeAppConfigName." -ForegroundColor $defaultForegroundColour
		Write-Host "The deployment scripts will likely fail as you can only have " -ForegroundColor $defaultForegroundColour
		Write-Host "a single Free SKU Azure App Configuration instance per subscription." -ForegroundColor $defaultForegroundColour
		Write-Host ""
	}
	elseif ( $ExistingFreeAppConfigName -like 'appcfg-aimrstore-*')
	{
		$ExistingFreeAppConfigNameIndexOfLastDash = $ExistingFreeAppConfigName.LastIndexOfAny('-')
		if ( $ExistingFreeAppConfigNameIndexOfLastDash -gt 0 )
		{
			$UniqueDeploymentId = $ExistingFreeAppConfigName.Substring($ExistingFreeAppConfigNameIndexOfLastDash + 1)
			Write-Host "Step 5: Warning: There is an existing Free SKU App Configuration that has been deployed by the tool." -ForegroundColor Yellow
			Write-Host "You must use the same Unique Deployment ID ($UniqueDeploymentId) if you run the tool again." -ForegroundColor Yellow
			Write-Host ""
		}
		else
		{
			Write-Host "Step 5: Warning: There is an existing Free SKU App Configuration that appears to have been deployed by the tool," -ForegroundColor Yellow
			Write-Host "but the name is non standard." -ForegroundColor Yellow
			Write-Host ""
		}
	}
	else
	{
		Write-Host "Step 5: Success: There is no conflicting Free SKU App Configuration instance deployed." -ForegroundColor Green
		Write-Host ""
	}

	#Step 6: Are there any Free SKU Integration Account instances deployed
	Write-Host "Step 6: Are there any Free SKU Integration Account instances deployed?" -ForegroundColor $defaultForegroundColour
	# Get the name of any Free SKU Integration Accounts which don't look like they were deployed by the tool
	$ExistingFreeIntAccounts = az resource list --resource-type 'Microsoft.Logic/integrationAccounts' --query "[?sku.name == 'Free' && !starts_with(name, 'intacc-aimartifactstore-')].{Name:name, Location:location}" --output table

	# Test if we have any Free SKU Integration Account instances that don't appear to be part of the tool
	if ( $ExistingFreeIntAccounts -ne '' -and $ExistingFreeIntAccounts -notlike '*intacc-aimartifactstore-*')
	{
		$haveWarnings = 'true'
		Write-Host "Step 6: Warning: There are Free SKU App Integration Account instances deployed." -ForegroundColor Yellow
		Write-Host "There are Integration Accounts using the Free SKU deployed to this subscription" -ForegroundColor $defaultForegroundColour
		Write-Host "which don't appear to have been deployed by the BTS Migrator tool." -ForegroundColor $defaultForegroundColour
		Write-Host ""
		Write-Host "If you run the tool using the same region as used by one of these Integration Accounts, " -ForegroundColor $defaultForegroundColour
		Write-Host "then the deployment scripts will likely fail as you can only have " -ForegroundColor $defaultForegroundColour
		Write-Host "one Free SKU Integration Account instance per region per subscription." -ForegroundColor $defaultForegroundColour
		Write-Host ""
		Write-Host "Existing Free SKU Integration accounts:" -ForegroundColor $defaultForegroundColour
		Write-Host ""
		$ExistingFreeIntAccounts | Format-Table | Out-String | Write-Host -ForegroundColor $defaultForegroundColour
	}
	else
	{    
		Write-Host "Step 6: Success: There are no conflicting Free SKU Integration Account instances deployed." -ForegroundColor Green
		Write-Host ""
	}

	# Test if we were successful
	if ( $haveErrors -eq 'true' )
	{
		Write-Host "The deployment scripts will probably fail with errors (see errors and warnings above)." -ForegroundColor Red
		Write-Host ""
		exit
	}
	elseif ( $haveWarnings -eq 'true' )
	{
		Write-Host "The deployment scripts will probably succeed (see warnings above)." -ForegroundColor Yellow
		Write-Host ""
	}
	else
	{
		Write-Host "Excellent news, the deployment scripts should run with no errors." -ForegroundColor Green
		Write-Host ""
	}

	$continue = Read-Host "Would you like to continue with deployment? (Y or N)"
	if ( $continue -ne "Y" )
	{
		Write-Host "Exiting deployment script at user request." -ForegroundColor Red
		Write-Host ""
		exit
	}

	Write-Host "Starting deployment of Azure Resources to subscription '$currentSubscription' ($subscriptionId)" -ForegroundColor $defaultForegroundColour
}
else
{
	Write-Host "Starting deployment of Azure Resources to current subscription, in unattended mode" -ForegroundColor $defaultForegroundColour
}
Write-Host ""

# If we're in UI mode, assign a stopwatch so we can output the elapsed runtime
if ($runUnattended -ne 1)
{
	$stopwatch = [System.Diagnostics.Stopwatch]::StartNew()
}# Read in the resources.
$filePaths = @("$PSScriptRoot//Deploy-All.bat",
    "$PSScriptRoot//Deploy-All-Unattended.bat",
    "$PSScriptRoot//TearDown-All.bat",
    "$PSScriptRoot//Deploy-All.ps1",
    "$PSScriptRoot//TearDown-All.ps1",
    "$PSScriptRoot/messagebus/configmanager/Deploy-40-ConfigManager-ApiManagement.ps1",
    "$PSScriptRoot/messagebus/configmanager/New-ConfigManager-ApiManagement.ps1",
    "$PSScriptRoot/messagebus/configmanager/TearDown-40-ConfigManager-ApiManagement.ps1",
    "$PSScriptRoot/messagebus/configmanager/Remove-ConfigManager-ApiManagement.ps1",
    "$PSScriptRoot/messagebus/messagebusgroup/Deploy-10-MessageBusGroup.ps1",
    "$PSScriptRoot/messagebus/messagebusgroup/New-MessageBusGroup.ps1",
    "$PSScriptRoot/messagebus/messagebusgroup/TearDown-10-MessageBusGroup.ps1",
    "$PSScriptRoot/messagebus/messagebusgroup/Remove-MessageBusGroup.ps1",
    "$PSScriptRoot/messagebus/messagebusops/Deploy-20-MessageBusOps-AppInsights.ps1",
    "$PSScriptRoot/messagebus/messagebusops/New-MessageBusOps-AppInsights.ps1",
    "$PSScriptRoot/messagebus/messagebusops/TearDown-20-MessageBusOps-AppInsights.ps1",
    "$PSScriptRoot/messagebus/messagebusops/Remove-MessageBusOps-AppInsights.ps1",
    "$PSScriptRoot/messagebus/messagebusservice/Deploy-5-MessageBusService-Role.ps1",
    "$PSScriptRoot/messagebus/messagebusservice/New-MessageBusService-Role.ps1",
    "$PSScriptRoot/messagebus/messagebusservice/TearDown-5-MessageBusService-Role.ps1",
    "$PSScriptRoot/messagebus/messagebusservice/Remove-MessageBusService-Role.ps1",
    "$PSScriptRoot/messagebus/messagebusservice/Deploy-30-MessageBusService-ApiManagement.ps1",
    "$PSScriptRoot/messagebus/messagebusservice/New-MessageBusService-ApiManagement.ps1",
    "$PSScriptRoot/messagebus/messagebusservice/TearDown-30-MessageBusService-ApiManagement.ps1",
    "$PSScriptRoot/messagebus/messagebusservice/Remove-MessageBusService-ApiManagement.ps1",
    "$PSScriptRoot/messagebus/messagebusservice/Deploy-30-MessageBusService-AppService.ps1",
    "$PSScriptRoot/messagebus/messagebusservice/New-MessageBusService-AppService.ps1",
    "$PSScriptRoot/messagebus/messagebusservice/TearDown-30-MessageBusService-AppService.ps1",
    "$PSScriptRoot/messagebus/messagebusservice/Remove-MessageBusService-AppService.ps1",
    "$PSScriptRoot/messagebus/messagebusservice/Deploy-20-MessageBusService-StorageAccount.ps1",
    "$PSScriptRoot/messagebus/messagebusservice/New-MessageBusService-StorageAccount.ps1",
    "$PSScriptRoot/messagebus/messagebusservice/TearDown-20-MessageBusService-StorageAccount.ps1",
    "$PSScriptRoot/messagebus/messagebusservice/Remove-MessageBusService-StorageAccount.ps1",
    "$PSScriptRoot/messagebus/messagebusservice/Deploy-35-MessageBusService-ApiManagement-RoleAssignment.ps1",
    "$PSScriptRoot/messagebus/messagebusservice/New-MessageBusService-ApiManagement-RoleAssignment.ps1",
    "$PSScriptRoot/messagebus/messagebusservice/TearDown-35-MessageBusService-ApiManagement-RoleAssignment.ps1",
    "$PSScriptRoot/messagebus/messagebusservice/Remove-MessageBusService-ApiManagement-RoleAssignment.ps1",
    "$PSScriptRoot/messagebus/workflows/configcacheupdater/Deploy-90-ConfigCacheUpdater-LogicApp-Disabled.ps1",
    "$PSScriptRoot/messagebus/workflows/configcacheupdater/Deploy-110-ConfigCacheUpdater-LogicApp-Enabled.ps1",
    "$PSScriptRoot/messagebus/workflows/configcacheupdater/New-ConfigCacheUpdater-LogicApp.ps1",
    "$PSScriptRoot/messagebus/workflows/configcacheupdater/TearDown-90-ConfigCacheUpdater-LogicApp.ps1",
    "$PSScriptRoot/messagebus/workflows/configcacheupdater/Remove-ConfigCacheUpdater-LogicApp.ps1",
    "$PSScriptRoot/messagebus/workflows/configcacheupdater/Deploy-80-EventGridSubscribe-ApiConnection.ps1",
    "$PSScriptRoot/messagebus/workflows/configcacheupdater/New-EventGridSubscribe-ApiConnection.ps1",
    "$PSScriptRoot/messagebus/workflows/configcacheupdater/TearDown-80-EventGridSubscribe-ApiConnection.ps1",
    "$PSScriptRoot/messagebus/workflows/configcacheupdater/Remove-EventGridSubscribe-ApiConnection.ps1",
    "$PSScriptRoot/messagebus/workflows/configcacheupdater/Deploy-100-AppConfigStore-RoleAssignment.ps1",
    "$PSScriptRoot/messagebus/workflows/configcacheupdater/New-AppConfigStore-RoleAssignment.ps1",
    "$PSScriptRoot/messagebus/workflows/configcacheupdater/TearDown-100-AppConfigStore-RoleAssignment.ps1",
    "$PSScriptRoot/messagebus/workflows/configcacheupdater/Remove-AppConfigStore-RoleAssignment.ps1",
    "$PSScriptRoot/messagebus/messagingmanager/Deploy-50-MessagingManager-Function.ps1",
    "$PSScriptRoot/messagebus/messagingmanager/New-MessagingManager-Function.ps1",
    "$PSScriptRoot/messagebus/messagingmanager/TearDown-50-MessagingManager-Function.ps1",
    "$PSScriptRoot/messagebus/messagingmanager/Remove-MessagingManager-Function.ps1",
    "$PSScriptRoot/messagebus/messagingmanager/Microsoft.AzureIntegrationMigration.FunctionApp.MessagingManager.zip",
    "$PSScriptRoot/messagebus/messagingmanager/Deploy-60-MessagingManager-ApiManagement.ps1",
    "$PSScriptRoot/messagebus/messagingmanager/New-MessagingManager-ApiManagement.ps1",
    "$PSScriptRoot/messagebus/messagingmanager/TearDown-60-MessagingManager-ApiManagement.ps1",
    "$PSScriptRoot/messagebus/messagingmanager/Remove-MessagingManager-ApiManagement.ps1",
    "$PSScriptRoot/messagebus/routingmanager/Deploy-50-RoutingManager-Function.ps1",
    "$PSScriptRoot/messagebus/routingmanager/New-RoutingManager-Function.ps1",
    "$PSScriptRoot/messagebus/routingmanager/TearDown-50-RoutingManager-Function.ps1",
    "$PSScriptRoot/messagebus/routingmanager/Remove-RoutingManager-Function.ps1",
    "$PSScriptRoot/messagebus/routingmanager/Microsoft.AzureIntegrationMigration.FunctionApp.RoutingManager.zip",
    "$PSScriptRoot/messagebus/routingmanager/Deploy-60-RoutingManager-ApiManagement.ps1",
    "$PSScriptRoot/messagebus/routingmanager/New-RoutingManager-ApiManagement.ps1",
    "$PSScriptRoot/messagebus/routingmanager/TearDown-60-RoutingManager-ApiManagement.ps1",
    "$PSScriptRoot/messagebus/routingmanager/Remove-RoutingManager-ApiManagement.ps1",
    "$PSScriptRoot/messagebus/workflows/routingsliprouter/Deploy-80-RoutingSlipRouter-LogicApp.ps1",
    "$PSScriptRoot/messagebus/workflows/routingsliprouter/New-RoutingSlipRouter-LogicApp.ps1",
    "$PSScriptRoot/messagebus/workflows/routingsliprouter/TearDown-80-RoutingSlipRouter-LogicApp.ps1",
    "$PSScriptRoot/messagebus/workflows/routingsliprouter/Remove-RoutingSlipRouter-LogicApp.ps1",
    "$PSScriptRoot/messagebus/routingstore/Deploy-20-RoutingStore-AppConfig.ps1",
    "$PSScriptRoot/messagebus/routingstore/New-RoutingStore-AppConfig.ps1",
    "$PSScriptRoot/messagebus/routingstore/TearDown-20-RoutingStore-AppConfig.ps1",
    "$PSScriptRoot/messagebus/routingstore/Remove-RoutingStore-AppConfig.ps1",
    "$PSScriptRoot/messagebus/routingstore/Deploy-15-RoutingStore-KeyVault.ps1",
    "$PSScriptRoot/messagebus/routingstore/New-RoutingStore-KeyVault.ps1",
    "$PSScriptRoot/messagebus/routingstore/TearDown-15-RoutingStore-KeyVault.ps1",
    "$PSScriptRoot/messagebus/routingstore/Remove-RoutingStore-KeyVault.ps1",
    "$PSScriptRoot/messagebus/routingstore/Deploy-40-RoutingStore-ApiManagement.ps1",
    "$PSScriptRoot/messagebus/routingstore/New-RoutingStore-ApiManagement.ps1",
    "$PSScriptRoot/messagebus/routingstore/TearDown-40-RoutingStore-ApiManagement.ps1",
    "$PSScriptRoot/messagebus/routingstore/Remove-RoutingStore-ApiManagement.ps1",
    "$PSScriptRoot/messagebus/artifactstore/Deploy-20-ArtifactStore.ps1",
    "$PSScriptRoot/messagebus/artifactstore/New-ArtifactStore.ps1",
    "$PSScriptRoot/messagebus/artifactstore/TearDown-20-ArtifactStore.ps1",
    "$PSScriptRoot/messagebus/artifactstore/Remove-ArtifactStore.ps1",
    "$PSScriptRoot/applications/biztlakais/group/Deploy-10-ApplicationGroup.ps1",
    "$PSScriptRoot/applications/biztlakais/group/New-ApplicationGroup.ps1",
    "$PSScriptRoot/applications/biztlakais/group/TearDown-10-ApplicationGroup.ps1",
    "$PSScriptRoot/applications/biztlakais/group/Remove-ApplicationGroup.ps1",
    "$PSScriptRoot/applications/biztlakais/group/Deploy-35-MessageBusService-ApiManagement-RoleAssignment.ps1",
    "$PSScriptRoot/applications/biztlakais/group/New-MessageBusService-ApiManagement-RoleAssignment.ps1",
    "$PSScriptRoot/applications/biztlakais/group/TearDown-35-MessageBusService-ApiManagement-RoleAssignment.ps1",
    "$PSScriptRoot/applications/biztlakais/group/Remove-MessageBusService-ApiManagement-RoleAssignment.ps1",
    "$PSScriptRoot/applications/systemapplication/group/Deploy-10-ApplicationGroup.ps1",
    "$PSScriptRoot/applications/systemapplication/group/New-ApplicationGroup.ps1",
    "$PSScriptRoot/applications/systemapplication/group/TearDown-10-ApplicationGroup.ps1",
    "$PSScriptRoot/applications/systemapplication/group/Remove-ApplicationGroup.ps1",
    "$PSScriptRoot/applications/systemapplication/group/Deploy-35-MessageBusService-ApiManagement-RoleAssignment.ps1",
    "$PSScriptRoot/applications/systemapplication/group/New-MessageBusService-ApiManagement-RoleAssignment.ps1",
    "$PSScriptRoot/applications/systemapplication/group/TearDown-35-MessageBusService-ApiManagement-RoleAssignment.ps1",
    "$PSScriptRoot/applications/systemapplication/group/Remove-MessageBusService-ApiManagement-RoleAssignment.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/flatfilemessageprocessor/Deploy-90-FlatFileMessageProcessor-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/flatfilemessageprocessor/New-FlatFileMessageProcessor-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/flatfilemessageprocessor/TearDown-90-FlatFileMessageProcessor-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/flatfilemessageprocessor/Remove-FlatFileMessageProcessor-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/jsondecoder/Deploy-90-JsonDecoder-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/jsondecoder/New-JsonDecoder-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/jsondecoder/TearDown-90-JsonDecoder-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/jsondecoder/Remove-JsonDecoder-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/jsonencoder/Deploy-90-JsonEncoder-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/jsonencoder/New-JsonEncoder-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/jsonencoder/TearDown-90-JsonEncoder-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/jsonencoder/Remove-JsonEncoder-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/xmlenvelopewrapper/Deploy-85-XmlEnvelopeWrapper-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/xmlenvelopewrapper/New-XmlEnvelopeWrapper-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/xmlenvelopewrapper/TearDown-85-XmlEnvelopeWrapper-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/xmlenvelopewrapper/Remove-XmlEnvelopeWrapper-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/xmlmessageprocessor/Deploy-85-XmlMessageProcessor-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/xmlmessageprocessor/New-XmlMessageProcessor-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/xmlmessageprocessor/TearDown-85-XmlMessageProcessor-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/xmlmessageprocessor/Remove-XmlMessageProcessor-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/xmlmessagetranslator/Deploy-85-XmlMessageTranslator-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/xmlmessagetranslator/New-XmlMessageTranslator-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/xmlmessagetranslator/TearDown-85-XmlMessageTranslator-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/xmlmessagetranslator/Remove-XmlMessageTranslator-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/xmlmessagevalidator/Deploy-85-XmlMessageValidator-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/xmlmessagevalidator/New-XmlMessageValidator-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/xmlmessagevalidator/TearDown-85-XmlMessageValidator-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/xmlmessagevalidator/Remove-XmlMessageValidator-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/endpoints/messageconstructor/Deploy-85-MessageConstructor-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/endpoints/messageconstructor/New-MessageConstructor-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/endpoints/messageconstructor/TearDown-85-MessageConstructor-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/endpoints/messageconstructor/Remove-MessageConstructor-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/workflows/messageresponsehandler/Deploy-85-MessageResponseHandler-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/workflows/messageresponsehandler/New-MessageResponseHandler-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/workflows/messageresponsehandler/TearDown-85-MessageResponseHandler-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/workflows/messageresponsehandler/Remove-MessageResponseHandler-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/workflows/messageresponsehandler/Deploy-80-MessageResponseHandlerServiceBus-ApiConnection.ps1",
    "$PSScriptRoot/applications/systemapplication/workflows/messageresponsehandler/New-MessageResponseHandlerServiceBus-ApiConnection.ps1",
    "$PSScriptRoot/applications/systemapplication/workflows/messageresponsehandler/Remove-MessageResponseHandlerServiceBus-ApiConnection.ps1",
    "$PSScriptRoot/applications/systemapplication/workflows/messageresponsehandler/TearDown-80-MessageResponseHandlerServiceBus-ApiConnection.ps1",
    "$PSScriptRoot/applications/systemapplication/workflows/messagesuspendprocessor/Deploy-85-MessageSuspendProcessor-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/workflows/messagesuspendprocessor/New-MessageSuspendProcessor-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/workflows/messagesuspendprocessor/TearDown-85-MessageSuspendProcessor-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/workflows/messagesuspendprocessor/Remove-MessageSuspendProcessor-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/workflows/messagesuspendprocessor/Deploy-80-MessageSuspendProcessorServiceBus-ApiConnection.ps1",
    "$PSScriptRoot/applications/systemapplication/workflows/messagesuspendprocessor/New-MessageSuspendProcessorServiceBus-ApiConnection.ps1",
    "$PSScriptRoot/applications/systemapplication/workflows/messagesuspendprocessor/Remove-MessageSuspendProcessorServiceBus-ApiConnection.ps1",
    "$PSScriptRoot/applications/systemapplication/workflows/messagesuspendprocessor/TearDown-80-MessageSuspendProcessorServiceBus-ApiConnection.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/contentdemoter/Deploy-90-ContentDemoter-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/contentdemoter/New-ContentDemoter-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/contentdemoter/TearDown-90-ContentDemoter-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/contentdemoter/Remove-ContentDemoter-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/endpoints/filedatagateway/Deploy-30-DataGateway.ps1",
    "$PSScriptRoot/applications/systemapplication/endpoints/filedatagateway/New-DataGateway.ps1",
    "$PSScriptRoot/applications/systemapplication/endpoints/filedatagateway/TearDown-30-DataGateway.ps1",
    "$PSScriptRoot/applications/systemapplication/endpoints/filedatagateway/Remove-DataGateway.ps1",
    "$PSScriptRoot/applications/systemapplication/endpoints/filedatagateway/datagateway.onpremisedatagateway.dev.psparameters.json",
    "$PSScriptRoot/applications/biztlakais/messages/schemas/cryptotransaction/Deploy-100-Schema.ps1",
    "$PSScriptRoot/applications/biztlakais/messages/schemas/cryptotransaction/New-Schema.ps1",
    "$PSScriptRoot/applications/biztlakais/messages/schemas/cryptotransaction/Remove-Schema.ps1",
    "$PSScriptRoot/applications/biztlakais/messages/schemas/cryptotransaction/TearDown-100-Schema.ps1",
    "$PSScriptRoot/applications/biztlakais/messages/schemas/blockchainreport/Deploy-100-Schema.ps1",
    "$PSScriptRoot/applications/biztlakais/messages/schemas/blockchainreport/New-Schema.ps1",
    "$PSScriptRoot/applications/biztlakais/messages/schemas/blockchainreport/Remove-Schema.ps1",
    "$PSScriptRoot/applications/biztlakais/messages/schemas/blockchainreport/TearDown-100-Schema.ps1",
    "$PSScriptRoot/applications/biztlakais/messages/transforms/cryptotransaction2blockchainreport/Deploy-120-Map.ps1",
    "$PSScriptRoot/applications/biztlakais/messages/transforms/cryptotransaction2blockchainreport/New-Map.ps1",
    "$PSScriptRoot/applications/biztlakais/messages/transforms/cryptotransaction2blockchainreport/Remove-Map.ps1",
    "$PSScriptRoot/applications/biztlakais/messages/transforms/cryptotransaction2blockchainreport/TearDown-120-Map.ps1",
    "$PSScriptRoot/applications/biztlakais/messages/schemas/errors/Deploy-100-Schema.ps1",
    "$PSScriptRoot/applications/biztlakais/messages/schemas/errors/New-Schema.ps1",
    "$PSScriptRoot/applications/biztlakais/messages/schemas/errors/Remove-Schema.ps1",
    "$PSScriptRoot/applications/biztlakais/messages/schemas/errors/TearDown-100-Schema.ps1",
    "$PSScriptRoot/applications/biztlakais/messages/transforms/cryptotransaction2errors/Deploy-120-Map.ps1",
    "$PSScriptRoot/applications/biztlakais/messages/transforms/cryptotransaction2errors/New-Map.ps1",
    "$PSScriptRoot/applications/biztlakais/messages/transforms/cryptotransaction2errors/Remove-Map.ps1",
    "$PSScriptRoot/applications/biztlakais/messages/transforms/cryptotransaction2errors/TearDown-120-Map.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messagebox/namespace/Deploy-15-Namespace-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messagebox/namespace/New-Namespace-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messagebox/namespace/TearDown-15-Namespace-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messagebox/namespace/Remove-Namespace-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messagebox/Deploy-20-TopicChannel-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messagebox/New-TopicChannel-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messagebox/TearDown-20-TopicChannel-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messagebox/Remove-TopicChannel-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messagebox/subscriptions/sendport5/Deploy-30-TopicChannelSubscription-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messagebox/subscriptions/sendport5/New-TopicChannelSubscription-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messagebox/subscriptions/sendport5/Remove-TopicChannelSubscription-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messagebox/subscriptions/sendport5/TearDown-30-TopicChannelSubscription-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messagebox/subscriptions/error/Deploy-30-TopicChannelSubscription-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messagebox/subscriptions/error/New-TopicChannelSubscription-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messagebox/subscriptions/error/Remove-TopicChannelSubscription-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messagebox/subscriptions/error/TearDown-30-TopicChannelSubscription-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messagebox/subscriptions/biztlakaismigration-crytporeport/Deploy-30-TopicChannelSubscription-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messagebox/subscriptions/biztlakaismigration-crytporeport/New-TopicChannelSubscription-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messagebox/subscriptions/biztlakaismigration-crytporeport/Remove-TopicChannelSubscription-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messagebox/subscriptions/biztlakaismigration-crytporeport/TearDown-30-TopicChannelSubscription-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messageboxresponse/Deploy-20-TopicChannel-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messageboxresponse/New-TopicChannel-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messageboxresponse/TearDown-20-TopicChannel-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/messageboxresponse/Remove-TopicChannel-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/suspendqueue/Deploy-20-TopicChannel-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/suspendqueue/New-TopicChannel-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/suspendqueue/TearDown-20-TopicChannel-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/channels/suspendqueue/Remove-TopicChannel-ServiceBus.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/contentpromoter/Deploy-90-ContentPromoter-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/contentpromoter/New-ContentPromoter-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/contentpromoter/TearDown-90-ContentPromoter-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/contentpromoter/Remove-ContentPromoter-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/topicpublisher/Deploy-90-TopicPublisher-ApiConnection.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/topicpublisher/New-TopicPublisher-ApiConnection.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/topicpublisher/TearDown-90-TopicPublisher-ApiConnection.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/topicpublisher/Remove-TopicPublisher-ApiConnection.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/topicpublisher/Deploy-95-TopicPublisher-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/topicpublisher/New-TopicPublisher-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/topicpublisher/TearDown-95-TopicPublisher-LogicApp.ps1",
    "$PSScriptRoot/applications/systemapplication/intermediaries/topicpublisher/Remove-TopicPublisher-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/topicsubscribersendport5/Deploy-100-TopicSubscriber-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/topicsubscribersendport5/New-TopicSubscriber-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/topicsubscribersendport5/Remove-TopicSubscriber-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/topicsubscribersendport5/TearDown-100-TopicSubscriber-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/topicsubscribersendport5/Deploy-105-TopicSubscriber-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/topicsubscribersendport5/New-TopicSubscriber-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/topicsubscribersendport5/Remove-TopicSubscriber-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/topicsubscribersendport5/TearDown-105-TopicSubscriber-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingslips/biztlakais.sendport5/Deploy-105-RoutingSlip-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingslips/biztlakais.sendport5/New-RoutingSlip-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingslips/biztlakais.sendport5/TearDown-105-RoutingSlip-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingslips/biztlakais.sendport5/Remove-RoutingSlip-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/configurationentries/biztlakais.sendport5/Deploy-105-ConfigurationEntry-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/configurationentries/biztlakais.sendport5/New-ConfigurationEntry-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/configurationentries/biztlakais.sendport5/TearDown-105-ConfigurationEntry-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/configurationentries/biztlakais.sendport5/Remove-ConfigurationEntry-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingproperties/routes/biztlakais.sendport5/Deploy-105-RoutingProperties-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingproperties/routes/biztlakais.sendport5/New-RoutingProperties-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingproperties/routes/biztlakais.sendport5/TearDown-105-RoutingProperties-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingproperties/routes/biztlakais.sendport5/Remove-RoutingProperties-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/topicsubscribererror/Deploy-100-TopicSubscriber-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/topicsubscribererror/New-TopicSubscriber-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/topicsubscribererror/Remove-TopicSubscriber-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/topicsubscribererror/TearDown-100-TopicSubscriber-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/topicsubscribererror/Deploy-105-TopicSubscriber-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/topicsubscribererror/New-TopicSubscriber-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/topicsubscribererror/Remove-TopicSubscriber-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/topicsubscribererror/TearDown-105-TopicSubscriber-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingslips/biztlakais.error/Deploy-105-RoutingSlip-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingslips/biztlakais.error/New-RoutingSlip-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingslips/biztlakais.error/TearDown-105-RoutingSlip-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingslips/biztlakais.error/Remove-RoutingSlip-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/configurationentries/biztlakais.error/Deploy-105-ConfigurationEntry-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/configurationentries/biztlakais.error/New-ConfigurationEntry-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/configurationentries/biztlakais.error/TearDown-105-ConfigurationEntry-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/configurationentries/biztlakais.error/Remove-ConfigurationEntry-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingproperties/routes/biztlakais.error/Deploy-105-RoutingProperties-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingproperties/routes/biztlakais.error/New-RoutingProperties-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingproperties/routes/biztlakais.error/TearDown-105-RoutingProperties-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingproperties/routes/biztlakais.error/Remove-RoutingProperties-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/biztlakaismigration-crytporeport/Deploy-100-ProcessManagerServiceBus-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/biztlakaismigration-crytporeport/New-ProcessManagerServiceBus-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/biztlakaismigration-crytporeport/Remove-ProcessManagerServiceBus-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/biztlakaismigration-crytporeport/TearDown-100-ProcessManagerServiceBus-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/config/configurationentries/biztlakais.biztlakaismigration.crytporeport/Deploy-105-ConfigurationEntry-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/configurationentries/biztlakais.biztlakaismigration.crytporeport/New-ConfigurationEntry-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/configurationentries/biztlakais.biztlakaismigration.crytporeport/TearDown-105-ConfigurationEntry-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/configurationentries/biztlakais.biztlakaismigration.crytporeport/Remove-ConfigurationEntry-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/biztlakaismigration-crytporeport/Deploy-105-ProcessManager-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/biztlakaismigration-crytporeport/New-ProcessManager-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/biztlakaismigration-crytporeport/Remove-ProcessManager-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/intermediaries/biztlakaismigration-crytporeport/TearDown-105-ProcessManager-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingslips/biztlakais.biztlakaismigration.crytporeport/Deploy-105-RoutingSlip-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingslips/biztlakais.biztlakaismigration.crytporeport/New-RoutingSlip-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingslips/biztlakais.biztlakaismigration.crytporeport/TearDown-105-RoutingSlip-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingslips/biztlakais.biztlakaismigration.crytporeport/Remove-RoutingSlip-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/bizaaismigration_receivelocation/Deploy-105-FileReceiveAdapter-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/bizaaismigration_receivelocation/New-FileReceiveAdapter-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/bizaaismigration_receivelocation/Remove-FileReceiveAdapter-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/bizaaismigration_receivelocation/TearDown-105-FileReceiveAdapter-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/bizaaismigration_receivelocation/Deploy-100-FileReceiveAdapterFileSystem-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/bizaaismigration_receivelocation/New-FileReceiveAdapterFileSystem-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/bizaaismigration_receivelocation/Remove-FileReceiveAdapterFileSystem-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/bizaaismigration_receivelocation/TearDown-100-FileReceiveAdapterFileSystem-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/bizaaismigration_receivelocation/Deploy-100-FileReceiveAdapterServiceBus-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/bizaaismigration_receivelocation/New-FileReceiveAdapterServiceBus-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/bizaaismigration_receivelocation/Remove-FileReceiveAdapterServiceBus-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/bizaaismigration_receivelocation/TearDown-100-FileReceiveAdapterServiceBus-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingslips/biztlakais.bizaaismigration_receive.bizaaismigration_receivelocation/Deploy-105-RoutingSlip-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingslips/biztlakais.bizaaismigration_receive.bizaaismigration_receivelocation/New-RoutingSlip-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingslips/biztlakais.bizaaismigration_receive.bizaaismigration_receivelocation/TearDown-105-RoutingSlip-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingslips/biztlakais.bizaaismigration_receive.bizaaismigration_receivelocation/Remove-RoutingSlip-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/configurationentries/biztlakais.bizaaismigration_receive.bizaaismigration_receivelocation/Deploy-105-ConfigurationEntry-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/configurationentries/biztlakais.bizaaismigration_receive.bizaaismigration_receivelocation/New-ConfigurationEntry-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/configurationentries/biztlakais.bizaaismigration_receive.bizaaismigration_receivelocation/TearDown-105-ConfigurationEntry-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/configurationentries/biztlakais.bizaaismigration_receive.bizaaismigration_receivelocation/Remove-ConfigurationEntry-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingproperties/routes/biztlakais.bizaaismigration_receive.bizaaismigration_receivelocation/Deploy-105-RoutingProperties-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingproperties/routes/biztlakais.bizaaismigration_receive.bizaaismigration_receivelocation/New-RoutingProperties-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingproperties/routes/biztlakais.bizaaismigration_receive.bizaaismigration_receivelocation/TearDown-105-RoutingProperties-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/config/routingproperties/routes/biztlakais.bizaaismigration_receive.bizaaismigration_receivelocation/Remove-RoutingProperties-AppConfig.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/sendport5/Deploy-105-FileSendAdapter-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/sendport5/New-FileSendAdapter-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/sendport5/Remove-FileSendAdapter-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/sendport5/TearDown-105-FileSendAdapter-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/sendport5/Deploy-100-FileSendAdapter-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/sendport5/New-FileSendAdapter-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/sendport5/Remove-FileSendAdapter-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/sendport5/TearDown-100-FileSendAdapter-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/error/Deploy-105-FileSendAdapter-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/error/New-FileSendAdapter-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/error/Remove-FileSendAdapter-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/error/TearDown-105-FileSendAdapter-LogicApp.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/error/Deploy-100-FileSendAdapter-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/error/New-FileSendAdapter-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/error/Remove-FileSendAdapter-ApiConnection.ps1",
    "$PSScriptRoot/applications/biztlakais/endpoints/error/TearDown-100-FileSendAdapter-ApiConnection.ps1")

$templates = @()

# Extract the priority and file name from the template full path.
$filePaths | ForEach-Object {
    $fileName = Split-Path $_ -leaf

    if ($fileName -match 'Deploy-([0-9]*?)-(?:.*.ps1)' ) {
        $priority = $Matches.1
        $templates += [Template]::new($fileName, $_, $priority)
    }
}# Run the scripts in ascending order.
# Filter based on the min and max priority.
$templates | Where-Object { $_.Priority -ge $minDeploymentPriority } | Where-Object { $_.Priority -le $maxDeploymentPriority } | Sort-Object { $_.Priority } | Select-Object -ExpandProperty FullPath -Unique | ForEach-Object {
    New-DeploymentWithRetry $_
}

# If we're in UI mode, output the elapsed time
if ($runUnattended -ne 1)
{
	$stopwatch.Stop()
	Write-Host ("Deployment elapsed time: {0:d2}:{1:d2}:{2:d2} (hh:mm:ss)" -f $stopwatch.Elapsed.Hours, $stopwatch.Elapsed.Minutes, $stopwatch.Elapsed.Seconds) -ForegroundColor $defaultForegroundColour
}