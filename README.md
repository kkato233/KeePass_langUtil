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

