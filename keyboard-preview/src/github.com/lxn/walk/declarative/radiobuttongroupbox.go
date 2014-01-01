// Copyright 2013 The Walk Authors. All rights reserved.
// Use of this source code is governed by a BSD-style
// license that can be found in the LICENSE file.

package declarative

import (
	"github.com/lxn/walk"
)

type RadioButtonGroupBox struct {
	AssignTo         **walk.GroupBox
	Name             string
	Enabled          Property
	Visible          Property
	Font             Font
	ToolTipText      Property
	MinSize          Size
	MaxSize          Size
	StretchFactor    int
	Row              int
	RowSpan          int
	Column           int
	ColumnSpan       int
	ContextMenuItems []MenuItem
	OnKeyDown        walk.KeyEventHandler
	OnKeyPress       walk.KeyEventHandler
	OnKeyUp          walk.KeyEventHandler
	OnMouseDown      walk.MouseEventHandler
	OnMouseMove      walk.MouseEventHandler
	OnMouseUp        walk.MouseEventHandler
	OnSizeChanged    walk.EventHandler
	Title            string
	DataBinder       DataBinder
	Layout           Layout
	Children         []Widget
	DataMember       string
	Optional         bool
	Buttons          []RadioButton
}

func (rbgb RadioButtonGroupBox) Create(builder *Builder) error {
	w, err := walk.NewGroupBox(builder.Parent())
	if err != nil {
		return err
	}

	w.SetSuspended(true)
	builder.Defer(func() error {
		w.SetSuspended(false)
		return nil
	})

	return builder.InitWidget(rbgb, w, func() error {
		if err := w.SetTitle(rbgb.Title); err != nil {
			return err
		}

		if err := (RadioButtonGroup{
			DataMember: rbgb.DataMember,
			Optional:   rbgb.Optional,
			Buttons:    rbgb.Buttons,
		}).Create(builder); err != nil {
			return err
		}

		if rbgb.AssignTo != nil {
			*rbgb.AssignTo = w
		}

		return nil
	})
}

func (w RadioButtonGroupBox) WidgetInfo() (name string, disabled, hidden bool, font *Font, toolTipText string, minSize, maxSize Size, stretchFactor, row, rowSpan, column, columnSpan int, contextMenuItems []MenuItem, OnKeyDown walk.KeyEventHandler, OnKeyPress walk.KeyEventHandler, OnKeyUp walk.KeyEventHandler, OnMouseDown walk.MouseEventHandler, OnMouseMove walk.MouseEventHandler, OnMouseUp walk.MouseEventHandler, OnSizeChanged walk.EventHandler) {
	return w.Name, false, false, &w.Font, "", w.MinSize, w.MaxSize, w.StretchFactor, w.Row, w.RowSpan, w.Column, w.ColumnSpan, w.ContextMenuItems, w.OnKeyDown, w.OnKeyPress, w.OnKeyUp, w.OnMouseDown, w.OnMouseMove, w.OnMouseUp, w.OnSizeChanged
}

func (rbgb RadioButtonGroupBox) ContainerInfo() (DataBinder, Layout, []Widget) {
	return rbgb.DataBinder, rbgb.Layout, nil
}
