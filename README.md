# KeePass_langUtil
KeePass 言語リソース作成 ユーティリティー

## KeePass で利用する 言語リソースを メンテナンスするためのユーティリティー

KeePass は Langages フォルダの中に 言語リソース `Japanese.lngx` を入れると アプリを日本語化する事ができる。

この `Japanese.lngx` は XML ファイルを Zip Stream 圧縮したものなので

lngx ファイル → XML ファイル
XML ファイル → lngx ファイル

の変換を行うユーティリティーを作成した。

利用例

```
lngx2xml Japanese.lngx Japanese.xml
```

日本語化リソースが XML 形式のファイルに展開される。

この XML ファイルを編集して

```
xml2lngx.exe Japanese.xml Japanese.lngx
```
とすると 日本語リソースを書き換える事ができる。

Translation フォルダの中の DefaultText.xml を 最新の KeePass の DefaultText.xml と比較して その差分を
Translation/ja/Japanese.xml ファイルに 翻訳して差分適用する。

build フォルダを開き 

```
xml2lngx ..\Translation\ja\Japanese.xml  Languages\Japanese.lngx
```
として XML ファイルから 言語リソースファイルを生成して

KeePass.exe を起動して動作確認をする。

KeePass は
https://github.com/kkato233/KeePass
でメンテナンス中

## 新しいバージョン出たときのメンテナンス手順

ソースコードの中から

`Translation\DefaultText.xml`

を取り出して英語版の 言語リソースとして登録

差分が少なければ `Translation\DefaultText.xml` の変更履歴をもとに

`Translation\ja\Japanese.xml`

ファイルを作成する。

差分が大きい場合には

https://keepass.info/translations.html 

にある 言語リソースをダウンロードして利用可能か？確認する。

https://keepass.info/translations.html のページの下の方にある

`TrlUtil` をダウロードして .lngx ファイルを直接編集できる。

編集した結果は `lngx2xml.exe` を使って XML 化して
ソースとして `Translation\ja\Japanese.xml` ファイルに登録する。

## 新しいバージョンが出たときのビルド対応

lngx2xml や xml2lngx は 該当するバージョンの exe や dll が必要。

KeePass を ビルドして生成された
```
KeePass.exe
KeePassLib.dll
```
ファイルを `libs` フォルダに入れてコミットする。


`KeePass_langUtil.sln` を Visual Studio で開いてビルドする。

ビルド結果の build フォルダの生成物は コミットする。




