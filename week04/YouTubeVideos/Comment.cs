using System;
using System.Collections.Generic;
using System.ComponentModel;
class Comment
{
    private string _commenterName;
    private string _text;
    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text = text;
    }
    public string CommenterName()
    {
        return _commenterName;
    }
    public string Text(){
        return _text;
    }

}