# RoFJAA API

The RoFJAA API exposes information relating to Flexi Job Apprenticeship Agencies, the register of which is held in its underlying SQL database.


## How It Works

The API is a simple .Net Core restful API with a SQL Server backend.


## 🚀 Installation

### Pre-Requisites

* A clone of this repository
* A code editor that supports .NetCore 6
* A SQL Server installation
* Storage emulator
* Database project published to local db server

### Config

This services uses the standard Apprenticeship Service configuration. All configuration can be found in the [das-employer-config repository](https://github.com/SkillsFundingAgency/das-employer-config/tree/master/das-rofjaa-api).

Configuration should be added to the local emulated storage using partition key `LOCAL` and RowKey `SFA.DAS.Rofjaa.Api_1.0`, and should resemble the following:

```
{
  "Rofjaa": {
    "ConnectionString": "<local db connection string>"
  },
  "AzureAd": {
    "tenant": "<tenant>",
    "identifier": "<service identifier>"
  }
}
```



## 🔗 External Dependencies

RoFJAA API has no external dependenices.

## Technologies

* .NetCore 6
* Web API
* SQL Server
* Entity Framework
* NLog
* Azure Table Storage
* NUnit
* Moq
* FluentAssertions

