
import { Component, OnInit, Injector, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import { CreateOrUpdatePictureInput,PictureEditDto, PictureServiceProxy } from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';

@Component({
  selector: 'create-or-edit-picture',
  templateUrl: './create-or-edit-picture.component.html',
  styleUrls:[
	'create-or-edit-picture.component.less'
  ],
})

export class CreateOrEditPictureComponent
  extends ModalComponentBase
    implements OnInit {
    /**
    * 编辑时DTO的id
    */
    id: any ;

	  entity: PictureEditDto=new PictureEditDto();

    /**
    * 初始化的构造函数
    */
    constructor(
		injector: Injector,
		private _pictureService: PictureServiceProxy
	) {
		super(injector);
    }

    ngOnInit() :void{
		this.init();
    }


    /**
    * 初始化方法
    */
    init(): void {
		this._pictureService.getForEdit(this.id).subscribe(result => {
			this.entity = result.picture;
		});
    }

    /**
    * 保存方法,提交form表单
    */
    submitForm(): void {
		const input = new CreateOrUpdatePictureInput();
		input.picture = this.entity;

		this.saving = true;

		this._pictureService.createOrUpdate(input)
		.finally(() => (this.saving = false))
		.subscribe(() => {
			this.notify.success(this.l('SavedSuccessfully'));
			this.success(true);
		});
    }
}
