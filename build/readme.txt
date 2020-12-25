言語ファイルのビルド方法

..\Translation\DefaultText.xml ファイル が 新しいバージョンに変更になった差分を見て
..\Translation\ja\Japanese.xml ファイル のテキストを同じように差分修正します。

xml2lngx ..\Translation\ja\Japanese.xml  Languages\Japanese.lngx

KeePass.exe を起動して 日本語リソースが正しく適用されている事を確認します。

KeePass.exe は 該当の言語バージョンにあったものに随時差し替えをする。

