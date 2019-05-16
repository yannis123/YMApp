
import { Component, OnInit, Injector, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import { CreateOrUpdateProductAttributeInput,ProductAttributeEditDto, ProductAttributeServiceProxy } from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';

@Component({
  selector: 'create-or-edit-product-attribute',
  templateUrl: './create-or-edit-product-attribute.component.html',
  styleUrls:[
	'create-or-edit-product-attribute.component.less'
  ],
})

export class CreateOrEditProductAttributeComponent
  extends ModalComponentBase
    implements OnInit {
    /**
    * 编辑时DTO的id
    */
    id: any ;

	  entity: ProductAttributeEditDto=new ProductAttributeEditDto();

    /**
    * 初始化的构造函数
    */
    constructor(
		injector: Injector,
		private _productAttributeService: ProductAttributeServiceProxy
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
		this._productAttributeService.getForEdit(this.id).subscribe(result => {
			this.entity = result.productAttribute;
		});
    }

    /**
    * 保存方法,提交form表单
    */
    submitForm(): void {
		const input = new CreateOrUpdateProductAttributeInput();
		input.productAttribute = this.entity;

		this.saving = true;

		this._productAttributeService.createOrUpdate(input)
		.finally(() => (this.saving = false))
		.subscribe(() => {
			this.notify.success(this.l('SavedSuccessfully'));
			this.success(true);
		});
    }
}
