// multilinelabel.go - Extends the base walk.Label type to support multiple lines.
package main

import (
	"github.com/lxn/walk"
	d "github.com/lxn/walk/declarative"
	"github.com/lxn/win"
)

type multilineLabel struct {
	walk.Label
	textChangedPublisher walk.EventPublisher
}

type MultilineLabel struct {
	d.Label
	AssignTo         **multilineLabel
	Name             string
	Enabled          d.Property
	Visible          d.Property
	Font             d.Font
	ToolTipText      d.Property
	MinSize          d.Size
	MaxSize          d.Size
	StretchFactor    int
	Row              int
	RowSpan          int
	Column           int
	ColumnSpan       int
	ContextMenuItems []d.MenuItem
	OnKeyDown        walk.KeyEventHandler
	OnKeyPress       walk.KeyEventHandler
	OnKeyUp          walk.KeyEventHandler
	OnMouseDown      walk.MouseEventHandler
	OnMouseMove      walk.MouseEventHandler
	OnMouseUp        walk.MouseEventHandler
	OnSizeChanged    walk.EventHandler
	Text             d.Property
}

func NewMultilineLabel(parent walk.Container) (*multilineLabel, error) {
	l := new(multilineLabel)

	if err := walk.InitWidget(
		l,
		parent,
		"STATIC",
		win.WS_VISIBLE|win.SS_CENTER,
		0); err != nil {
		return nil, err
	}

	l.MustRegisterProperty("Text", walk.NewProperty(
		func() interface{} {
			return l.Text()
		},
		func(v interface{}) error {
			return l.SetText(v.(string))
		},
		l.textChangedPublisher.Event()))

	return l, nil
}

func (l MultilineLabel) Create(builder *d.Builder) error {
	w, err := NewMultilineLabel(builder.Parent())
	if err != nil {
		return err
	}

	return builder.InitWidget(l, w, func() error {
		if l.AssignTo != nil {
			*l.AssignTo = w
		}

		return nil
	})
}
