range1Original = [-40.0, -30.0, -20.0, -12.5, -0.75, -0.25, -0.05, 0.0, 0.25, 2.5, 6.0, 9.0, 14.0, 20.0, 25.0]

colorsOriginal = [
    (0, 0, 80),
    (0, 30, 100),
    (0, 50, 102),
    (19, 108, 160),
    (24, 140, 205),
    (135, 206, 250),
    (176, 226, 255),
    (0, 97, 71),
    (16, 122, 47),
    (232, 215, 125),
    (161, 67, 0),
    (130, 30, 30),
    (161, 161, 161),
    (206, 206, 206),
    (255, 255, 255)
]
# -----------------------------
colors = [
    (0, 50, 102),
    (19, 108, 160),
    (135, 206, 250),
    (176, 226, 255),
    (0, 97, 71),
    (16, 122, 47),
    (232, 215, 125),
    (161, 67, 0),
    (130, 30, 30),
    (255, 255, 255)
]
range1 = range(-20,20,4)


divider = 255

for index, j in enumerate(range1):
    i = float(j)
    col = colors[index]
    newRange = (((i - float(range1[0])) * (0.6 - 0)) / (float(range1[len(range1) - 1]) - float(range1[0]))) + 0
    # print ("%.2f" % newRange), \
    #     ("%.2f" % float(col[0] / float(divider))), \
    #     ("%.2f" % float(col[1] / float(divider))), \
    #     ("%.2f" % float(col[2] / float(divider)))

    print "	else if (height < " + ("%.2f" % newRange) + "f) { " \
                                                           "color = fixed4(" + \
            ("%.2f" % float(col[0] / float(divider))) + "," +\
            ("%.2f" % float(col[1] / float(divider))) + "," + \
            ("%.2f" % float(col[2] / float(divider))) + ",1.0);}"
