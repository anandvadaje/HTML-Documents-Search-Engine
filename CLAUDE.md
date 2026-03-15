# CLAUDE.md — HTML Documents Search Engine

This file provides guidance for AI assistants working in this repository.

---

## Project Overview

**HTML Documents Search Engine** is a Windows desktop application (C# / .NET Framework 4.5.2) that implements a probabilistic search engine over a pre-indexed corpus of HTML documents. The ranking model is the **Query Likelihood Model** (smoothed with Jelinek-Mercer smoothing). The UI is built with Windows Forms using the **MetroFramework** library for Metro-style styling.

The corpus is pre-processed and stored as CSV files; no indexing step is performed at runtime.

---

## Repository Structure

```
/
├── README.md
├── CLAUDE.md                              ← this file
├── HTML Documents Search Engine.sln       ← Visual Studio solution
└── HTML Documents Search Engine/          ← sole project
    ├── HTML Documents Search Engine.csproj
    ├── App.config
    ├── Runner.cs                          ← entry point (Main)
    ├── SearchForm.cs                      ← UI event handlers
    ├── SearchForm.Designer.cs             ← auto-generated; DO NOT edit manually
    ├── SearchForm.resx                    ← form resources
    ├── Logic.cs                           ← search algorithm & ranking
    ├── DataCollection.cs                  ← CSV loading / data initialisation
    ├── SearchDictionary.cs                ← DTO: term → CF, DF, offset
    ├── Posting.cs                         ← DTO: docID, TF
    ├── Docs_Info.cs                       ← DTO: headline, length, snippet, path
    ├── Properties/
    │   ├── AssemblyInfo.cs
    │   ├── Resources.resx / Resources.Designer.cs
    │   └── Settings.settings / Settings.Designer.cs
    └── SEDocumentExtraction/              ← pre-processed corpus data
        ├── Dictionary.csv                 ← term | CF | DF | postings-offset
        ├── Postings.csv                   ← docID | TF  (indexed by offset)
        ├── DocsTable.csv                  ← docID | headline | length | snippet | path
        └── Total.csv                      ← single integer: total tokens in collection
```

---

## Technology Stack

| Layer | Technology |
|-------|-----------|
| Language | C# (.NET Framework 4.5.2) |
| UI | Windows Forms + MetroFramework 1.4.0.0 |
| Data storage | CSV files (StreamReader, manual parsing) |
| Collections | `System.Collections.Generic` (`Dictionary<K,V>`, `List<T>`) |
| Ranking | Query Likelihood Model (log-space, Jelinek-Mercer smoothing) |
| Build tool | MSBuild via Visual Studio 2017+ |
| Platform | Windows only (WinExe output) |

---

## Building & Running

### Prerequisites
- Visual Studio 2017 or later (Community edition is fine)
- .NET Framework 4.5.2 SDK
- No package restore needed — MetroFramework DLL is referenced directly

### Build
Open `HTML Documents Search Engine.sln` in Visual Studio and press **F6** (Build Solution).

Build configurations:
| Config | Output |
|--------|--------|
| Debug\|Any CPU | `bin\Debug\HTML Documents Search Engine.exe` |
| Release\|Any CPU | `bin\Release\HTML Documents Search Engine.exe` |

### Run
Press **F5** in Visual Studio, or run the compiled `.exe` directly.

The application uses relative paths to locate the CSV data files:
```
..\..\SEDocumentExtraction\*
```
This means the exe **must** be run from `bin\Debug\` or `bin\Release\` for the relative path to resolve correctly (two levels up lands in the project directory, which contains `SEDocumentExtraction\`).

### No automated tests
There is no test project. Verification is manual via the GUI.

---

## Architecture & Data Flow

```
SearchForm (UI)
    │  user types query + clicks Search
    ▼
Logic.Search(query)
    │  1. Strip HTML tags & punctuation
    │  2. Tokenize on whitespace
    │  3. Stem tokens (suffix rules)
    │  4. Remove stopwords
    │  5. Look up each term in Dictionary
    │  6. Retrieve postings from Postings list
    │  7. Compute Query Likelihood score per document
    │  8. Return top-5 results
    ▼
SearchForm displays results (headline, path, score, snippet)

DataCollection (initialised once at startup)
    ├── Reads Dictionary.csv  → Dictionary<string, SearchDictionary>
    ├── Reads Postings.csv    → List<Posting>
    ├── Reads DocsTable.csv   → Dictionary<int, Docs_Info>
    └── Reads Total.csv       → long collectionSize
```

---

## Key Classes

### `Logic` (`Logic.cs`)
Core search logic. Instantiated once by `SearchForm`.

- `Search(string query) → List<KeyValuePair<Docs_Info, double>>` — full pipeline; returns up to 5 ranked results.
- Stemming: handles `"ies"→"y"`, `"es"→"e"`, trailing `"s"`, and `"ing"` suffixes.
- Stopwords filtered: `the`, `a`, `an`, `and`, `by`, `from`, `of`, `in`, `with`.
- Scoring (Jelinek-Mercer, λ = 0.9):
  ```
  score[d] += log₂(0.9 × (tf / docLength) + 0.1 × (cf / collectionSize))
  ```

### `DataCollection` (`DataCollection.cs`)
Loads the three main CSV files and `Total.csv` at startup.
Public properties: `DictionaryTable`, `PostingsList`, `DocsTable`, `TotalTokens`.

### DTOs
| Class | Fields |
|-------|--------|
| `SearchDictionary` | `cf` (long), `df` (int), `offset` (int) |
| `Posting` | `docID` (int), `tf` (int) |
| `Docs_Info` | `headline`, `length` (int), `snippet`, `path` (all strings/int) |

### `SearchForm` (`SearchForm.cs`)
Thin UI layer. On button click: calls `Logic.Search`, formats and displays results in the MetroTextBox.

### `Runner` (`Runner.cs`)
`static void Main` — standard Windows Forms bootstrap; creates and runs `SearchForm`.

---

## Data Files

Located in `HTML Documents Search Engine/SEDocumentExtraction/`.

| File | Format | Size |
|------|--------|------|
| `Dictionary.csv` | `term,cf,df,offset` | ~231 KB |
| `Postings.csv` | `docID,tf` | ~489 KB |
| `DocsTable.csv` | `docID,headline,length,snippet,path` | ~115 KB |
| `Total.csv` | single integer | 10 bytes |

**Do not modify these files** unless you are re-indexing the corpus. The offset column in `Dictionary.csv` is a line index into `Postings.csv`; changes to either file must stay in sync.

---

## Code Conventions

### Naming
- **PascalCase** for classes and methods: `DataCollection`, `Search()`.
- **camelCase** with underscores for local variables and parameters: `query_input`, `doc_length`.
- UI controls use a `m_` prefix: `m_SearchButton`, `m_ResultTextBox`.
- Note the pre-existing typo in the UI control `m_KeyWorkTextBox` ("KeyWork" instead of "KeyWord") — preserve it to avoid breaking designer bindings.

### Style
- Public fields (no properties) on DTOs — consistent with the existing codebase.
- `StreamReader` with manual `Split(',')` for CSV parsing; no external CSV library.
- Log-base-2 used for scoring (`Math.Log(..., 2)`).

### Files to never edit manually
- `SearchForm.Designer.cs` — regenerated by the Windows Forms designer.
- `Properties/Resources.Designer.cs`, `Properties/Settings.Designer.cs` — auto-generated.

---

## Known Limitations & Technical Debt

- **Hardcoded relative path** for data files (`..\..\SEDocumentExtraction\*`) — breaks if exe is moved.
- **Magic numbers** in scoring (`0.9`, `0.1`) — the smoothing parameter λ is not configurable.
- **No input validation** on the query string; empty queries or very long queries are not guarded against.
- **No error handling** if CSV files are missing or malformed.
- **Regex used as plain strings** — no compiled `Regex` objects; minor performance issue for repeated searches.
- **No tests** — all verification is manual.
- **Windows-only** — MetroFramework and `System.Windows.Forms` prevent cross-platform use.

---

## Development Workflow

1. **Branch:** work on a feature branch, never directly on `master`.
2. **Build:** use Visual Studio (MSBuild); there is no CLI build script.
3. **Test:** run the application manually and search for a few terms to verify ranking behaviour.
4. **Commit:** write concise, descriptive commit messages.
5. **Push:** `git push -u origin <branch-name>`.

### Modifying the ranking algorithm
Changes to `Logic.cs` affect search quality directly. If you adjust the smoothing parameter (λ) or stemming/stopword lists, re-test with several representative queries to confirm score ordering is sensible.

### Adding or changing data files
If you regenerate `Dictionary.csv`, `Postings.csv`, or `DocsTable.csv`, update `Total.csv` to match the new collection size. Verify that offsets in `Dictionary.csv` still point to the correct rows in `Postings.csv`.

### Changing the UI
Edit `SearchForm.cs` only (event handlers, display logic). Use Visual Studio's designer for layout changes — it will regenerate `SearchForm.Designer.cs` automatically.
