PatientTimelineFhir
==================

Example client for connecting to a FHIR REST API that creates a timeline of patient interaction.

The sample code provides a basic MVC UI that allows you to:

* Enter a patient's given and family name
* Retrieve the patient's timeline

Th timeline is made up of [Encounter](http://www.hl7.org/implement/standards/fhir/encounter.html) and [Alert](http://www.hl7.org/implement/standards/fhir/alert.html) Resources from this [Test API](http://hl7connect.healthintersections.com.au/svc/fhir/).

This uses the __Hl7.Fhir__ NuGet package provided by Ewout Kramer ([See here for a good introduction to using FHIR](http://www.slideshare.net/ewoutkramer/hl7-fhir-for-developers))

Dependencies
--------------------------

* ASP.NET C# MVC 4.5
* NuGet
    * Hl7.Fhir
    * Newtonsoft.Json
	* MVC 4.5 standard dependencies