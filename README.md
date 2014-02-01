SxGoogle - A Simple C# Wrapper for the Google Drive API
===========

Description
--------

SxGoogle is a small C# based wrapper for the Google Drive API which provides developers with a way to authenticate their applications with an end-users Google Drive account along with obtaining an OAUTH Access/Refresh Token so that in future the application can silently access the users Google Drive account. Currently the example provided just shows how to authenticate followed by uploading a file however the application could easily be extended to allow both uploading and downloading and more.

The source code for this was originally written as part of an automated MS SQL Server database backup tool I wrote to automate the backing up and uploading of SQL databases to an external cloud provider such as Google Drive. As I myself had difficulty at first understanding and implementing the Drive API I've decided to release my source code in the hope that if someone else is also struggling to implement the Drive API they will be able to either use my code as an example or extend/build upon what I've created to better suite their requirements.

Currently the application comes in two parts:

1) 'SxGoogle' - This is the main part of the application and the wrapper for the Drive API

2) 'GoogleConnect' - This is an example program with example code on how to authenticate your application with Google Drive along with calling the upload functionality of SxGoogle.

Licence
--------
Copyright (c) 2014 Ashley Hipgrave

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software. 

This project/source and derivative works can not be used as a part of or in 
combination with any code or binarys involed directly or indirectly with the 
social or real money gambling industry.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
