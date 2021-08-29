# ComicBookAPI
List of endpoint in Comic Book API

## Book Endpoint

### Get all book
> GET api/Book

Sample Response - *Status: 200 Ok*
```json
[
    {
        "Id": "4295d118-e92f-4fe4-aec0-3e21511f78f2",
        "Release_Date": "2021-08-15T21:27:00",
        "Cover": "data:image/png;base64,iVBORw0..",
        "ComicId": "e7e78ee9-32c9-4a30-9f38-34f3978b1d3b",
        "VolumeNumber": 2,
        "IsHave": true
    },
    {
        "Id": "1def8fc6-1aed-48b9-882f-90ff9eefb410",
        "Release_Date": "2021-08-15T21:27:00",
        "Cover": "data:image/png;base64,iVBORw0..",
        "ComicId": "e7e78ee9-32c9-4a30-9f38-34f3978b1d3b",
        "VolumeNumber": 1,
        "IsHave": true
    },
    {
        "Id": "b435f1f4-5f17-4491-bb50-bf6b63b9fafe",
        "Release_Date": "2021-02-01T12:00:00",
        "Cover": "data:image/png;base64,iVBORw0..",
        "ComicId": "6f6ca13d-c145-40e8-a959-31d4274e2093",
        "VolumeNumber": 1,
        "IsHave": true
    }
]
```

### Get book by id
> GET api/Book/{id}

Sample Response - *Status: 200 Ok*
```json
{
    "Release_Date": "2021-08-15T21:27:00",
    "Cover": "data:image/png;base64,iVBORw0..",
    "ComicId": "e7e78ee9-32c9-4a30-9f38-34f3978b1d3b",
    "VolumeNumber": 2,
    "IsHave": true
}
```

### Create book
> POST api/Book

Sample Request
```json
{
    "Release_Date": "2021-08-15T21:27:00",
    "Cover": "data:image/png;base64,iVBORw0..",
    "ComicId": "e7e78ee9-32c9-4a30-9f38-34f3978b1d3b",
    "VolumeNumber": 2,
    "IsHave": true
}
```

Sample Response - *Status: 201 Created*
```json
{
    "Id": "d6c32245-7a4e-40c7-bc42-dc92dc90fe19",
    "Release_Date": "2021-08-15T21:27:00",
    "Cover": "data:image/png;base64,iVBORw0..",
    "ComicId": "e7e78ee9-32c9-4a30-9f38-34f3978b1d3b",
    "VolumeNumber": 2,
    "IsHave": true
}
```

### Update book
> PUT api/Book/{id}

Sample Request
```json
{
    "Id": "d6c32245-7a4e-40c7-bc42-dc92dc90fe19",
    "Release_Date": "2021-08-15T21:27:00",
    "Cover": "data:image/png;base64,iVBORw0..",
    "ComicId": "e7e78ee9-32c9-4a30-9f38-34f3978b1d3b",
    "VolumeNumber": 2,
    "IsHave": true
}
```

Sample Response - *Status: 200 Ok*
```json
{
    "Id": "d6c32245-7a4e-40c7-bc42-dc92dc90fe19",
    "Release_Date": "2021-08-15T21:27:00",
    "Cover": "data:image/png;base64,iVBORw0..",
    "ComicId": "e7e78ee9-32c9-4a30-9f38-34f3978b1d3b",
    "VolumeNumber": 2,
    "IsHave": true
}
```

### Delete book
> PUT api/Book/{id}

Sample Response - *Status: 200 Ok*

## Comic Endpoint

### Get all Comic
> GET api/Comic

Sample Response - *Status: 200 Ok*
```json
[
    {
        "Id": "6f6ca13d-c145-40e8-a959-31d4274e2093",
        "Title": "Title 1",
        "Author": "Author 1",
        "Status": "Completed",
        "TotalVolume": 34
    },
    {
        "Id": "e7e78ee9-32c9-4a30-9f38-34f3978b1d3b",
        "Title": "Title 2",
        "Author": "Author 2",
        "Status": "Publishing",
        "TotalVolume": 96
    },
    {
        "Id": "05ea0833-66d2-46d2-8c9e-3cc6218515ce",
        "Title": "Title 3",
        "Author": "Author 3",
        "Status": "Completed",
        "TotalVolume": 35
    }
]
```

### Get Comic by id
> GET api/Comic/{id}
```json
{
    "Id": "05ea0833-66d2-46d2-8c9e-3cc6218515ce",
    "Title": "Title 3",
    "Author": "Author 3",
    "Status": "Completed",
    "TotalVolume": 35
}
```

### Create Comic
> POST api/Comic

Sample Request
```json
{
    "Title": "Title 4",
    "Author": "Author 4",
    "Status": "Completed",
    "TotalVolume": 1
}
```

Sample Response - *Status: 200 Ok*
```json
{
    "Id": "9b97cf70-8dbc-4836-9374-423e28c240f4",
    "Title": "Title 4",
    "Author": "Author 4",
    "Status": "Completed",
    "TotalVolume": 1
}
```

### Update Comic
> PUT api/Comic/{id}

Sample Request
```json
{
    "Id": "9b97cf70-8dbc-4836-9374-423e28c240f4",
    "Title": "Title 4",
    "Author": "Author 4",
    "Status": "Completed",
    "TotalVolume": 2
}
```

Sample Response - *Status: 200 Ok*
```json
{
    "Id": "9b97cf70-8dbc-4836-9374-423e28c240f4",
    "Title": "Title 4",
    "Author": "Author 4",
    "Status": "Completed",
    "TotalVolume": 2
}
```

### Delete Comic
> PUT api/Comic/{id}

Sample Response - *Status: 200 Ok*

### Search Comic
> POST api/Comic/Search

Sample Request
```json
{
  "Title": "sample string 1",
  "Author": "sample string 2",
  "Status": "sample string 3",
  "TotalVolume": 4
}
```

Sample Response - *Status: 200 Ok*
```json
[
    {
        "Id": "6f6ca13d-c145-40e8-a959-31d4274e2093",
        "Title": "Title 1",
        "Author": "Author 1",
        "Status": "Completed",
        "TotalVolume": 34
    },
    {
        "Id": "e7e78ee9-32c9-4a30-9f38-34f3978b1d3b",
        "Title": "Title 2",
        "Author": "Author 2",
        "Status": "Publishing",
        "TotalVolume": 96
    },
]
```
