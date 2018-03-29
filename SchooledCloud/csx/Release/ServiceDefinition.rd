<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="SchooledCloud" generation="1" functional="0" release="0" Id="76376937-7d45-4c81-9cbc-78bc35d8a707" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="SchooledCloudGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="SchooledSite:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/SchooledCloud/SchooledCloudGroup/LB:SchooledSite:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="SchooledSite:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/SchooledCloud/SchooledCloudGroup/MapSchooledSite:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="SchooledSiteInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/SchooledCloud/SchooledCloudGroup/MapSchooledSiteInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:SchooledSite:Endpoint1">
          <toPorts>
            <inPortMoniker name="/SchooledCloud/SchooledCloudGroup/SchooledSite/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapSchooledSite:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/SchooledCloud/SchooledCloudGroup/SchooledSite/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapSchooledSiteInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/SchooledCloud/SchooledCloudGroup/SchooledSiteInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="SchooledSite" generation="1" functional="0" release="0" software="C:\Users\Khan\Documents\Schooled\SchooledCloud\csx\Release\roles\SchooledSite" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;SchooledSite&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;SchooledSite&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/SchooledCloud/SchooledCloudGroup/SchooledSiteInstances" />
            <sCSPolicyUpdateDomainMoniker name="/SchooledCloud/SchooledCloudGroup/SchooledSiteUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/SchooledCloud/SchooledCloudGroup/SchooledSiteFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="SchooledSiteUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="SchooledSiteFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="SchooledSiteInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="97a62210-f043-4d29-bc09-5f03dc1285e2" ref="Microsoft.RedDog.Contract\ServiceContract\SchooledCloudContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="2364d4a6-a90c-444f-8737-ab45e7854ae0" ref="Microsoft.RedDog.Contract\Interface\SchooledSite:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/SchooledCloud/SchooledCloudGroup/SchooledSite:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>