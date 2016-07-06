先确认Web.config中有下面这些项
<configuration>
	<system.web>
		<httpRuntime maxRequestLength="2147483647" shutdownTimeout="300000" maxUrlLength="2097151"/>
	</system.web>
	<system.webServer>
    		<security>
      			<requestFiltering>
        			<requestLimits maxAllowedContentLength="2147483647"></requestLimits>
      			</requestFiltering>
    		</security>
	</system.webServer>
</configuration>

