# SlimPK2
A PK2 Framework for Silkroad Online archives.
This framework gives you the abilities to read and write data from and to a .pk2 archive.

# The MIT License (MIT)
Copyright (c) 2016 WimBeam

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

# Quick guide

## General information
SlimPK2 supports 3 modes to work with a .pk2 file archive:

* Index - Will create a special index of files, to get access to path variables (Less efficient but easy to use)
* BlockIndex - Will create an index "as-is" without special classes for files/directories.
* FreeBrowse - Will not create any index at all. You can now use PK2Archive.GetNavigator() to navigate through the archive. (fastest)

## How to
You can initialize a new PK2 archive using the following code:

var PK2 = new PK2Archive("myPath", PK2Config.GetDefault());

Feel free to check out the PK2Config.cs class. This class alows you to provide more parameters such as "key", "mode" and "base key".

## Using the navigator
As explained above, the PK2Navigator class (PK2Archive.GetNavigator()) allows you to freely browse the PK2 archive.
That means, that only the root block is being loaded at the beginning to grant a default location. You can not access any PK2 index at all!
The Navigator class has many functions that allow you to browse through the PK2.

## Create new files
Use PK2Entry.Create() to create new items within the PK2.

## Delete/rename files
The following example can also be used to delete/rename directories!
PK2Archive.GetFile("path").Delete();
PK2Archive.GetDirectory("path").Rename("new name");

## Known bugs
I did not test everything. It could be that it's not possible to create items in the root directory at the moment.
If you find any other bugs feel free to create a pull request. I don't give you ANY support!
