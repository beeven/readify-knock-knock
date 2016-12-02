from io import StringIO

def reverse_words(sentence):
    out_str = StringIO()
    temp_str = StringIO()
    for c in sentence:
        if not c.isspace():
            temp_str.write(c)
        else:
            word = temp_str.getvalue()
            out_str.write(word[::-1])
            out_str.write(c)
            temp_str = StringIO()
    word = temp_str.getvalue()
    out_str.write(word[::-1])
    return out_str.getvalue()